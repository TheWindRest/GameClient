for %%i in (.\*.proto) do (  
    .\Tools\protoc.exe --plugin=protoc-gen-lua=".\Tools\build.bat" --lua_out=.\ %%i
) 