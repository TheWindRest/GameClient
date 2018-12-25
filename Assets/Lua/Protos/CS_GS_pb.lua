--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
module('CS_GS_pb')

MSGID = protobuf.EnumDescriptor();
MSGID_CS2GS_ASKREGISTER_ENUM = protobuf.EnumValueDescriptor();
MSGID_GS2CS_ERROR_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_USERINFO_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_STARTMATCH_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_ENTERROOM_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_TRANSFORMSYNC_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_STATESYNC_ENUM = protobuf.EnumValueDescriptor();
MSGID_CS2GS_SHOOTBULLET_ENUM = protobuf.EnumValueDescriptor();
ASKREGISTER = protobuf.Descriptor();
ASKREGISTER_MSGID_FIELD = protobuf.FieldDescriptor();
ASKREGISTER_STATE_FIELD = protobuf.FieldDescriptor();
ASKREGISTER_MSGLIST_FIELD = protobuf.FieldDescriptor();
ERRORMSG = protobuf.Descriptor();
ERRORMSG_MSGID_FIELD = protobuf.FieldDescriptor();
ERRORMSG_ERRORID_FIELD = protobuf.FieldDescriptor();
TRANSMITMSG = protobuf.Descriptor();
TRANSMITMSG_MAIL_FIELD = protobuf.FieldDescriptor();
TRANSMITMSG_MSGID_FIELD = protobuf.FieldDescriptor();
TRANSMITMSG_DATA_FIELD = protobuf.FieldDescriptor();
USERINFO = protobuf.Descriptor();
USERINFO_MSGID_FIELD = protobuf.FieldDescriptor();
USERINFO_NAME_FIELD = protobuf.FieldDescriptor();
STARTMATCH = protobuf.Descriptor();
STARTMATCH_MSGID_FIELD = protobuf.FieldDescriptor();
STARTMATCH_MAIL_FIELD = protobuf.FieldDescriptor();
STARTMATCH_RESULT_FIELD = protobuf.FieldDescriptor();
ENTERROOM = protobuf.Descriptor();
ENTERROOM_MSGID_FIELD = protobuf.FieldDescriptor();
ENTERROOM_MAIL_FIELD = protobuf.FieldDescriptor();
ENTERROOM_NAME_FIELD = protobuf.FieldDescriptor();
ENTERROOM_ROOMID_FIELD = protobuf.FieldDescriptor();
TRANSFORMINFO = protobuf.Descriptor();
TRANSFORMINFO_MAIL_FIELD = protobuf.FieldDescriptor();
TRANSFORMINFO_SPEED_FIELD = protobuf.FieldDescriptor();
TRANSFORMINFO_POSITION_FIELD = protobuf.FieldDescriptor();
TRANSFORMINFO_ROTATION_FIELD = protobuf.FieldDescriptor();
TRANSFORMSYNC = protobuf.Descriptor();
TRANSFORMSYNC_MSGID_FIELD = protobuf.FieldDescriptor();
TRANSFORMSYNC_MAIL_FIELD = protobuf.FieldDescriptor();
TRANSFORMSYNC_ROOMID_FIELD = protobuf.FieldDescriptor();
TRANSFORMSYNC_TRANSFORMINFO_FIELD = protobuf.FieldDescriptor();
STATESYNC = protobuf.Descriptor();
STATESYNC_MSGID_FIELD = protobuf.FieldDescriptor();
STATESYNC_MAIL_FIELD = protobuf.FieldDescriptor();
STATESYNC_ROOMID_FIELD = protobuf.FieldDescriptor();
STATESYNC_HEALTH_FIELD = protobuf.FieldDescriptor();
SHOOTBULLET = protobuf.Descriptor();
SHOOTBULLET_MSGID_FIELD = protobuf.FieldDescriptor();
SHOOTBULLET_MAIL_FIELD = protobuf.FieldDescriptor();
SHOOTBULLET_ROOMID_FIELD = protobuf.FieldDescriptor();
SHOOTBULLET_WEAPONID_FIELD = protobuf.FieldDescriptor();

