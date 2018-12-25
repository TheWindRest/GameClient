
Class_EntityManager = class()

function Class_EntityManager:Init()
    Event.AddListener(EventType.TransformChange, self.TransformChange, self)
    Event.AddListener(EventType.StateChange, self.StateChange, self)
    self.PlayerAsset = ResourceManager.Instance:LoadPrefab("SceneResources", "Player")
    self.EntityAsset = ResourceManager.Instance:LoadPrefab("SceneResources", "Other")
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
            local entity = GameObject.Instantiate(self.EntityAsset)
            entity.name = mail
            self.EntityList[mail] = entity
            entity.transform.position = Vector3.New(positionDict[1], positionDict[2], positionDict[3])
        end

        local motionController = self.EntityList[mail]:GetComponent(typeof(MotionController))
        if motionController then
            motionController.speed = value.speed
            motionController.moveDirection = Vector3.New(rotationDict[1], rotationDict[2], rotationDict[3])
            motionController.movePosition = Vector3.New(positionDict[1], positionDict[2], positionDict[3])
        end
    end
end

function Class_EntityManager:StateChange(Msg)
    -- body
end

function Class_EntityManager:CreatePlayer()
    local mail = NetworkSender.Mail
    if self.EntityList[mail] == nil then
        local entity = GameObject.Instantiate(self.PlayerAsset)
        entity.name = "Player"
        self.EntityList[mail] = entity
    end
    self.MotionController = self.EntityList[mail]:GetComponent(typeof(MotionController))
    self.InputController = self.EntityList[mail]:GetComponent(typeof(InputController))
    if self.PositionTimer == nil then
        self.PositionTimer = Timer.New(self.PositionSync, self, 0.1, -1, false)
    end
    self.PositionTimer:Start()
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

function Class_EntityManager:DestroyEntity(Msg)
    local mail = Msg.mail
    if not LuaUtils.IsNil(self.EntityList[mail]) then
        local entity = self.EntityList[mail]
        GameObject.Destroy(entity)
    end
end

function Class_EntityManager:OnDestroy()
    self.PositionTimer:Stop()
end