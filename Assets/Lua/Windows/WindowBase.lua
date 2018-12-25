require("class")
require("Windows/WindowManager")

WindowBase = class()

function WindowBase:ctor()
    self.Instance = nil     --窗口实例
    self.WindowIndex = nil  --窗口地址
end

function WindowBase:Show()
    if self:Visible() then return end
    WindowManager:Show(self.WindowIndex)
end

function WindowBase:Hide()
    if not self:Visible() then return end
    WindowManager:Hide(self.WindowIndex)
end

function WindowBase:Listen(Object, Type, CallBack, Param)
    local listener = Object:GetComponent(typeof(UIEventListener))
    if listener == nil then
        listener = Object:AddComponent(typeof(UIEventListener))
    end
    listener:Listen(Object, Type, self, CallBack, Param)
end

function WindowBase:Visible()
    if LuaUtils:IsNil(self.Instance) then
        return false
    else
        return self.Instance.activeSelf  
    end
end