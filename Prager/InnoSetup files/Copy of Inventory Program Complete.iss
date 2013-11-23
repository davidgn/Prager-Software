[Setup]
AppName=Prager Book Inventory 
AppID=Prager Inventory Program

AppVerName=Prager Book Inventory
VersionInfoVersion=8.11.2
;InfoBeforeFile=d:\Upload\Prager\infoBeforeInstall.txt
AppPublisher=Prager, Software
AppPublisherURL=http://www.PragerSoftware.com
;OnlyBelowVersion=0,6
DefaultGroupName=Prager
AllowNoIcons=yes
LicenseFile=j:\Upload\Prager\Prager License Agreement.rtf
Compression=lzma/max
SolidCompression=yes
;AlwaysRestart=yes
AppMutex=PragerInventoryMutex
;InfoAfterFile=Migrating from SQL Server Express to Firebird.rtf

DefaultDirName={pf}\Prager
OutputDir=j:\Upload\Prager
;  program name
OutputBaseFilename=PragerInventorySetup

[_ISTool]
EnableISX=true

[Code]

 //-------------    Open URL in web browser after uninstall    -------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
ErrorCode: Integer;
begin
if (CurUninstallStep = usPostUninstall) then
  ShellExec('open', 'http://www.pragersoftware.com/feedback.html', '', '', SW_SHOW, ewNoWait, ErrorCode)
end;

//-----------------    .NET code    ----------------------
var
dotnetRedistPath: string;
downloadNeeded: boolean;
dotNetNeeded: boolean;
memoDependenciesNeeded: string;

procedure isxdl_AddFile(URL, Filename: PChar);
external 'isxdl_AddFile@files:isxdl.dll stdcall';
function isxdl_DownloadFiles(hWnJ: Integer): Integer;
external 'isxdl_DownloadFiles@files:isxdl.dll stdcall';
function isxdl_SetOption(Option, Value: PChar): Integer;
external 'isxdl_SetOption@files:isxdl.dll stdcall';

//  download site ------------------------>V
const
dotnetRedistURL = 'http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe';
// local system for testing...
// dotnetRedistURL = 'http://192.168.1.1/dotnetfx.exe';

function InitializeSetup(): Boolean;

begin
Result := true;
dotNetNeeded := false;

