require("Windows/WindowBase")

local Wnd_WaitClass = class(WindowBase)

function Wnd_WaitClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UIWaitEnter, self.Show, self)
    Event.AddListener(EventType.UIWaitExit, self.Hide, self)
end

function Wnd_WaitClass:OnNewInstance()

end

function Wnd_WaitClass:OnShowDone()

end

function Wnd_WaitClass:OnLostInstance()
    Event.RemoveListener(EventType.UIWaitEnter, self.Show)
    Event.RemoveListener(EventType.UIWaitExit, self.Hide)
end

return Wnd_WaitClass.new