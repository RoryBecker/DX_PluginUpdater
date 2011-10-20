REM Waste Line
COPY DX_PluginUpdater.dll temp.dll
ILMerge.exe /out:DX_PluginUpdater.dll temp.dll Ionic.Zip.Reduced.dll
DEL temp.dll
pause