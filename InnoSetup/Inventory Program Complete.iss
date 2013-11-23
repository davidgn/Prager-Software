[Setup]
AppName=Prager Book Inventory
AppID=Prager Inventory Program
AppVerName=Prager Book Inventory
VersionInfoVersion=12.9.2
;InfoAFterFile=G:\Upload\Prager\infoAfterInstall.rtf
InfoBeforeFile=d:\Upload\Prager\InnoSetup files\infoBeforeInstall.rtf
AppPublisher=Prager, Software
AppPublisherURL=http://www.PragerSoftware.com
DefaultGroupName=Prager
;DisableDirPage=yes
AlwaysShowComponentsList=yes
AllowNoIcons=yes
LicenseFile=D:\Upload\Prager\Prager License Agreement.rtf
Compression=lzma/max
SolidCompression=yes
AppMutex=PragerInventoryMutex
DefaultDirName={pf32}\Prager\Inv
OutputDir=D:\Upload\Prager
OutputBaseFilename=PragerInventorySetup-12.9.2

[Dirs]
;Name: "{app}\Prager"; Permissions: everyone-modify; MinVersion: 0,5.0

[Icons]
Name: "{group}\Prager Book Inventory "; Filename: {pf32}\Prager\Inv\PragerInventory.exe
Name: {group}\{cm:UninstallProgram,Prager Book Inventory }; Filename: {uninstallexe}
Name: {userdesktop}\Prager Book Inv - 12.9.2; Filename: {pf32}\Prager\Inv\PragerInventory.exe; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Prager Book Inventory "; Filename: {pf32}\Prager\Inv\PragerInventory.exe; Tasks: quicklaunchicon

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]  
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.exe; DestDir: {pf32}\Prager\Inv; DestName: PragerInventory.exe; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.pdb; DestDir: {pf32}\Prager\Inv; DestName: PragerInventory.pdb; Flags: ignoreversion
;Source: D:\Prager Software\Book Inventory Manager\bin\Release\PricingRoutines.dll; DestDir: {pf32}\Prager\Inv; DestName: PricingRoutines.dll; Flags: ignoreversion
;Source: D:\Prager Software\Book Inventory Manager\bin\Release\PricingRoutines.pdb; DestDir: {pf32}\Prager\Inv; DestName: PricingRoutines.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\GetBookInfo.dll; DestDir: {pf32}\Prager\Inv; DestName: GetBookInfo.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\GetBookInfo.pdb; DestDir: {pf32}\Prager\Inv; DestName: GetBookInfo.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.dll; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebService.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.pdb; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebService.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.dll; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebServiceProducts.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.pdb; DestDir: {pf32}\Prager\Inv; DestName: MarketplaceWebServiceProducts.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\PragerInventory.exe.config; DestDir: {pf32}\Prager\Inv; DestName: PragerInventory.exe.config; Flags: ignoreversion

;  miscellaneous support files
Source: D:\Upload\Prager\Files for CD-ROM\Sample File to Import.txt; DestDir: {sd}\Prager\Sample Files
Source: D:\Upload\Prager\Files for CD-ROM\SamplePrimaryCatalog.txt; DestDir: {sd}\Prager\Sample Files
Source: D:\Upload\Prager\Files for CD-ROM\Amazon book catalog.txt; DestDir: {sd}\Prager\Sample Files
Source: D:\Upload\Prager\TestUploadFiles\*; DestDir: {sd}\Prager\Export
Source: D:\Upload\Prager\Inventory.cfg; DestDir: C:\Prager; Flags: ignoreversion onlyifdoesntexist 
Source: D:\C# Applications\edtFTPnet\edtFTPnet.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion
Source: D:\C# Applications\Amazon Marketplace Web Services\src\MarketplaceWebService\bin\Release\MarketplaceWebService.dll; DestDir: {pf32}\Prager\Inv; 
Source: D:\Upload\Prager\Databases\dbBooks.fdb; DestDir: {sd}\Prager; Flags: onlyifdoesntexist uninsneveruninstall

;  WinSCP files
Source: D:\Prager Software\WinSCP\WinSCP.exe; DestDir: {pf32}\Prager\Inv; DestName: WinSCP.exe; Flags: ignoreversion
Source: D:\Prager Software\WinSCP\WinSCP.dll; DestDir: {pf32}\Prager\Inv; DestName: WinSCP.dll; Flags: ignoreversion 
Source: D:\Prager Software\WinSCP\WinSCPnet.dll; DestDir: {pf32}\Prager\Inv; DestName: WinSCPnet.dll; Flags: ignoreversion 

;  MessageBoxChk supporting code
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\MsgBoxCheck.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\CbtHook.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist
Source: D:\C# Applications\MessageBoxChk\MsgBoxCheck\bin\Release\WindowsHook.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion onlyifdoesntexist

