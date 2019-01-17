EntityType = {
    Active = 1,
    Static = 2,
}

RelationType = {
    NoRelation = 0,
    Friendly = 1,
    Opposed = 2,
}

local Class_EntityManager = class()
EntityManager = Class_EntityManager.new()

function Class_EntityManager:Init()
    Event.AddListener(EventType.TransformChange, self.TransformChange, self)
    Event.AddListener(EventType.TakeDamage, self.TakeDamage, self)
    Event.AddListener(EventType.StateChange, self.StateChange, self)
    Event.AddListener(EventType.ShootBullet, self.ShootBullet, self)

    self.EntityAsset = {}
    local entityConfig = ConfigTable[ConfigName.Entity]
    for key, value in pairs(entityConfig) do
        local entity = {}
        entity.ID = tonumber(value["ID"])
        entity.Name = tostring(value["Name"])
        entity.ResourceName = tostring(value["ResourceName"])
        entity.Asset = ResourceManager.Instance:LoadPrefab("SceneResources", entity.ResourceName)
        self.EntityAsset[entity.ID] = entity
    end

    self.EntityList = {}

    self.MotionController = nil
    self.InputController = nil
    self.PositionTimer = nil
end

function Class_EntityManager:TransformChange(Msg)
    for key, value in ipairs(Msg.transforminfo) do
        positionDict, rotationDict = {}, {}
        for key, value in ipairs(value.position) do
            table.insert(positionDict, value)
        end    
        for key, value in ipairs(value.rotation) do
            table.insert(rotationDict, value)
        end

        local mail = value.mail
        if self.EntityList[mail] == nil then
            local param = {}
            param.ModelID = 102
            param.Name = mail
            param.Position = Vector3.New(positionDict[1], positionDict[2], positionDict[3])
            param.Rotation = Quaternion.Euler(0, 0, 0)
            param.Parent = nil
            param.EntityType = EntityType.Active
            param.EntityID = mail
            param.RelationType = RelationType.Opposed
            self.EntityList[mail] = self:CreateEntity(param)
        end

        local motionController = self.EntityList[mail]:GetComponent(typeof(MotionController))
        if motionController then
            motionController.speed = value.speed
            motionController.moveDirection = Vector3.New(rotationDict[1], rotationDict[2], rotationDict[3])
            motionController.movePosition = Vector3.New(positionDict[1], positionDict[2], positionDict[3])
        end
    end
end

function Class_EntityManager:TakeDamage(Msg)
    local shooter = Msg.shooter
    local target = Msg.target
    print(shooter.entityid, target.entityid, Msg.damage)
end

function Class_EntityManager:StateChange(Msg)
    local entity = Msg.entity
    print(entity.entityid, entity.health, entity.score)
end

function Class_EntityManager:ShootBullet(Msg)
    local mail = Msg.mail
    local entity = self.EntityList[mail]
    if not LuaUtils:IsNil(entity) then
        local model = entity:GetComponent(typeof(MotionController)).Model
        local launchPoint = Utils.FindChild(model, "LaunchPoint")
        local param = {}
        param.ModelID = 103
        param.Name = "bullet"
        param.Position = launchPoint.transform.position
        param.Rotation = model.transform.rotation
        param.Parent = nil
        param.EntityType = EntityType.Static
        param.EntityID = ""
        param.RelationType = RelationType.NoRelation
        local bullet = self:CreateEntity(param)
        local bulletController = bullet:GetComponent(typeof(BulletController))
        bulletController.parent = entity
        bulletController.gameObject.name = entity.name.."_"..bulletController.bulletID
        bulletController.OnCollision:AddCallback(self, self.OnCollision)
    end
end

function Class_EntityManager:CreatePlayer(EntityID, Position, Rotation)
    local mail = NetworkSender.Mail
    if self.EntityList[mail] == nil then
        local param = {}
        param.ModelID = 101
        param.Name = "Player"
        param.Position = Position
        param.Rotation = Rotation
        param.Parent = nil
        param.EntityType = EntityType.Active
        param.EntityID = EntityID
        param.RelationType = RelationType.Friendly
        self.EntityList[mail] = self:CreateEntity(param)
    end
    self.MotionController = self.EntityList[mail]:GetComponent(typeof(MotionController))
    self.InputController = self.EntityList[mail]:GetComponent(typeof(InputController))
    if self.PositionTimer == nil then
        self.PositionTimer = Timer.New(self.PositionSync, self, 0.1, -1, false)
    end
    self.PositionTimer:Start()
    return self.EntityList[mail]
end

function Class_EntityManager:PositionSync()
    local mail = NetworkSender.Mail
    local player = self.EntityList[mail]
    if player == nil then return end

    local speed = self.InputController.speed
    local position = player.transform.position
    local rotation = self.InputController.moveVector
    NetworkSender:TransformSync(speed, position, rotation)
end

function Class_EntityManager:OnCollision(Object, Collision)
    local entity = Collision:GetComponent(typeof(Entity))
    NetworkSender:TakeDamage(entity.EntityType, entity.EntityID)
    GameObject.Destroy(Object)
end

function Class_EntityManager:DestroyEntity(Msg)
    local mail = Msg.mail
    if not LuaUtils.IsNil(self.EntityList[mail]) then
        local entity = self.EntityList[mail]
        GameObject.Destroy(entity)
    end
end

function Class_EntityManager:CreateEntity(Param)
    local Template = self.EntityAsset[Param.ModelID]
    if Template == nil then
        print("实例化模型出错", Param.ModelID)
        return 
    end
    local itemGo = GameObject.Instantiate(Template.Asset, Param.Position, Param.Rotation)
    itemGo.name = Param.Name
    if Param.Parent then
        itemGo.transform:SetParent(Param.Parent.transform, false)
    end
    local entity = itemGo:GetComponent(typeof(Entity))
    if entity == nil then
        entity = itemGo:AddComponent(typeof(Entity))
    end
    entity.EntityType = Param.EntityType
    entity.EntityID = Param.EntityID
    entity.RelationType = Param.RelationType

    if Param.RelationType ~= nil then
        local asset
        if Param.RelationType == RelationType.Friendly then
            asset = ResourceManager.Instance:LoadPrefab("Core", "BaseBlueBar")
        elseif Param.RelationType == RelationType.Opposed then
            asset = ResourceManager.Instance:LoadPrefab("Core", "BaseRedBar")
        end
        local barEntity = GameObject.Instantiate(asset)
        local bar = barEntity:AddComponent(typeof(BarBase))
        local follow3DTarget = bar:GetComponent(typeof(Follow3DTarget))
        follow3DTarget.Target = entity.gameObject
    end

    return itemGo
end

function Class_EntityManager:OnDestroy()
    self.PositionTimer:Stop()
end