MSGID_CS2GS_ASKREGISTER_ENUM.name = "CS2GS_AskRegister"
MSGID_CS2GS_ASKREGISTER_ENUM.index = 0
MSGID_CS2GS_ASKREGISTER_ENUM.number = 2000
MSGID_GS2CS_ERROR_ENUM.name = "GS2CS_Error"
MSGID_GS2CS_ERROR_ENUM.index = 1
MSGID_GS2CS_ERROR_ENUM.number = 2001
MSGID_CS2GS_USERINFO_ENUM.name = "CS2GS_UserInfo"
MSGID_CS2GS_USERINFO_ENUM.index = 2
MSGID_CS2GS_USERINFO_ENUM.number = 2002
MSGID_CS2GS_STARTMATCH_ENUM.name = "CS2GS_StartMatch"
MSGID_CS2GS_STARTMATCH_ENUM.index = 3
MSGID_CS2GS_STARTMATCH_ENUM.number = 2003
MSGID_CS2GS_ENTERROOM_ENUM.name = "CS2GS_EnterRoom"
MSGID_CS2GS_ENTERROOM_ENUM.index = 4
MSGID_CS2GS_ENTERROOM_ENUM.number = 2004
MSGID_CS2GS_TRANSFORMSYNC_ENUM.name = "CS2GS_TransformSync"
MSGID_CS2GS_TRANSFORMSYNC_ENUM.index = 5
MSGID_CS2GS_TRANSFORMSYNC_ENUM.number = 2005
MSGID_CS2GS_STATESYNC_ENUM.name = "CS2GS_StateSync"
MSGID_CS2GS_STATESYNC_ENUM.index = 6
MSGID_CS2GS_STATESYNC_ENUM.number = 2006
MSGID_CS2GS_SHOOTBULLET_ENUM.name = "CS2GS_ShootBullet"
MSGID_CS2GS_SHOOTBULLET_ENUM.index = 7
MSGID_CS2GS_SHOOTBULLET_ENUM.number = 2007
MSGID.name = "MsgID"
MSGID.full_name = ".CS_GS.MsgID"
MSGID.values = {MSGID_CS2GS_ASKREGISTER_ENUM,MSGID_GS2CS_ERROR_ENUM,MSGID_CS2GS_USERINFO_ENUM,MSGID_CS2GS_STARTMATCH_ENUM,MSGID_CS2GS_ENTERROOM_ENUM,MSGID_CS2GS_TRANSFORMSYNC_ENUM,MSGID_CS2GS_STATESYNC_ENUM,MSGID_CS2GS_SHOOTBULLET_ENUM}
ASKREGISTER_MSGID_FIELD.name = "msgid"
ASKREGISTER_MSGID_FIELD.full_name = ".CS_GS.AskRegister.msgid"
ASKREGISTER_MSGID_FIELD.number = 1
ASKREGISTER_MSGID_FIELD.index = 0
ASKREGISTER_MSGID_FIELD.label = 1
ASKREGISTER_MSGID_FIELD.has_default_value = true
ASKREGISTER_MSGID_FIELD.default_value = CS2GS_AskRegister
ASKREGISTER_MSGID_FIELD.enum_type = MSGID
ASKREGISTER_MSGID_FIELD.type = 14
ASKREGISTER_MSGID_FIELD.cpp_type = 8

ASKREGISTER_STATE_FIELD.name = "state"
ASKREGISTER_STATE_FIELD.full_name = ".CS_GS.AskRegister.state"
ASKREGISTER_STATE_FIELD.number = 2
ASKREGISTER_STATE_FIELD.index = 1
ASKREGISTER_STATE_FIELD.label = 1
ASKREGISTER_STATE_FIELD.has_default_value = false
ASKREGISTER_STATE_FIELD.default_value = 0
ASKREGISTER_STATE_FIELD.type = 5
ASKREGISTER_STATE_FIELD.cpp_type = 1

ASKREGISTER_MSGLIST_FIELD.name = "msgList"
ASKREGISTER_MSGLIST_FIELD.full_name = ".CS_GS.AskRegister.msgList"
ASKREGISTER_MSGLIST_FIELD.number = 3
ASKREGISTER_MSGLIST_FIELD.index = 2
ASKREGISTER_MSGLIST_FIELD.label = 3
ASKREGISTER_MSGLIST_FIELD.has_default_value = false
ASKREGISTER_MSGLIST_FIELD.default_value = {}
ASKREGISTER_MSGLIST_FIELD.enum_type = MSGID
ASKREGISTER_MSGLIST_FIELD.type = 14
ASKREGISTER_MSGLIST_FIELD.cpp_type = 8

