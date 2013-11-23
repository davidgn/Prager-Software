[Setup]
AppName=Prager Media Inventory
AppID=Prager MediaInventory Program
AppVerName=Prager Media Inventory
VersionInfoVersion=1.2.2
;InfoAFterFile=f:\Upload\Prager\infoAfterInstall.rtf
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
DefaultDirName={pf32}\Prager\Med
OutputDir=D:\Upload\Prager
OutputBaseFilename=PragerMediaUpdate-1.2.2

[Dirs]
;Name: "{app}\Prager"; Permissions: everyone-modify; MinVersion: 0,5.0

[InstallDelete]
Name: {userdesktop}\Prager Book Inventory.lnk; Type: files

[Icons]
Name: {userdesktop}\Prager Media Manager-1.2.2; Filename: {pf32}\Prager\Med\PragerMediaInventory.exe;

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: D:\Prager Software\Media Inventory Manager\bin\Release\PragerMediaInventoryManager.exe; DestDir: {pf32}\Prager\Med; DestName: PragerMediaInventory.exe; Flags: ignoreversion
Source: D:\Prager Software\Media Inventory Manager\bin\Release\PragerMediaInventoryManager.pdb; DestDir: {pf32}\Prager\Med; DestName: PragerMediaInventoryManager.pdb; Flags: ignoreversion
Source: D:\Prager Software\Media Inventory Manager\bin\Release\PragerMediaInventoryManager.exe.config; DestDir: {pf32}\Prager\Med; DestName: PragerMediaInventory.exe.config; Flags: ignoreversion
Source: C:\ProgramData\Prager\prager.Media.AZimporttabSettings.xml; DestDir: c:\ProgramData; DestName: prager.Media.AZimporttabSettings.xml; 
Source: D:\C# Applications\edtFTPnet\edtFTPnet.dll; DestDir: {pf32}\Prager\Med; Flags: ignoreversion 

;  updated firebird dll
Source: D:\Download\Firebird\FirebirdSql.Data.FirebirdClient.dll; DestDir: {pf32}\Prager\Med; Flags: ignoreversion

;  miscellaneous support files
Source: D:\C# Applications\Amazon Marketplace Web Services\src\MarketplaceWebService\bin\Release\MarketplaceWebService.dll; DestDir: {pf32}\Prager\Med;

;  WinSCP installation file
Source: D:\Prager Software\WinSCP\winscp427setup.exe; DestDir: {tmp}; 

;  line below is used in code section below
Source: D:\Upload\Prager\isxdl.dll; Flags: dontcopy
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Run]
;Filename: "{sys}\net.exe"; Parameters: "stop FirebirdGuardianDefaultInstance"; Flags: runascurrentuser shellexec waituntilterminated; StatusMsg: "Stopping Firebird service..."
;Filename: "{pf32}\Firebird\unins000.exe"; Parameters: "/SILENT"; Check: IsFirebirdInstalled; Flags: runascurrentuser waituntilterminated; StatusMsg: "Uninstalling Firebird database engine...";
;Filename: {tmp}\Firebird-2.1.2.18118_0_Win32.exe; Check: IsFirebirdInstalled; Parameters: "/SP- /SILENT /LOG /NOCANCEL /LANG=""en"" /DIR=""{pf32}\Firebird"" /GROUP=""Firebird"" /NOICONS /NOCPL /COMPONENTS=""ServerComponent,ServerComponent\SuperServerComponent,DevAdminComponent,ClientComponent"""; StatusMsg: Installing database engine...; Flags: waituntilterminated
;Filename: {tmp}\Firebird-2.1.4.18393_0_Win32.exe; Check: IsFirebirdInstalled; Parameters: "/SP- /SILENT /LOG /NOCANCEL /LANG=""en"" /DIR=""{pf32}\Firebird"" /GROUP=""Firebird"" /NOICONS /NOCPL /COMPONENTS=""ServerComponent,ServerComponent\SuperServerComponent,DevAdminComponent,ClientComponent"""; StatusMsG: Installing database engine...; Flags: waituntilterminated
;Filename: "{pf32}\Firebird\bin\gsec.exe"; Parameters: "-add prager -pw books"; Check: IsFirebirdInstalled; Flags: runascurrentuser shellexec waituntilterminated; StatusMsg: "Adding user..."
;Filename: {tmp}\winscp427setup.exe; Check: IsWinSCPInstalled; Parameters: /SILENT /NOCANDY

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
  fname := ExpandConstant('{pf32}\Prager\Med\PragerMediaInventory.exe');
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
 end;
