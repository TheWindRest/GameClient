local Class_MapDrawer = class()
MapDrawer = Class_MapDrawer.new()

function Class_MapDrawer:Init()
    self.ObjectParent = GameObject.Find("MapDrawer")
    if self.ObjectParent == nil then
        self.ObjectParent = GameObject.New("MapDrawer")
        self.ObjectParent.transform.position = Vector3.New(0, 0, 0)
    else
        print("找到组件", self.ObjectParent.name)
    end
    GameObject.DontDestroyOnLoad(self.ObjectParent)
    self.ItemList = {}
    self.MapData = {}

    Event.AddListener(EventType.UpdateMap, self.AddMap, self)
end

function Class_MapDrawer:AddLocalMap()
    local mapConfig = ConfigTable[ConfigName.Map]
    for key, value in pairs(mapConfig) do
        local map = {}
        map.ID = tonumber(value["ID"])
        map.Name = tostring(value["Name"])
        map.Data = self:GetMapData(map.Name)
        self.MapData[map.ID] = map
    end
end

function Class_MapDrawer:GetMapData(MapName)
    local asset = ResourceManager.Instance:LoadTextAsset("Map", "MapInfo"..MapName.."_Level1")
    if asset then
        return self:ParseMapData(asset.text)
    end
end

function Class_MapDrawer:AddMap(MapID, Text)
    local mapData = self:ParseMapData(Text)
    local map = self:GetMapInfo(tonumber(MapID))
    if next(map) ~= nil then
        map.Data = mapData
        self.MapData[map.ID] = map
    end
end

function Class_MapDrawer:GetMapInfo(MapID)
    local map = {}
    local mapConfig = ConfigTable[ConfigName.Map]
    for key, value in pairs(mapConfig) do
        if MapID == tonumber(value["ID"]) then
            map.ID = tonumber(value["ID"])
            map.Name = tostring(value["Name"])
        end
    end
    return map
end

function Class_MapDrawer:ParseMapData(Text)
    local mapData = {}
    local textArray = string.split(Text, "\n")
    for key1, value1 in pairs(textArray) do
        mapData[key1] = {}
        local oneLine = string.split(value1, ",")
        for key2, value2 in pairs(oneLine) do
            mapData[key1][key2] = tonumber(value2)
        end
    end
    return mapData
end

function Class_MapDrawer:CreateMap(MapID)
    local map = self.MapData[MapID]
    if map == nil then
        print("地图<"..MapID..">加载出错")
        return false
    end
    for key1, value1 in pairs(self.ItemList) do
        for key2, value2 in pairs(value1) do
            GameObject.Destroy(value2)
        end
    end
    self.ItemList = {}

    for key1, value1 in pairs(map.Data) do
        for key2, value2 in pairs(value1) do
            if value2 > 0 then
                local param = {}
                param.ModelID = value2
                param.Name = key1.."_"..key2
                param.Position = Vector3.New(key1, key2, 0) * 3.2
                param.Rotation = Quaternion.Euler(0, 0, 0)
                param.Parent = self.ObjectParent
                param.EntityType = EntityType.Static
                param.EntityID = key1.."_"..key2
                param.RelationType = RelationType.NoRelation
                local itemGo = EntityManager:CreateEntity(param)
                if self.ItemList[key1] == nil then
                    self.ItemList[key1] = {}
                end
                self.ItemList[key1][key2] = itemGo
            end
        end
    end
end

function Class_MapDrawer:GetRandomPos(MapID)
    local map = self.MapData[MapID]
    if map == nil then
        print("地图<"..MapID..">加载出错")
        return Vector3.New(0, 0, 0)
    end
    local randomPos = {}
    for key1, value1 in pairs(map.Data) do
        for key2, value2 in pairs(value1) do
            if value2 == 0 then
                table.insert(randomPos, Vector3.New(key1, key2, 0) * 3.2)
            end
        end
    end

    math.randomseed(tostring(os.time()):reverse():sub(1, 6))
    local num = math.random(1, #randomPos)
    return randomPos[num]
end
