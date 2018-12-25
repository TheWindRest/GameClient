require("class")
local json = require "cjson"

ConfigName = {
    WindowDefine =          "WindowDefine",
}

ConfigTable = {}

local Class_Config = class()
Config = Class_Config.new()

function Class_Config:ctor()
    -- body
end

function Class_Config:Init()
    for key, value in pairs(ConfigName) do
        local asset = ResourceManager.Instance:LoadTextAsset("Config", value)
        if asset then
            local text = json.decode(asset.text)        
            ConfigTable[value] = text
            print("配置表<"..value..">初始化完成")
        end
    end
    print("--已加载所有配置文件--")
end
