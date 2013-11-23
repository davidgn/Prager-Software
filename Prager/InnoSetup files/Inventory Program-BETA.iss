[Setup]
AppName=Prager Book Inventory

;  don't forget to change version number -->
AppVerName=Prager Book Inventory
VersionInfoVersion=9.4.5
;InfoBeforeFile=d:\Upload\Prager\infoBeforeInstall.txt
AppPublisher=Prager, Software
AppPublisherURL=http://www.PragerSoftware.com
DefaultGroupName=Prager
AllowNoIcons=yes
LicenseFile=j:\Upload\Prager\Prager License Agreement.rtf
Compression=lzma/max
SolidCompression=yes
;AlwaysRestart=yes
AppMutex=PragerInventoryMutex

;---don't allow user to change target directory
UsePreviousAppDir=no
DisableDirPage=yes
DefaultDirName={pf}\Prager
OutputDir=j:\Upload\Prager
;  program name
OutputBaseFilename=PragerInventory-BETA

[Code]
 //-------------    Open URL in web browser after uninstall    -------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
ErrorCode: Integer;
begin
if (CurUninstallStep = usPostUninstall) then
  ShellExec('open', 'http://www.pragersoftware.com/feedback.html', '', '', SW_SHOW, ewNoWait, ErrorCode)
end;

//------------------    has full install been done?    -----------------
function InitializeSetup(): Boolean;
var
fname: String;
begin
  fname := ExpandConstant('{pf}') + '\Prager\PragerInventory.exe';
  result := true;

  if not (FileExists(fname)) then
    begin
    MsgBox('You must use the FULL installation before you can install the Updates or BETA', mbCriticalError, MB_OK);
    result := false;
    end;
end;

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "j:\C# Applications\Inventory Program\Prager Book Maintenance\bin\Release\PragerInventory.exe"; DestDir: "{app}"; DestName: "PragerInventory-BETA.exe"; Flags: ignoreversion
;Source: "C:\Program Files\Microsoft Visual Basic 2005 Power Packs\3.0\Microsoft.VisualBasic.PowerPacks.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
;Source: "J:\Upload\Prager\edtFTPnet.dll"; DestDir: "{pf}\Prager"; Flags: ignoreversion

;------------------    MsgBoxCheck    -------------------------
;Source: "J:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\MsgBoxCheck.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
;Source: "J:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\CbtHook.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
;Source: "J:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\WindowsHook.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
;Source: "j:\C# Applications\ExceptionMsgBox\Microsoft.ExceptionMessageBox.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist

;---------------    Firebird    --------------
;Source: "J:\Download\Firebird\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{pf}\Prager"; Flags: ignoreversion


; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Prager Book Inventory "; Filename: "{app}\PragerInventory-BETA.exe"
Name: "{group}\{cm:UninstallProgram,Prager Book Inventory }"; Filename: "{uninstallexe}"
Name: "{userdesktop}\Prager Book Inventory v9.4.5 BETA"; Filename: "{app}\PragerInventory-BETA.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Prager Book Inventory "; Filename: "{app}\PragerInventory-BETA.exe"; Tasks: quicklaunchicon





