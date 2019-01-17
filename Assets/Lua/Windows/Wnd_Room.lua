require("Windows/WindowBase")
require("EntityManager")

local Wnd_RoomClass = class(WindowBase)

function Wnd_RoomClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UIRoomEnter, self.Show, self)
    Event.AddListener(EventType.UIRoomExit, self.Hide, self)
end

function Wnd_RoomClass:OnNewInstance()
    self.ShootBtn = Utils.FindChild(self.Instance, "Shoot")
    self:Listen(self.ShootBtn, EventTriggerType.PointerClick, self.OnShootClick)
end

function Wnd_RoomClass:OnShowDone()
    MapDrawer:CreateMap(1)
    local player = EntityManager:CreatePlayer(NetworkSender.Mail, MapDrawer:GetRandomPos(1), Quaternion.Euler(0, 0, 0))
    local camera = GameObject.Find("Camera")
    local cameraController = camera:GetComponent(typeof((CameraController)))
    cameraController.target = player.transform
end

function Wnd_RoomClass:OnShootClick(Object)
    NetworkSender:ShootBullet()
end

function Wnd_RoomClass:OnLostInstance()
    Event.RemoveListener(EventType.UIRoomEnter, self.Show)
    Event.RemoveListener(EventType.UIRoomExit, self.Hide)
    self.EntityManager:OnDestroy()
end

return Wnd_RoomClass.new