ASKREGISTER.name = "AskRegister"
ASKREGISTER.full_name = ".CS_GS.AskRegister"
ASKREGISTER.nested_types = {}
ASKREGISTER.enum_types = {}
ASKREGISTER.fields = {ASKREGISTER_MSGID_FIELD, ASKREGISTER_STATE_FIELD, ASKREGISTER_MSGLIST_FIELD}
ASKREGISTER.is_extendable = false
ASKREGISTER.extensions = {}
ERRORMSG_MSGID_FIELD.name = "msgid"
ERRORMSG_MSGID_FIELD.full_name = ".CS_GS.ErrorMsg.msgid"
ERRORMSG_MSGID_FIELD.number = 1
ERRORMSG_MSGID_FIELD.index = 0
ERRORMSG_MSGID_FIELD.label = 1
ERRORMSG_MSGID_FIELD.has_default_value = true
ERRORMSG_MSGID_FIELD.default_value = GS2CS_Error
ERRORMSG_MSGID_FIELD.enum_type = MSGID
ERRORMSG_MSGID_FIELD.type = 14
ERRORMSG_MSGID_FIELD.cpp_type = 8

ERRORMSG_ERRORID_FIELD.name = "errorid"
ERRORMSG_ERRORID_FIELD.full_name = ".CS_GS.ErrorMsg.errorid"
ERRORMSG_ERRORID_FIELD.number = 2
ERRORMSG_ERRORID_FIELD.index = 1
ERRORMSG_ERRORID_FIELD.label = 1
ERRORMSG_ERRORID_FIELD.has_default_value = false
ERRORMSG_ERRORID_FIELD.default_value = 0
ERRORMSG_ERRORID_FIELD.type = 5
ERRORMSG_ERRORID_FIELD.cpp_type = 1

ERRORMSG.name = "ErrorMsg"
ERRORMSG.full_name = ".CS_GS.ErrorMsg"
ERRORMSG.nested_types = {}
ERRORMSG.enum_types = {}
ERRORMSG.fields = {ERRORMSG_MSGID_FIELD, ERRORMSG_ERRORID_FIELD}
ERRORMSG.is_extendable = false
ERRORMSG.extensions = {}
TRANSMITMSG_MAIL_FIELD.name = "mail"
TRANSMITMSG_MAIL_FIELD.full_name = ".CS_GS.TransmitMsg.mail"
TRANSMITMSG_MAIL_FIELD.number = 1
TRANSMITMSG_MAIL_FIELD.index = 0
TRANSMITMSG_MAIL_FIELD.label = 1
TRANSMITMSG_MAIL_FIELD.has_default_value = false
TRANSMITMSG_MAIL_FIELD.default_value = ""
TRANSMITMSG_MAIL_FIELD.type = 9
TRANSMITMSG_MAIL_FIELD.cpp_type = 9

TRANSMITMSG_MSGID_FIELD.name = "msgid"
TRANSMITMSG_MSGID_FIELD.full_name = ".CS_GS.TransmitMsg.msgid"
TRANSMITMSG_MSGID_FIELD.number = 2
TRANSMITMSG_MSGID_FIELD.index = 1
TRANSMITMSG_MSGID_FIELD.label = 1
TRANSMITMSG_MSGID_FIELD.has_default_value = false
TRANSMITMSG_MSGID_FIELD.default_value = nil
TRANSMITMSG_MSGID_FIELD.enum_type = MSGID
TRANSMITMSG_MSGID_FIELD.type = 14
TRANSMITMSG_MSGID_FIELD.cpp_type = 8

TRANSMITMSG_DATA_FIELD.name = "data"
TRANSMITMSG_DATA_FIELD.full_name = ".CS_GS.TransmitMsg.data"
TRANSMITMSG_DATA_FIELD.number = 3
TRANSMITMSG_DATA_FIELD.index = 2
TRANSMITMSG_DATA_FIELD.label = 1
TRANSMITMSG_DATA_FIELD.has_default_value = false
TRANSMITMSG_DATA_FIELD.default_value = ""
TRANSMITMSG_DATA_FIELD.type = 12
TRANSMITMSG_DATA_FIELD.cpp_type = 9