;  updated Firebird API .dll
Source: D:\Upload\Prager\Firebird\FirebirdSql.Data.FirebirdClient.dll; DestDir: {pf32}\Prager\Inv; Flags: ignoreversion
;  Firebird installation file (make sure to change way program finds this in the registry)  <----------
Source: D:\Upload\Prager\Firebird\Firebird-2.1.4.18393_0_Win32.exe; DestDir: {tmp}; Flags: ignoreversion


;Source: D:\Prager Software\WinSCP\winscp511setup.exe; DestDir: {tmp}; Flags: ignoreversion

;  line below is used in code section below
Source: d:\Upload\Prager\isxdl.dll; Flags: dontcopy
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Run]
;Filename: "{sys}\net.exe"; Parameters: "stop firebirdserverdefaultinstance"; Check: IsFirebirdInstalled; Flags: runascurrentuser shellexec waituntilterminated; StatusMsF: "Stopping Firebird service..."
;Filename: "{pf32}\Firebird\unins000.exe"; Parameters: "/SILENT"; Check: IsFirebirdInstalled; Flags: runascurrentuser waituntilterminated; StatusMsF: "Uninstalling Firebird database engine...";
Filename: {tmp}\Firebird-2.1.4.18393_0_Win32.exe; Check: IsFirebirdInstalled; Parameters: "/SP- /SILENT /LOG /NOCANCEL /LANG=""en"" /DIR=""{pf32}\Firebird"" /GROUP=""Firebird"" /NOICONS /NOCPL /COMPONENTS=""ServerComponent,ServerComponent\SuperServerComponent,DevAdminComponent,ClientComponent"""; StatusMsG: Installing database engine...; Flags: waituntilterminated
;Filename: "{pf32}\Firebird\bin\gsec.exe"; Parameters: "-add prager -pw books"; Check: IsFirebirdInstalled; Flags: runascurrentuser shellexec waituntilterminated; StatusMsG: "Adding user..."
Filename: {tmp}\winscp427setup.exe; Check: IsWinSCPInstalled; Parameters: /SILENT /NOCANDY

[_ISTool]
EnableISX=true

[Code]
function DeleteOldFiles(): Boolean;
var
fname: string;
begin
  fname := ExpandConstant('{pf}') + '\Prager\Tamir.SharpSSH.dll';
//  result := true;
  DeleteFile(fname);
end;

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


const
//dotnetRedistURL = 'http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe';
dotnetRedistURL = 'http://www.microsoft.com/download/en/confirmation.aspx?id=17851'; //  dotNet 4.0
// local system for testing...
// dotnetRedistURL = 'http://192.168.1.1/dotnetfx.exe';

function InitializeSetup(): Boolean;
begin
Result := true;
dotNetNeeded := false;

// Check for required netfx installation
 if (not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v4')) then begin
        MsgBox('This program requires Microsoft .NET Framework 4.0.x (currently 4.0.3) Full Setup.'#13#13
        'Please use Windows Update to install this version,'#13
        'and then re-run the Book Inventory Manager setup program.', mbInformation, MB_OK);
        result := false;
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
  isxdl_SetOption('description', 'This application needs to install the Microsoft .NET Framework 4.0. Please wait while Setup is downloading extra files to your computer.');
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

//if (not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v2.0.50727')) and
//(not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v3.0')) and
//(not RegKeyExists(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v3.5')) then begin
//   dotNetNeeded := true;

//----------------------    Firebird code    ------------------------
function IsFirebirdInstalled():Boolean;
begin
  Result := true;
  if (RegValueExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Firebird Project\Firebird Server\Instances', 'DefaultInstance') AND
      FileExists(ExpandConstant('{pf32}\Firebird\bin\fbserver.exe'))) then
      begin
//    MsgBox('firebird key exists', mbInformation, MB_OK);
      Result := false;  //  don't process if it already exists
  end;

//    begin
  //if Is64BitInstallMode then
    //MsgBox('Installing in 64-bit mode', mbInformation, MB_OK)
//  else
  //  MsgBox('Installing in 32-bit mode', mbInformation, MB_OK);
//end;

 end;

 //----------------------    WinSCP code    ------------------------
function IsWinSCPInstalled():Boolean;
  var
  fname: String;

begin
  DeleteOldFiles();  //  delete any old files no longer used

  fname := ExpandConstant('{pf32}\WinSCP\WinSCP.exe');
  Result := false;
  if not FileExists(fname) then
      begin
     //   MsgBox('WinSCP does NOT exist: ' + fname, mbInformation, MB_OK);
        Result := true;  //  don't process if it already exists
      end;
end;
