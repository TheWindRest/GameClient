require("Windows/WindowBase")

local Wnd_LoginClass = class(WindowBase)

function Wnd_LoginClass:Start(WindowIndex)
    self.WindowIndex = WindowIndex
    Event.AddListener(EventType.UILoginEnter, self.Show, self)
    Event.AddListener(EventType.UILoginExit, self.Hide, self)
end

function Wnd_LoginClass:OnNewInstance()
    self.NameInput = Utils.FindChild(self.Instance, "Name"):GetComponent(typeof(InputField))
    self.PasswordInput = Utils.FindChild(self.Instance, "Password"):GetComponent(typeof(InputField))
    self.LoginBtn = Utils.FindChild(self.Instance, "Login")
    self:Listen(self.LoginBtn, EventTriggerType.PointerClick, self.OnLoginClick)
end

function Wnd_LoginClass:OnShowDone()

end

function Wnd_LoginClass:OnLoginClick(Object)
    local mail = self.NameInput.text
    local password = self.PasswordInput.text
    NetworkSender:AskLogin(mail, password, 0)
end

function Wnd_LoginClass:OnLostInstance()
    Event.RemoveListener(EventType.UILoginEnter, self.Show)
    Event.RemoveListener(EventType.UILoginExit, self.Hide)
end

return Wnd_LoginClass.new