TRANSMITMSG.name = "TransmitMsg"
TRANSMITMSG.full_name = ".CS_GS.TransmitMsg"
TRANSMITMSG.nested_types = {}
TRANSMITMSG.enum_types = {}
TRANSMITMSG.fields = {TRANSMITMSG_MAIL_FIELD, TRANSMITMSG_MSGID_FIELD, TRANSMITMSG_DATA_FIELD}
TRANSMITMSG.is_extendable = false
TRANSMITMSG.extensions = {}
USERINFO_MSGID_FIELD.name = "msgid"
USERINFO_MSGID_FIELD.full_name = ".CS_GS.UserInfo.msgid"
USERINFO_MSGID_FIELD.number = 1
USERINFO_MSGID_FIELD.index = 0
USERINFO_MSGID_FIELD.label = 1
USERINFO_MSGID_FIELD.has_default_value = true
USERINFO_MSGID_FIELD.default_value = CS2GS_UserInfo
USERINFO_MSGID_FIELD.enum_type = MSGID
USERINFO_MSGID_FIELD.type = 14
USERINFO_MSGID_FIELD.cpp_type = 8

USERINFO_NAME_FIELD.name = "name"
USERINFO_NAME_FIELD.full_name = ".CS_GS.UserInfo.name"
USERINFO_NAME_FIELD.number = 2
USERINFO_NAME_FIELD.index = 1
USERINFO_NAME_FIELD.label = 1
USERINFO_NAME_FIELD.has_default_value = false
USERINFO_NAME_FIELD.default_value = ""
USERINFO_NAME_FIELD.type = 9
USERINFO_NAME_FIELD.cpp_type = 9

USERINFO.name = "UserInfo"
USERINFO.full_name = ".CS_GS.UserInfo"
USERINFO.nested_types = {}
USERINFO.enum_types = {}
USERINFO.fields = {USERINFO_MSGID_FIELD, USERINFO_NAME_FIELD}
USERINFO.is_extendable = false
USERINFO.extensions = {}
STARTMATCH_MSGID_FIELD.name = "msgid"
STARTMATCH_MSGID_FIELD.full_name = ".CS_GS.StartMatch.msgid"
STARTMATCH_MSGID_FIELD.number = 1
STARTMATCH_MSGID_FIELD.index = 0
STARTMATCH_MSGID_FIELD.label = 1
STARTMATCH_MSGID_FIELD.has_default_value = true
STARTMATCH_MSGID_FIELD.default_value = CS2GS_StartMatch
STARTMATCH_MSGID_FIELD.enum_type = MSGID
STARTMATCH_MSGID_FIELD.type = 14
STARTMATCH_MSGID_FIELD.cpp_type = 8

STARTMATCH_MAIL_FIELD.name = "mail"
STARTMATCH_MAIL_FIELD.full_name = ".CS_GS.StartMatch.mail"
STARTMATCH_MAIL_FIELD.number = 2
STARTMATCH_MAIL_FIELD.index = 1
STARTMATCH_MAIL_FIELD.label = 1
STARTMATCH_MAIL_FIELD.has_default_value = false
STARTMATCH_MAIL_FIELD.default_value = ""
STARTMATCH_MAIL_FIELD.type = 9
STARTMATCH_MAIL_FIELD.cpp_type = 9

STARTMATCH_RESULT_FIELD.name = "result"
STARTMATCH_RESULT_FIELD.full_name = ".CS_GS.StartMatch.result"
STARTMATCH_RESULT_FIELD.number = 3
STARTMATCH_RESULT_FIELD.index = 2
STARTMATCH_RESULT_FIELD.label = 1
STARTMATCH_RESULT_FIELD.has_default_value = false
STARTMATCH_RESULT_FIELD.default_value = 0
STARTMATCH_RESULT_FIELD.type = 5
STARTMATCH_RESULT_FIELD.cpp_type = 1

