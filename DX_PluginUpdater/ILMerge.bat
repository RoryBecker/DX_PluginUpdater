ECHO parameter=%1
CD %1
COPY DX_PluginUpdater.dll temp.dll
ILMerge.exe /out:DX_PluginUpdater.dll temp.dll Ionic.Zip.Reduced.dll
DEL temp.dll


