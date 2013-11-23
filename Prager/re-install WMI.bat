%SYSTEMDRIVE%
CD %windir%\system32\wbem
Mofcomp.exe cimwin32.mof
Regsvr32 /s wbemupgd.dll
Regsvr32 /s wbemsvc.dll
wmiprvse /regserver 