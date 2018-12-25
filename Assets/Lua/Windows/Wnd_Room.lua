require("Windows/WindowBase")
require("EntityManager")

local Wnd_RoomClass = class(WindowBase)

function Wnd_RoomClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UIRoomEnter, self.Show, self)
    Event.AddListener(EventType.UIRoomExit, self.Hide, self)
end

function Wnd_RoomClass:OnNewInstance()
    self.EntityManager = Class_EntityManager.new()
    self.EntityManager:Init()
    self.EntityManager:CreatePlayer()
end

function Wnd_RoomClass:OnShowDone()

end

function Wnd_RoomClass:OnLostInstance()
    Event.RemoveListener(EventType.UIRoomEnter, self.Show)
    Event.RemoveListener(EventType.UIRoomExit, self.Hide)
    self.EntityManager:OnDestroy()
end

return Wnd_RoomClass.new