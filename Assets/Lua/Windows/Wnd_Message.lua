require("Windows/WindowBase")

local Wnd_MessageClass = class(WindowBase)

function Wnd_MessageClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UIMessageEnter, self.Show, self)
    Event.AddListener(EventType.UIMessageExit, self.Hide, self)
end

function Wnd_MessageClass:OnNewInstance()

end

function Wnd_MessageClass:OnShowDone()

end

function Wnd_MessageClass:OnLostInstance()
    Event.RemoveListener(EventType.UIMessageEnter, self.Show)
    Event.RemoveListener(EventType.UIMessageExit, self.Hide)
end

return Wnd_MessageClass.new