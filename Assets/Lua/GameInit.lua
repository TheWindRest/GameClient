require("Define")
require("LuaUtils")
require("Config")
require("EntityManager")
require("MapDrawer")
require("NetworkHandler")
require("NetworkSender")
require("Windows/WindowManager")
Event = require("Tools/events/events")

local function Start()
    print("--Version 1.0--")
    print("--Lua Logic Init--")

    Config:Init()           --配置表管理初始化
    WindowManager:Init()    --窗口管理初始化
    EntityManager:Init()    --实体管理初始化
    MapDrawer:Init()        --地图绘制初始化
    NetworkHandler:Init()   --网络事件处理初始化
    NetworkSender:Init()    --网络消息发送初始化
    NetworkManager.Instance:Init(LoginServerIP, LoginServerPort, ServerType.LoginServer)    --连接网络

    Event.Brocast(EventType.UILogEnter)
    print("进入lua循环")
end

Start()