require("class")
require("Config")

WindowList = nil    --注册窗口列表
UICanvas = nil      --Canvas父类

Class_WindowManager = class()
WindowManager = Class_WindowManager.new()

function Class_WindowManager:Init()
    local windowConfig = ConfigTable[ConfigName.WindowDefine]
    if windowConfig == nil then
        print("加载窗口配置表失败")
        return
    end
    WindowList = {}
    for key, value in pairs(windowConfig) do
        local windowDepth = tonumber(value["Depth"])
        local windowName = tostring(value["LuaName"])
        local bundleName = tostring(value["BundleName"])
        local assetName = tostring(value["AssetName"])
        local windowClass = require("Windows/"..windowName)
        if windowClass then
            local window = windowClass()
            table.insert(WindowList, {
                Window = window,
                WindowDepth = windowDepth,
                WindowName = windowName,
                BundleName = bundleName,
                AssetName = assetName,
            })
        end
    end

    local sortFunc = function(Item1, Item2)
        return Item1.WindowDepth < Item2.WindowDepth
    end
    table.sort(WindowList, sortFunc)

    for k = 1, #WindowList do
        local window = WindowList[k]
        window.Window:Start(k)
        print("初始化窗口成功", window.WindowName)
    end

    UICanvas = GameObject.Find("Canvas")
    if UICanvas == nil then
        print("查找Canvas失败")
    else
        -- GameObject.DontDestroyOnLoad(UICanvas)
        print("找到组件", UICanvas.name)
    end

    self.TimeRecord = 0
    UpdateBeat:Add(self.Update, self)
end

function Class_WindowManager:Show(WindowIndex)
    if WindowIndex == nil or WindowList[WindowIndex] == nil then
        print("调用非法窗口:", WindowIndex)
        return
    end
    local windowInfo = WindowList[WindowIndex]
    local instance = windowInfo.Window.Instance
    if LuaUtils:IsNil(instance) then
        local asset = ResourceManager.Instance:LoadPrefab(windowInfo.BundleName, windowInfo.AssetName)
        if asset then
            local object = GameObject.Instantiate(asset)
            object.name = windowInfo.WindowName
            object.transform:SetParent(UICanvas.transform, false)
            object.transform.eulerAngles = Vector3.New(0, 0, 0)
            windowInfo.Window.Instance = object          
            windowInfo.Window:OnNewInstance()
            print("加载窗口成功", object.name)
        else
            print("加载资源错误", WindowIndex)
            return
        end
    end
    windowInfo.Window.Instance:SetActive(true)
    windowInfo.Window:OnShowDone()

    self:WindowDepthManage()
end

function Class_WindowManager:Hide(WindowIndex)
    if WindowIndex == nil or WindowList[WindowIndex] == nil then
        print("调用非法窗口", WindowIndex)
        return
    end
    local windowInfo = WindowList[WindowIndex]
    local instance = windowInfo.Window.Instance
    if instance then
        instance:SetActive(false)
    else
        print("窗口不存在", WindowIndex)
    end
end

function Class_WindowManager:WindowDepthManage()
    for k = 1, #WindowList do
        local window = WindowList[k]
        local instance = window.Window.Instance
        if instance then
            instance.transform:SetSiblingIndex(k - 1)
        end
    end
end

function Class_WindowManager:Update()
    self.TimeRecord = self.TimeRecord + Time.deltaTime
    if self.TimeRecord > 1 then
        self.TimeRecord = 0
    end
end

function Class_WindowManager:ReGetCanvas()
    UICanvas = GameObject.Find("Canvas")
end
