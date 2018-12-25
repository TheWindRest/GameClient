--Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
module('GC_GS_pb')

MSGID = protobuf.EnumDescriptor();
MSGID_GC2GS_TOKENLOGIN_ENUM = protobuf.EnumValueDescriptor();
MSGID_GS2GC_ERROR_ENUM = protobuf.EnumValueDescriptor();
TOKENLOGIN = protobuf.Descriptor();
TOKENLOGIN_MSGID_FIELD = protobuf.FieldDescriptor();
TOKENLOGIN_MAIL_FIELD = protobuf.FieldDescriptor();
TOKENLOGIN_PASSWORD_FIELD = protobuf.FieldDescriptor();
TOKENLOGIN_TOKEN_FIELD = protobuf.FieldDescriptor();
ERRORMSG = protobuf.Descriptor();
ERRORMSG_MSGID_FIELD = protobuf.FieldDescriptor();
ERRORMSG_ERRORID_FIELD = protobuf.FieldDescriptor();

MSGID_GC2GS_TOKENLOGIN_ENUM.name = "GC2GS_TokenLogin"
MSGID_GC2GS_TOKENLOGIN_ENUM.index = 0
MSGID_GC2GS_TOKENLOGIN_ENUM.number = 201
MSGID_GS2GC_ERROR_ENUM.name = "GS2GC_Error"
MSGID_GS2GC_ERROR_ENUM.index = 1
MSGID_GS2GC_ERROR_ENUM.number = 202
MSGID.name = "MsgID"
MSGID.full_name = ".GC_GS.MsgID"
MSGID.values = {MSGID_GC2GS_TOKENLOGIN_ENUM,MSGID_GS2GC_ERROR_ENUM}
TOKENLOGIN_MSGID_FIELD.name = "msgid"
TOKENLOGIN_MSGID_FIELD.full_name = ".GC_GS.TokenLogin.msgid"
TOKENLOGIN_MSGID_FIELD.number = 1
TOKENLOGIN_MSGID_FIELD.index = 0
TOKENLOGIN_MSGID_FIELD.label = 1
TOKENLOGIN_MSGID_FIELD.has_default_value = true
TOKENLOGIN_MSGID_FIELD.default_value = GC2GS_TokenLogin
TOKENLOGIN_MSGID_FIELD.enum_type = MSGID
TOKENLOGIN_MSGID_FIELD.type = 14
TOKENLOGIN_MSGID_FIELD.cpp_type = 8

TOKENLOGIN_MAIL_FIELD.name = "mail"
TOKENLOGIN_MAIL_FIELD.full_name = ".GC_GS.TokenLogin.mail"
TOKENLOGIN_MAIL_FIELD.number = 2
TOKENLOGIN_MAIL_FIELD.index = 1
TOKENLOGIN_MAIL_FIELD.label = 1
TOKENLOGIN_MAIL_FIELD.has_default_value = false
TOKENLOGIN_MAIL_FIELD.default_value = ""
TOKENLOGIN_MAIL_FIELD.type = 9
TOKENLOGIN_MAIL_FIELD.cpp_type = 9

TOKENLOGIN_PASSWORD_FIELD.name = "password"
TOKENLOGIN_PASSWORD_FIELD.full_name = ".GC_GS.TokenLogin.password"
TOKENLOGIN_PASSWORD_FIELD.number = 3
TOKENLOGIN_PASSWORD_FIELD.index = 2
TOKENLOGIN_PASSWORD_FIELD.label = 1
TOKENLOGIN_PASSWORD_FIELD.has_default_value = false
TOKENLOGIN_PASSWORD_FIELD.default_value = ""
TOKENLOGIN_PASSWORD_FIELD.type = 9
TOKENLOGIN_PASSWORD_FIELD.cpp_type = 9

TOKENLOGIN_TOKEN_FIELD.name = "token"
TOKENLOGIN_TOKEN_FIELD.full_name = ".GC_GS.TokenLogin.token"
TOKENLOGIN_TOKEN_FIELD.number = 4
TOKENLOGIN_TOKEN_FIELD.index = 3
TOKENLOGIN_TOKEN_FIELD.label = 1
TOKENLOGIN_TOKEN_FIELD.has_default_value = false
TOKENLOGIN_TOKEN_FIELD.default_value = ""
TOKENLOGIN_TOKEN_FIELD.type = 9
TOKENLOGIN_TOKEN_FIELD.cpp_type = 9

TOKENLOGIN.name = "TokenLogin"
TOKENLOGIN.full_name = ".GC_GS.TokenLogin"
TOKENLOGIN.nested_types = {}
TOKENLOGIN.enum_types = {}
TOKENLOGIN.fields = {TOKENLOGIN_MSGID_FIELD, TOKENLOGIN_MAIL_FIELD, TOKENLOGIN_PASSWORD_FIELD, TOKENLOGIN_TOKEN_FIELD}
TOKENLOGIN.is_extendable = false
TOKENLOGIN.extensions = {}
ERRORMSG_MSGID_FIELD.name = "msgid"
ERRORMSG_MSGID_FIELD.full_name = ".GC_GS.ErrorMsg.msgid"
ERRORMSG_MSGID_FIELD.number = 1
ERRORMSG_MSGID_FIELD.index = 0
ERRORMSG_MSGID_FIELD.label = 1
ERRORMSG_MSGID_FIELD.has_default_value = true
ERRORMSG_MSGID_FIELD.default_value = GS2GC_Error
ERRORMSG_MSGID_FIELD.enum_type = MSGID
ERRORMSG_MSGID_FIELD.type = 14
ERRORMSG_MSGID_FIELD.cpp_type = 8

ERRORMSG_ERRORID_FIELD.name = "errorid"
ERRORMSG_ERRORID_FIELD.full_name = ".GC_GS.ErrorMsg.errorid"
ERRORMSG_ERRORID_FIELD.number = 2
ERRORMSG_ERRORID_FIELD.index = 1
ERRORMSG_ERRORID_FIELD.label = 1
ERRORMSG_ERRORID_FIELD.has_default_value = false
ERRORMSG_ERRORID_FIELD.default_value = 0
ERRORMSG_ERRORID_FIELD.type = 5
ERRORMSG_ERRORID_FIELD.cpp_type = 1

ERRORMSG.name = "ErrorMsg"
ERRORMSG.full_name = ".GC_GS.ErrorMsg"
ERRORMSG.nested_types = {}
ERRORMSG.enum_types = {}
ERRORMSG.fields = {ERRORMSG_MSGID_FIELD, ERRORMSG_ERRORID_FIELD}
ERRORMSG.is_extendable = false
ERRORMSG.extensions = {}

ErrorMsg = protobuf.Message(ERRORMSG)
GC2GS_TokenLogin = 201
GS2GC_Error = 202
TokenLogin = protobuf.Message(TOKENLOGIN)