STARTMATCH.name = "StartMatch"
STARTMATCH.full_name = ".CS_GS.StartMatch"
STARTMATCH.nested_types = {}
STARTMATCH.enum_types = {}
STARTMATCH.fields = {STARTMATCH_MSGID_FIELD, STARTMATCH_MAIL_FIELD, STARTMATCH_RESULT_FIELD}
STARTMATCH.is_extendable = false
STARTMATCH.extensions = {}
ENTERROOM_MSGID_FIELD.name = "msgid"
ENTERROOM_MSGID_FIELD.full_name = ".CS_GS.EnterRoom.msgid"
ENTERROOM_MSGID_FIELD.number = 1
ENTERROOM_MSGID_FIELD.index = 0
ENTERROOM_MSGID_FIELD.label = 1
ENTERROOM_MSGID_FIELD.has_default_value = true
ENTERROOM_MSGID_FIELD.default_value = CS2GS_EnterRoom
ENTERROOM_MSGID_FIELD.enum_type = MSGID
ENTERROOM_MSGID_FIELD.type = 14
ENTERROOM_MSGID_FIELD.cpp_type = 8

ENTERROOM_MAIL_FIELD.name = "mail"
ENTERROOM_MAIL_FIELD.full_name = ".CS_GS.EnterRoom.mail"
ENTERROOM_MAIL_FIELD.number = 2
ENTERROOM_MAIL_FIELD.index = 1
ENTERROOM_MAIL_FIELD.label = 1
ENTERROOM_MAIL_FIELD.has_default_value = false
ENTERROOM_MAIL_FIELD.default_value = ""
ENTERROOM_MAIL_FIELD.type = 9
ENTERROOM_MAIL_FIELD.cpp_type = 9

ENTERROOM_NAME_FIELD.name = "name"
ENTERROOM_NAME_FIELD.full_name = ".CS_GS.EnterRoom.name"
ENTERROOM_NAME_FIELD.number = 3
ENTERROOM_NAME_FIELD.index = 2
ENTERROOM_NAME_FIELD.label = 1
ENTERROOM_NAME_FIELD.has_default_value = false
ENTERROOM_NAME_FIELD.default_value = ""
ENTERROOM_NAME_FIELD.type = 9
ENTERROOM_NAME_FIELD.cpp_type = 9

ENTERROOM_ROOMID_FIELD.name = "roomid"
ENTERROOM_ROOMID_FIELD.full_name = ".CS_GS.EnterRoom.roomid"
ENTERROOM_ROOMID_FIELD.number = 4
ENTERROOM_ROOMID_FIELD.index = 3
ENTERROOM_ROOMID_FIELD.label = 1
ENTERROOM_ROOMID_FIELD.has_default_value = false
ENTERROOM_ROOMID_FIELD.default_value = ""
ENTERROOM_ROOMID_FIELD.type = 9
ENTERROOM_ROOMID_FIELD.cpp_type = 9

ENTERROOM.name = "EnterRoom"
ENTERROOM.full_name = ".CS_GS.EnterRoom"
ENTERROOM.nested_types = {}
ENTERROOM.enum_types = {}
ENTERROOM.fields = {ENTERROOM_MSGID_FIELD, ENTERROOM_MAIL_FIELD, ENTERROOM_NAME_FIELD, ENTERROOM_ROOMID_FIELD}
ENTERROOM.is_extendable = false
ENTERROOM.extensions = {}
TRANSFORMINFO_MAIL_FIELD.name = "mail"
TRANSFORMINFO_MAIL_FIELD.full_name = ".CS_GS.TransformInfo.mail"
TRANSFORMINFO_MAIL_FIELD.number = 1
TRANSFORMINFO_MAIL_FIELD.index = 0
TRANSFORMINFO_MAIL_FIELD.label = 1
TRANSFORMINFO_MAIL_FIELD.has_default_value = false
TRANSFORMINFO_MAIL_FIELD.default_value = ""
TRANSFORMINFO_MAIL_FIELD.type = 9
TRANSFORMINFO_MAIL_FIELD.cpp_type = 9

TRANSFORMINFO_SPEED_FIELD.name = "speed"
TRANSFORMINFO_SPEED_FIELD.full_name = ".CS_GS.TransformInfo.speed"
TRANSFORMINFO_SPEED_FIELD.number = 2
TRANSFORMINFO_SPEED_FIELD.index = 1
TRANSFORMINFO_SPEED_FIELD.label = 1
TRANSFORMINFO_SPEED_FIELD.has_default_value = false
TRANSFORMINFO_SPEED_FIELD.default_value = 0.0
TRANSFORMINFO_SPEED_FIELD.type = 2
TRANSFORMINFO_SPEED_FIELD.cpp_type = 6

