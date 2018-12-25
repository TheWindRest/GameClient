require("Windows/WindowBase")

local Wnd_LobbyClass = class(WindowBase)

function Wnd_LobbyClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UILobbyEnter, self.Show, self)
    Event.AddListener(EventType.UILobbyExit, self.Hide, self)
    Event.AddListener(EventType.UserInfo, self.UpdateUserInfo, self)
end

function Wnd_LobbyClass:OnNewInstance()
    local PlayBtn = Utils.FindChild(self.Instance, "PlayBtn")
    self:Listen(PlayBtn, EventTriggerType.PointerClick, self.OnPlayClick)
end

function Wnd_LobbyClass:OnShowDone()
    NetworkSender:AskUserInfo()
end

function Wnd_LobbyClass:OnPlayClick(Object)
    NetworkSender:StartMatch()
end

function Wnd_LobbyClass:UpdateUserInfo(UserInfo)
    print(UserInfo.name)
end

function Wnd_LobbyClass:OnLostInstance()
    Event.RemoveListener(EventType.UILobbyEnter, self.Show)
    Event.RemoveListener(EventType.UILobbyExit, self.Hide)
end

return Wnd_LobbyClass.new