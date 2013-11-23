[Setup]
AppName=Prager Book Inventory
AppID=Prager Inventory Program
AppVerName=Prager Book Inventory
VersionInfoVersion=12.9.3
;InfoAFterFile=f:\Upload\Prager\infoAfterInstall.rtf
;InfoBeforeFile=d:\Prager Software\InnoSetup\CrashInfo.rtf
InfoBeforeFile=d:\Upload\Prager\InnoSetup files\infoBeforeInstall.rtf
AppPublisher=Prager, Software
AppPublisherURL=http://www.PragerSoftware.com
DefaultGroupName=Prager
;DisableDirPage=yes
AlwaysShowComponentsList=yes
AllowNoIcons=yes
LicenseFile=D:\Upload\Prager\Prager License Agreement.rtf
Compression=lzma
SolidCompression=true
AppMutex=PragerInventoryMutex
DefaultDirName={pf32}\Prager\Inv
OutputDir=D:\Upload\Prager
OutputBaseFilename=PragerInventoryBETA-12.9.3

[Dirs]
;Name: "{app}\Prager"; Permissions: everyone-modify; MinVersion: 0,5.0

[InstallDelete]
Name: {userdesktop}\Prager Media Inventory.lnk; Type: files

[Icons]

Name: {userdesktop}\Prager Book Manager - BETA; Filename: {pf32}\Prager\Inv\PragerInventoryBETA.exe;

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.exe; DestDir: {pf32}\Prager\Inv; DestName: PragerInventoryBETA.exe; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.pdb; DestDir: {pf32}\Prager\Inv; DestName: PragerInventoryBETA.pdb; Flags: ignoreversion
;Source: D:\Prager Software\Book Inventory Manager\bin\Release\PricingRoutines.dll; DestDir: {pf32}\Prager\Inv; DestName: PricingRoutines.dll; Flags: ignoreversion
;Source: D:\Prager Software\Book Inventory Manager\bin\Release\PricingRoutines.pdb; DestDir: {pf32}\Prager\Inv; DestName: PricingRoutines.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\GetBookInfo.dll; DestDir: {pf32}\Prager\Inv; DestName: GetBookInfo.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\GetBookInfo.pdb; DestDir: {pf32}\Prager\Inv; DestName: GetBookInfo.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.exe.config; DestDir: {pf32}\Prager\Inv; DestName: PragerInventory.exe.config; Flags: ignoreversion
Source: D:\C# Applications\edtFTPnet\edtFTPnet.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion
Source: D:\Upload\Prager\MS Support Components\AlexPilotti.FTPS.Client.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion

Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.exe.config; DestDir: {pf32}\Prager\Inv; DestName: PragerInventory.exe.config; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.dll; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebService.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.pdb; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebService.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.dll; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebServiceProducts.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.pdb; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebServiceProducts.pdb; Flags: ignoreversion
Source: D:\Upload\Prager\TestUploadFiles\*; DestDir: {sd}\Prager\Export

;  WinSCP files
Source: D:\Prager Software\WinSCP\WinSCP.exe; DestDir: {pf32}\Prager\Inv; DestName: WinSCP.exe; Flags: ignoreversion
Source: D:\Prager Software\WinSCP\WinSCP.dll; DestDir: {pf32}\Prager\Inv; DestName: WinSCP.dll; Flags: ignoreversion 
Source: D:\Prager Software\WinSCP\WinSCPnet.dll; DestDir: {pf32}\Prager\Inv; DestName: WinSCPnet.dll; Flags: ignoreversion 

;  updated Firebird API .dll
Source: D:\Upload\Prager\Firebird\FirebirdSql.Data.FirebirdClient.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion

;  MessageBoxChk supporting code
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\MsgBoxCheck.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\CbtHook.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\WindowsHook.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist

;  line below is used in code section below
Source: D:\Upload\Prager\isxdl.dll; Flags: dontcopy
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Run]


[_ISTool]
EnableISX=true

[Code]
//--------------    external code files    -----------------------------------
//#include "D:\Prager Software\InnoSetup\dotNetCode.txt";
#include "D:\Prager Software\InnoSetup\winSCPCode.txt"
//#include "D:\Prager Software\InnoSetup\firebirdCode.txt"


 //----------------------    Check for previous version code    ------------------------
 function IsPrereqInstalled(): Boolean;
 var fname: String;
 
 begin
  fname := ExpandConstant('{pf32}\Prager\Inv\PragerInventory.exe');
  Result := true;
  if not FileExists(fname) then
      begin
     //   MsgBox('Inv Pgm does NOT exist: ' + fname, mbInformation, MB_OK);
        MsgBox('Initially, you MUST install using the FULL link',mbInformation, MB_OK);
        Result := false;  //  don't process if it already exists
      end;
end;

function InitializeSetup() : boolean;
begin
  result := IsPrereqInstalled();

  Result := true;
//dotNetNeeded := false;

// Check for required netfx installation
 if (not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v4')) then begin
        MsgBox('This program requires Microsoft .NET Framework 4.0 Full Setup.'#13#13
        'Please use Windows Update to install this version,'#13
        'and then re-run the Book Inventory Manager setup program.', mbInformation, MB_OK);
        result := false;
end; 
end;

function IsDotNetInstalled() : boolean;
begin;
Result := true;
//dotNetNeeded := false;

//----------------------- Check for required .NET 4.0 installation  ------------------------
  if (not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v4')) then begin
        MsgBox('This program requires Microsoft .NET Framework 4.0 Full Setup.'#13#13
        'Please use Windows Update to install this version,'#13
        'and then re-run the Book Inventory Manager setup program.', mbInformation, MB_OK);
        result := false;
  end; 
end; 

 //-------------    Open URL in web browser after uninstall    -------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
ErrorCode: Integer;
begin
if (CurUninstallStep = usPostUninstall) then
  ShellExec('open', 'http://www.pragersoftware.com/feedback.html', '', '', SW_SHOW, ewNoWait, ErrorCode)
end;

//----------------------    Firebird code    ------------------------
function IsFirebirdInstalled():Boolean;
begin
  Result := true;   //  return true to install it anyway (it's an update

//  if (RegValueExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Firebird Project\Firebird Server\Instances', 'DefaultInstance') AND
//      FileExists(ExpandConstant('{pf32}\Firebird\bin\fbserver.exe'))) then
//      begin
//    MsgBox('firebird key exists', mbInformation, MB_OK);
//      Result := false;  //  don't process if it already exists
//  end;

//    begin
  //if Is64BitInstallMode then
    //MsgBox('Installing in 64-bit mode', mbInformation, MB_OK)
//  else
  //  MsgBox('Installing in 32-bit mode', mbInformation, MB_OK);
//end;

 end;