TRANSFORMINFO_POSITION_FIELD.name = "position"
TRANSFORMINFO_POSITION_FIELD.full_name = ".CS_GS.TransformInfo.position"
TRANSFORMINFO_POSITION_FIELD.number = 3
TRANSFORMINFO_POSITION_FIELD.index = 2
TRANSFORMINFO_POSITION_FIELD.label = 3
TRANSFORMINFO_POSITION_FIELD.has_default_value = false
TRANSFORMINFO_POSITION_FIELD.default_value = {}
TRANSFORMINFO_POSITION_FIELD.type = 2
TRANSFORMINFO_POSITION_FIELD.cpp_type = 6

TRANSFORMINFO_ROTATION_FIELD.name = "rotation"
TRANSFORMINFO_ROTATION_FIELD.full_name = ".CS_GS.TransformInfo.rotation"
TRANSFORMINFO_ROTATION_FIELD.number = 4
TRANSFORMINFO_ROTATION_FIELD.index = 3
TRANSFORMINFO_ROTATION_FIELD.label = 3
TRANSFORMINFO_ROTATION_FIELD.has_default_value = false
TRANSFORMINFO_ROTATION_FIELD.default_value = {}
TRANSFORMINFO_ROTATION_FIELD.type = 2
TRANSFORMINFO_ROTATION_FIELD.cpp_type = 6

TRANSFORMINFO.name = "TransformInfo"
TRANSFORMINFO.full_name = ".CS_GS.TransformInfo"
TRANSFORMINFO.nested_types = {}
TRANSFORMINFO.enum_types = {}
TRANSFORMINFO.fields = {TRANSFORMINFO_MAIL_FIELD, TRANSFORMINFO_SPEED_FIELD, TRANSFORMINFO_POSITION_FIELD, TRANSFORMINFO_ROTATION_FIELD}
TRANSFORMINFO.is_extendable = false
TRANSFORMINFO.extensions = {}
TRANSFORMSYNC_MSGID_FIELD.name = "msgid"
TRANSFORMSYNC_MSGID_FIELD.full_name = ".CS_GS.TransformSync.msgid"
TRANSFORMSYNC_MSGID_FIELD.number = 1
TRANSFORMSYNC_MSGID_FIELD.index = 0
TRANSFORMSYNC_MSGID_FIELD.label = 1
TRANSFORMSYNC_MSGID_FIELD.has_default_value = true
TRANSFORMSYNC_MSGID_FIELD.default_value = CS2GS_TransformSync
TRANSFORMSYNC_MSGID_FIELD.enum_type = MSGID
TRANSFORMSYNC_MSGID_FIELD.type = 14
TRANSFORMSYNC_MSGID_FIELD.cpp_type = 8

TRANSFORMSYNC_MAIL_FIELD.name = "mail"
TRANSFORMSYNC_MAIL_FIELD.full_name = ".CS_GS.TransformSync.mail"
TRANSFORMSYNC_MAIL_FIELD.number = 2
TRANSFORMSYNC_MAIL_FIELD.index = 1
TRANSFORMSYNC_MAIL_FIELD.label = 1
TRANSFORMSYNC_MAIL_FIELD.has_default_value = false
TRANSFORMSYNC_MAIL_FIELD.default_value = ""
TRANSFORMSYNC_MAIL_FIELD.type = 9
TRANSFORMSYNC_MAIL_FIELD.cpp_type = 9

TRANSFORMSYNC_ROOMID_FIELD.name = "roomid"
TRANSFORMSYNC_ROOMID_FIELD.full_name = ".CS_GS.TransformSync.roomid"
TRANSFORMSYNC_ROOMID_FIELD.number = 3
TRANSFORMSYNC_ROOMID_FIELD.index = 2
TRANSFORMSYNC_ROOMID_FIELD.label = 1
TRANSFORMSYNC_ROOMID_FIELD.has_default_value = false
TRANSFORMSYNC_ROOMID_FIELD.default_value = ""
TRANSFORMSYNC_ROOMID_FIELD.type = 9
TRANSFORMSYNC_ROOMID_FIELD.cpp_type = 9

