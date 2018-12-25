require("Windows/WindowBase")
require("Protos/GC_LS_pb")
require("LuaUtils")

local Wnd_SelectServerClass = class(WindowBase)

function Wnd_SelectServerClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UISelectServerEnter, self.Show, self)
    Event.AddListener(EventType.UISelectServerExit, self.Hide, self)
end

function Wnd_SelectServerClass:OnNewInstance()
    local scrollView = Utils.FindChild(self.Instance, "ServerList")
    self.ServerGrid = Utils.FindChild(scrollView, "Grid")
    self.ServerPrefab = Utils.FindChild(self.ServerGrid, "Server")
    self.ServerPrefab:SetActive(false)

    local playBtn = Utils.FindChild(self.Instance, "PlayBtn")
    self:Listen(playBtn, EventTriggerType.PointerClick, self.OnSelectServerClick)
end

function Wnd_SelectServerClass:OnShowDone()
    self:ShowServerList()
end

function Wnd_SelectServerClass:ShowServerList()
    for k = 1, self.ServerGrid.transform.childCount do
        local server = Utils.FindChild(self.ServerGrid, "Server"..k)
        if server then
            server:SetActive(false)
        end
    end

    local serverList = NetworkHandler.ServerList
    for k = 1, #serverList do
        serverInfo = serverList[k]
        local server = Utils.FindChild(self.ServerGrid, "Server"..k)
        if server == nil then
            server = GameObject.Instantiate(self.ServerPrefab, self.ServerGrid.transform)
            server.name = "Server"..k
        end

        local text = Utils.FindChild(server, "Label")
        LuaUtils:SetLabel(text, serverInfo.Name)

        server:SetActive(true)
    end
end

function Wnd_SelectServerClass:OnSelectServerClick(Object)
    local serverIndex = nil
    for k = 1, self.ServerGrid.transform.childCount do
        local server = Utils.FindChild(self.ServerGrid, "Server"..k)
        if server then
            toggle = server:GetComponent(typeof(Toggle))
            if toggle.isOn then
                serverIndex = k
                break
            end
        end
    end
    if serverIndex then
        serverInfo = NetworkHandler.ServerList[serverIndex]
        NetworkManager.Instance.canReconnect = false
        NetworkManager.Instance:Close()
        NetworkManager.Instance:Init(serverInfo.Addr, serverInfo.Port, ServerType.GateServer)
    else
        -- TODO:提示未选择任何服务器
        Debug.LogError("为选择任何服务器")
    end
end

function Wnd_SelectServerClass:OnLostInstance()
    Event.RemoveListener(EventType.UISelectServerEnter, self.Show)
    Event.RemoveListener(EventType.UISelectServerExit, self.Hide)
end

return Wnd_SelectServerClass.new