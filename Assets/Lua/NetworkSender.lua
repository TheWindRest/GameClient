require("ErrorID")
require("Protos/GC_GS_pb")
require("Protos/GC_LS_pb")
require("Protos/CS_GS_pb")

local NetworkSenderClass = class()
NetworkSender = NetworkSenderClass.new()

function NetworkSenderClass:Init()
    self.Mail = nil
    self.Password = nil
    self.Platform = nil
    self.Token = ""
    self.RoomID = nil
end

function NetworkSenderClass:AskLogin(Mail, Password, Platform)
    self.Mail = Mail
    self.Password = Password
    self.Platform = Platform
    
    local login = GC_LS_pb.AskLogin()
    login.msgid = GC_LS_pb.GC2LS_AskLogin
    login.platform = Platform
    login.mail = Mail
    login.password = Password
    
    local msg = login:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, login.msgid)
end

function NetworkSenderClass:AskLoginGate()
    if self.Mail == nil or self.Password == nil then
        Debug.LogError("登陆信息有误")
        return
    end
    local login = GC_GS_pb.TokenLogin()
    login.msgid = GC_GS_pb.GC2GS_TokenLogin
    login.mail = self.Mail
    login.password = self.Password
    login.token = self.Token
    
    local msg = login:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, login.msgid)
end

function NetworkSenderClass:AskUserInfo()
    local msgInfo = CS_GS_pb.UserInfo()
    msgInfo.msgid = CS_GS_pb.CS2GS_UserInfo
    msgInfo.name = ""
    local msg = msgInfo:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, msgInfo.msgid)
end

function NetworkSenderClass:StartMatch()
    local msgInfo = CS_GS_pb.StartMatch()
    msgInfo.msgid = CS_GS_pb.CS2GS_StartMatch
    msgInfo.mail = self.Mail
    msgInfo.result = 0
    local msg = msgInfo:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, msgInfo.msgid)
end

function NetworkSenderClass:TransformSync(Speed, Position, Rotation)
    local msgInfo = CS_GS_pb.TransformSync()
    msgInfo.msgid = CS_GS_pb.CS2GS_TransformSync
    msgInfo.mail = self.Mail
    msgInfo.roomid = self.RoomID
    
    local transformInfo = msgInfo.transforminfo:add()
    transformInfo.mail = self.Mail
    transformInfo.speed = Speed
    transformInfo.position:append(Position.x)
    transformInfo.position:append(Position.y)
    transformInfo.position:append(Position.z)

    transformInfo.rotation:append(Rotation.x)
    transformInfo.rotation:append(Rotation.y)
    transformInfo.rotation:append(Rotation.z)

    local msg = msgInfo:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, msgInfo.msgid)
end

function NetworkSenderClass:ShootBullet()
    local msgInfo = CS_GS_pb.ShootBullet()
    msgInfo.msgid = CS_GS_pb.CS2GS_ShootBullet
    msgInfo.mail = self.Mail
    msgInfo.roomid = self.RoomID
    msgInfo.weaponid = 0
    
    local msg = msgInfo:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, msgInfo.msgid)
end

function NetworkSenderClass:TakeDamage(TargetType, TargetID)
    if TargetType == EntityType.Active then
        TargetType = CS_GS_pb.Entity_Active
    elseif TargetType == EntityType.Static then
        TargetType = CS_GS_pb.Entity_Static
    end

    local msgInfo = CS_GS_pb.TakeDamage()
    msgInfo.msgid = CS_GS_pb.CS2GS_TakeDamage
    msgInfo.mail = self.Mail
    msgInfo.roomid = self.RoomID
    msgInfo.weaponid = 0
    msgInfo.bulletid = 0
    msgInfo.shooter.entitytype = CS_GS_pb.Entity_Active
    msgInfo.shooter.entityid = self.Mail
    msgInfo.target.entitytype = TargetType
    msgInfo.target.entityid = TargetID
    
    local msg = msgInfo:SerializeToString()
    NetworkManager.Instance:SendMsg(msg, msgInfo.msgid)
end