TRANSFORMSYNC_TRANSFORMINFO_FIELD.name = "transforminfo"
TRANSFORMSYNC_TRANSFORMINFO_FIELD.full_name = ".CS_GS.TransformSync.transforminfo"
TRANSFORMSYNC_TRANSFORMINFO_FIELD.number = 4
TRANSFORMSYNC_TRANSFORMINFO_FIELD.index = 3
TRANSFORMSYNC_TRANSFORMINFO_FIELD.label = 3
TRANSFORMSYNC_TRANSFORMINFO_FIELD.has_default_value = false
TRANSFORMSYNC_TRANSFORMINFO_FIELD.default_value = {}
TRANSFORMSYNC_TRANSFORMINFO_FIELD.message_type = TRANSFORMINFO
TRANSFORMSYNC_TRANSFORMINFO_FIELD.type = 11
TRANSFORMSYNC_TRANSFORMINFO_FIELD.cpp_type = 10

TRANSFORMSYNC.name = "TransformSync"
TRANSFORMSYNC.full_name = ".CS_GS.TransformSync"
TRANSFORMSYNC.nested_types = {}
TRANSFORMSYNC.enum_types = {}
TRANSFORMSYNC.fields = {TRANSFORMSYNC_MSGID_FIELD, TRANSFORMSYNC_MAIL_FIELD, TRANSFORMSYNC_ROOMID_FIELD, TRANSFORMSYNC_TRANSFORMINFO_FIELD}
TRANSFORMSYNC.is_extendable = false
TRANSFORMSYNC.extensions = {}
STATESYNC_MSGID_FIELD.name = "msgid"
STATESYNC_MSGID_FIELD.full_name = ".CS_GS.StateSync.msgid"
STATESYNC_MSGID_FIELD.number = 1
STATESYNC_MSGID_FIELD.index = 0
STATESYNC_MSGID_FIELD.label = 1
STATESYNC_MSGID_FIELD.has_default_value = true
STATESYNC_MSGID_FIELD.default_value = CS2GS_StateSync
STATESYNC_MSGID_FIELD.enum_type = MSGID
STATESYNC_MSGID_FIELD.type = 14
STATESYNC_MSGID_FIELD.cpp_type = 8

STATESYNC_MAIL_FIELD.name = "mail"
STATESYNC_MAIL_FIELD.full_name = ".CS_GS.StateSync.mail"
STATESYNC_MAIL_FIELD.number = 2
STATESYNC_MAIL_FIELD.index = 1
STATESYNC_MAIL_FIELD.label = 1
STATESYNC_MAIL_FIELD.has_default_value = false
STATESYNC_MAIL_FIELD.default_value = ""
STATESYNC_MAIL_FIELD.type = 9
STATESYNC_MAIL_FIELD.cpp_type = 9

STATESYNC_ROOMID_FIELD.name = "roomid"
STATESYNC_ROOMID_FIELD.full_name = ".CS_GS.StateSync.roomid"
STATESYNC_ROOMID_FIELD.number = 3
STATESYNC_ROOMID_FIELD.index = 2
STATESYNC_ROOMID_FIELD.label = 1
STATESYNC_ROOMID_FIELD.has_default_value = false
STATESYNC_ROOMID_FIELD.default_value = ""
STATESYNC_ROOMID_FIELD.type = 9
STATESYNC_ROOMID_FIELD.cpp_type = 9

STATESYNC_HEALTH_FIELD.name = "health"
STATESYNC_HEALTH_FIELD.full_name = ".CS_GS.StateSync.health"
STATESYNC_HEALTH_FIELD.number = 4
STATESYNC_HEALTH_FIELD.index = 3
STATESYNC_HEALTH_FIELD.label = 1
STATESYNC_HEALTH_FIELD.has_default_value = false
STATESYNC_HEALTH_FIELD.default_value = 0
STATESYNC_HEALTH_FIELD.type = 5
STATESYNC_HEALTH_FIELD.cpp_type = 1