// Check for required netfx installation
if (not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v2.0.50727')) then begin
   dotNetNeeded := true;
  if (not IsAdminLoggedOn()) then begin
  MsgBox('This application needs the Microsoft .NET Framework v2.0 to be installed by an Administrator', mbInformation, MB_OK);
  Result := false;
    end else begin
    memoDependenciesNeeded := memoDependenciesNeeded + ' .NET Framework' #13;
    dotnetRedistPath := ExpandConstant('{src}\dotnetfx.exe');
      if not FileExists(dotnetRedistPath) then begin
      dotnetRedistPath := ExpandConstant('{tmp}\dotnetfx.exe');
        if not FileExists(dotnetRedistPath) then begin
        isxdl_AddFile(dotnetRedistURL, dotnetRedistPath);
        downloadNeeded := true;
        end;
      end;
    SetIniString('install', 'dotnetRedist', dotnetRedistPath, ExpandConstant('{tmp}\dep.ini'));
    end;
  end;
end;

function NextButtonClick(CurPage: Integer): Boolean;
var
hWnd: Integer;
ResultCode: Integer;

begin
Result := true;

if CurPage = wpReady then begin

   hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));
   // don't try to init isxdl if it's not needed because it will error on < ie 3
  if downloadNeeded then begin
    isxdl_SetOption('label', 'Downloading Microsoft .NET Framework');
    isxdl_SetOption('description', 'This application needs to install the Microsoft .NET Framework 2.0. Please wait while Setup is downloading extra files to your computer.');
    if isxdl_DownloadFiles(hWnd) = 0 then Result := false;
    end;
    if (Result = true) and (dotNetNeeded = true) then begin
      if Exec(ExpandConstant(dotnetRedistPath), '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then begin
      // handle success if necessary; ResultCode contains the exit code
        if not (ResultCode = 0) then begin
        Result := false;
        end;
      end else begin
      // handle failure if necessary; ResultCode contains the error code
      Result := false;
      end;
    end;
  end;
end;

function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
var
s: string;

begin
if memoDependenciesNeeded <> '' then
  s := s + 'Dependencies to install:' + NewLine + memoDependenciesNeeded + NewLine;
  s := s + MemoDirInfo + NewLine + NewLine;

  Result := s
end;

//----------------------    Firebird code    ------------------------
function IsFirebirdInstalled():Boolean;
begin
 if FileExists ('c:\Program Files\Firebird\bin\fbserver.exe') then
    result := true
 else
    result := false
end;

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "J:\C# Applications\Inventory Program\Prager Book Maintenance\bin\Release\PragerInventory.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Program Files\Microsoft Visual Basic 2005 Power Packs\3.0\Microsoft.VisualBasic.PowerPacks.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
Source: "J:\C# Applications\Inventory Program\Prager Book Maintenance\bin\Release\RealPosition.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "J:\Upload\Prager\Files for CD-ROM\Sample File to Import.txt"; DestDir: "{app}\Sample Files";
Source: "J:\Upload\Prager\Files for CD-ROM\SamplePrimaryCatalog.txt"; DestDir: "{app}\Sample Files";
Source: "J:\Upload\Prager\Files for CD-ROM\TestUploadFiles\*"; DestDir: "{app}\Export";
Source: "J:\Upload\Prager\Inventory.cfg"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Program Files\helpMATIC Pro HTML\My Projects\Prager Inventory Program\BookInventoryPgm.chm"; DestDir: "{app}"; Flags: ignoreversion
Source: "J:\C# Applications\Inventory Program\migrateFromSQLServer\bin\Debug\migrateFromSQLServer.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
Source: "j:\C# Applications\ExceptionMsgBox\Microsoft.ExceptionMessageBox.dll"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
;Source: "J:\C# Applications\Google\bin\Release\Google.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "J:\Upload\Prager\edtFTPnet.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "J:\Upload\Prager\dbBooks.fdb"; DestDir: "C:\prager"; Flags: onlyifdoesntexist

Source: "c:\program files\Firebird\bin\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{pf}\Prager"; Flags: ignoreversion
Source: "J:\Download\Firebird-2.1.1.17910-0_Win32.exe"; DestDir: "{tmp}"; Flags: ignoreversion

Source: "J:\C# Applications\AmazonECS\src\Amazon.ECS\bin\Release\Amazon.ECS.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: C:\Program Files\ISTool\isxdl.dll; Flags: dontcopy
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Prager Book Inventory "; Filename: "{app}\PragerInventory.exe"
Name: "{group}\{cm:UninstallProgram,Prager Book Inventory }"; Filename: "{uninstallexe}"
Name: "{userdesktop}\Prager Book Inventory v8.11.2"; Filename: "{app}\PragerInventory.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Prager Book Inventory "; Filename: "{app}\PragerInventory.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{sys}\net.exe"; Parameters: "stop firebirdserverdefaultinstance"; Check: IsFirebirdInstalled; Flags: runascurrentuser shellexec waituntilterminated; StatusMsg: "Stopping Firebird service..."
Filename: "{pf}\Firebird\unins000.exe"; Parameters: "/SILENT"; Check: IsFirebirdInstalled; Flags: runascurrentuser waituntilterminated; StatusMsg: "Uninstalling Firebird database engine...";
Filename: "{tmp}\Firebird-2.1.1.17910-0_Win32.exe"; Parameters: "/SP- /SILENT /LOG /NOCANCEL /LANG=""en"" /DIR=""{pf}\Firebird"" /GROUP=""Firebird"" /NOICONS /NOCPL /COMPONENTS=""ServerComponent,ServerComponent\SuperServerComponent,DevAdminComponent,ClientComponent"""; StatusMsg: "Installing database engine..."; Flags: waituntilterminated
;Filename: "{pf}\Firebird\bin\gsec.exe"; Parameters: "-add prager -pw books"; Check: IsFirebirdInstalled; Flags: runascurrentuser shellexec waituntilterminated; StatusMsg: "Adding user..."

