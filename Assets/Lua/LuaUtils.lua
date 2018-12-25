require("class")
require("Define")

local ClassLuaUtils = class()
LuaUtils = ClassLuaUtils.new()

function ClassLuaUtils:SetLabel(Object, Content)
    local text = Object:GetComponent(typeof(Text))
    if text then
        text.text = Content
    else
        Debug.LogError("组件Text不存在")
    end
end

function ClassLuaUtils:IsNil(Object) --Nil == true
    if Object == nil then return true end

    return Object:Equals(nil)
end