STATESYNC.name = "StateSync"
STATESYNC.full_name = ".CS_GS.StateSync"
STATESYNC.nested_types = {}
STATESYNC.enum_types = {}
STATESYNC.fields = {STATESYNC_MSGID_FIELD, STATESYNC_MAIL_FIELD, STATESYNC_ROOMID_FIELD, STATESYNC_HEALTH_FIELD}
STATESYNC.is_extendable = false
STATESYNC.extensions = {}
SHOOTBULLET_MSGID_FIELD.name = "msgid"
SHOOTBULLET_MSGID_FIELD.full_name = ".CS_GS.ShootBullet.msgid"
SHOOTBULLET_MSGID_FIELD.number = 1
SHOOTBULLET_MSGID_FIELD.index = 0
SHOOTBULLET_MSGID_FIELD.label = 1
SHOOTBULLET_MSGID_FIELD.has_default_value = true
SHOOTBULLET_MSGID_FIELD.default_value = CS2GS_ShootBullet
SHOOTBULLET_MSGID_FIELD.enum_type = MSGID
SHOOTBULLET_MSGID_FIELD.type = 14
SHOOTBULLET_MSGID_FIELD.cpp_type = 8

SHOOTBULLET_MAIL_FIELD.name = "mail"
SHOOTBULLET_MAIL_FIELD.full_name = ".CS_GS.ShootBullet.mail"
SHOOTBULLET_MAIL_FIELD.number = 2
SHOOTBULLET_MAIL_FIELD.index = 1
SHOOTBULLET_MAIL_FIELD.label = 1
SHOOTBULLET_MAIL_FIELD.has_default_value = false
SHOOTBULLET_MAIL_FIELD.default_value = ""
SHOOTBULLET_MAIL_FIELD.type = 9
SHOOTBULLET_MAIL_FIELD.cpp_type = 9

SHOOTBULLET_ROOMID_FIELD.name = "roomid"
SHOOTBULLET_ROOMID_FIELD.full_name = ".CS_GS.ShootBullet.roomid"
SHOOTBULLET_ROOMID_FIELD.number = 3
SHOOTBULLET_ROOMID_FIELD.index = 2
SHOOTBULLET_ROOMID_FIELD.label = 1
SHOOTBULLET_ROOMID_FIELD.has_default_value = false
SHOOTBULLET_ROOMID_FIELD.default_value = ""
SHOOTBULLET_ROOMID_FIELD.type = 9
SHOOTBULLET_ROOMID_FIELD.cpp_type = 9

SHOOTBULLET_WEAPONID_FIELD.name = "weaponid"
SHOOTBULLET_WEAPONID_FIELD.full_name = ".CS_GS.ShootBullet.weaponid"
SHOOTBULLET_WEAPONID_FIELD.number = 4
SHOOTBULLET_WEAPONID_FIELD.index = 3
SHOOTBULLET_WEAPONID_FIELD.label = 1
SHOOTBULLET_WEAPONID_FIELD.has_default_value = false
SHOOTBULLET_WEAPONID_FIELD.default_value = 0
SHOOTBULLET_WEAPONID_FIELD.type = 5
SHOOTBULLET_WEAPONID_FIELD.cpp_type = 1

SHOOTBULLET.name = "ShootBullet"
SHOOTBULLET.full_name = ".CS_GS.ShootBullet"
SHOOTBULLET.nested_types = {}
SHOOTBULLET.enum_types = {}
SHOOTBULLET.fields = {SHOOTBULLET_MSGID_FIELD, SHOOTBULLET_MAIL_FIELD, SHOOTBULLET_ROOMID_FIELD, SHOOTBULLET_WEAPONID_FIELD}
SHOOTBULLET.is_extendable = false
SHOOTBULLET.extensions = {}

AskRegister = protobuf.Message(ASKREGISTER)
CS2GS_AskRegister = 2000
CS2GS_EnterRoom = 2004
CS2GS_ShootBullet = 2007
CS2GS_StartMatch = 2003
CS2GS_StateSync = 2006
CS2GS_TransformSync = 2005
CS2GS_UserInfo = 2002
EnterRoom = protobuf.Message(ENTERROOM)
ErrorMsg = protobuf.Message(ERRORMSG)
GS2CS_Error = 2001
ShootBullet = protobuf.Message(SHOOTBULLET)
StartMatch = protobuf.Message(STARTMATCH)
StateSync = protobuf.Message(STATESYNC)
TransformInfo = protobuf.Message(TRANSFORMINFO)
TransformSync = protobuf.Message(TRANSFORMSYNC)
TransmitMsg = protobuf.Message(TRANSMITMSG)
UserInfo = protobuf.Message(USERINFO)

