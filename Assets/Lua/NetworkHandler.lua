require("ErrorID")
require("Protos/GC_GS_pb")
require("Protos/GC_LS_pb")
require("Protos/CS_GS_pb")

local NetworkHandlerClass = class()
NetworkHandler = NetworkHandlerClass.new()

function NetworkHandlerClass:Init()
    NetworkManager.Instance.HandleNetMsg:AddCallback(self, self.HandleNetMsg)
    NetworkManager.Instance.HandleConnect:AddCallback(self, self.HandleConnect)
    NetworkManager.Instance.HandleDisConnect:AddCallback(self, self.HandleDisConnect)
end

function NetworkHandlerClass:HandleConnect(Type, ConnectTimes)
    print("已连接服务器", System.Enum.ToString(Type))
    Event.Brocast(EventType.UIWaitExit)
    if Type == ServerType.LoginServer then
        Event.Brocast(EventType.UILoginEnter)
    elseif Type == ServerType.GateServer then
        NetworkSender:AskLoginGate()
    end
end

function NetworkHandlerClass:HandleDisConnect(Type)
    print("已断开连接", System.Enum.ToString(Type))
    Event.Brocast(EventType.UIWaitEnter)
end

function NetworkHandlerClass:HandleNetMsg(Data, MsgID)
    print("接受消息", MsgID)
    if MsgID == GC_LS_pb.LS2GC_NotifyServerBSAddr then
        local recv = GC_LS_pb.ServerBSAddr()
        recv:ParseFromString(Data)
        self:OnGetServerList(recv)
    elseif MsgID == GC_GS_pb.GC2GS_TokenLogin then
        local login = GC_GS_pb.TokenLogin()
        login:ParseFromString(Data)
        self:EnterLobby(login)
    elseif MsgID == CS_GS_pb.CS2GS_UserInfo then
        local userInfo = CS_GS_pb.UserInfo()
        userInfo:ParseFromString(Data)
        Event.Brocast(EventType.UserInfo, userInfo)
    elseif MsgID == CS_GS_pb.CS2GS_StartMatch then

    elseif MsgID == CS_GS_pb.CS2GS_EnterRoom then
        local msgInfo = CS_GS_pb.EnterRoom()
        msgInfo:ParseFromString(Data)
        self:EnterRoom(msgInfo)
    elseif MsgID == CS_GS_pb.CS2GS_TransformSync then
        local msgInfo = CS_GS_pb.TransformSync()
        msgInfo:ParseFromString(Data)
        self:TransformChange(msgInfo)
    elseif MsgID == CS_GS_pb.CS2GS_TakeDamage then
        local msgInfo = CS_GS_pb.TakeDamage()
        msgInfo:ParseFromString(Data)
        self:TakeDamage(msgInfo)
    elseif MsgID == CS_GS_pb.CS2GS_StateSync then
        local msgInfo = CS_GS_pb.StateSync()
        msgInfo:ParseFromString(Data)
        self:StateChange(msgInfo)
    elseif MsgID == CS_GS_pb.CS2GS_ShootBullet then
        local msgInfo = CS_GS_pb.ShootBullet()
        msgInfo:ParseFromString(Data)
        self:ShootBullet(msgInfo)
    elseif MsgID == GC_LS_pb.LS2GC_Error then
        local recv = GC_LS_pb.ErrorMsg()
        recv:ParseFromString(Data)
        self:HandleError(recv.errorid)
    elseif GC_GS_pb.GS2GC_Error then
        local recv = GC_GS_pb.ErrorMsg()
        recv:ParseFromString(Data)
        self:HandleError(recv.errorid)
    end
end

function NetworkHandlerClass:HandleError(Error)
    local errorInfo = ErrorID[tonumber(Error)]
    if errorInfo then
        print(errorInfo)
    else
        print("无法处理的错误ID", Error)
    end
end

function NetworkHandlerClass:OnGetServerList(Msg)
    self.ServerList = {}
    for key, value in ipairs(Msg.serverinfo) do
        local server = {}
        server.Name = value.ServerName
        server.Addr = value.ServerAddr
        server.Port = value.ServerPort
        server.State = value.ServerState
        table.insert(self.ServerList, server)
    end
    Event.Brocast(EventType.UISelectServerEnter)
    Event.Brocast(EventType.UILoginExit)
end

function NetworkHandlerClass:EnterLobby(Msg)
    NetworkSender.Token = Msg.token
    Event.Brocast(EventType.UISelectServerExit)
    local loadFinished = function()
        WindowManager:ReGetCanvas()
        Event.Brocast(EventType.UILogEnter)
        Event.Brocast(EventType.UILobbyEnter)
    end
    LoadingScreen.LoadScene("Lobby", loadFinished)
end

function NetworkHandlerClass:EnterRoom(Msg)
    NetworkSender.RoomID = Msg.roomid
    local loadFinished = function()
        WindowManager:ReGetCanvas()
        Event.Brocast(EventType.UpdateMap, Msg.mapid, Msg.mapdata)
        Event.Brocast(EventType.UILogEnter)
        Event.Brocast(EventType.UIRoomEnter)
    end
    LoadingScreen.LoadScene("Battle01", loadFinished)
end

function NetworkHandlerClass:TransformChange(Msg)
    Event.Brocast(EventType.TransformChange, Msg)
end

function NetworkHandlerClass:TakeDamage(Msg)
    Event.Brocast(EventType.TakeDamage, Msg)
end

function NetworkHandlerClass:StateChange(Msg)
    Event.Brocast(EventType.StateChange, Msg)
end

function NetworkHandlerClass:ShootBullet(Msg)
    Event.Brocast(EventType.ShootBullet, Msg)
end

-- local req = GetPlayerListReq()
-- for i=0,4 do
--     req.Ids:append(id)
-- end

-- local res = GetPlayerListRes()
-- for i=0,4 do
--     local player = req.players:add()
--     player.Name = name
--     player.Id = id
-- end