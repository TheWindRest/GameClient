require("Windows/WindowBase")

local Wnd_LogClass = class(WindowBase)

function Wnd_LogClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UILogEnter, self.Show, self)
    Event.AddListener(EventType.UILogExit, self.Hide, self)
end

function Wnd_LogClass:OnNewInstance()
    self.ShowBtn = Utils.FindChild(self.Instance, "ShowBtn")
    self:Listen(self.ShowBtn, EventTriggerType.PointerClick, self.OnShowClick)
end

function Wnd_LogClass:OnShowDone()

end

function Wnd_LogClass:OnShowClick(Object)
    LogRecord.Instance:ControlOpen()
    print("已开启日志显示")
end

function Wnd_LogClass:OnLostInstance()
    Event.RemoveListener(EventType.UILogEnter, self.Show)
    Event.RemoveListener(EventType.UILogExit, self.Hide)
end

return Wnd_LogClass.new