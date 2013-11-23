[Setup]
AppName=Prager Bulk Book Loader

;  don't forget to change version number -->
AppVerName=Prager Bulk Book Loader
VersionInfoVersion=12.5.0
;InfoBeforeFile=f:\Upload\Prager\infoBeforeInstall.rtf
;InfoAFterFile=f:\Upload\Prager\infoAfterInstall.rtf
AppPublisher=Prager, Software
AppPublisherURL=http://www.PragerSoftware.com
DefaultGroupName=Prager
AllowNoIcons=yes
LicenseFile=d:\Upload\Prager\Prager License Agreement.rtf
Compression=lzma/ultra64
SolidCompression=yes
;AlwaysRestart=yes
AppMutex=PragerInventoryMutex

;---don't allow user to change target directory
UsePreviousAppDir=no
DisableDirPage=yes
DefaultDirName={pf32}\Prager\Ldr
OutputDir=d:\Upload\Prager
;  program name
OutputBaseFilename=BulkAddBooks

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: D:\Prager Software\BulkLister\bin\Release\BulkAddBooks.exe; DestDir: "{pf32}\Prager\Ldr"; DestName: "BulkAddBooks.exe"; Flags: ignoreversion
Source: D:\Prager Software\BulkLister\bin\Release\BulkAddBooks.pdb; DestDir: "{pf32}\Prager\Ldr"; DestName: "BulkAddBooks.pdb"; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.dll; DestDir: {pf32}\Prager\Ldr; DestName: MarketplaceWebService.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebService.pdb; DestDir: {pf32}\Prager\Ldr; DestName: MarketplaceWebService.pdb; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.dll; DestDir: {pf32}\Prager\Ldr; DestName: MarketplaceWebServiceProducts.dll; Flags: ignoreversion
Source: D:\Prager Software\Book Inventory Manager\bin\Release\MarketplaceWebServiceProducts.pdb; DestDir: {pf32}\Prager\Ldr; DestName: MarketplaceWebServiceProducts.pdb; Flags: ignoreversion
;Source: "d:\Download\Firebird\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{pf32}\Prager\Ldr"; Flags: ignoreversion
Source: "D:\Upload\Prager\Firebird\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{pf32}\Prager\Ldr"; Flags: ignoreversion

[Icons]
Name: "{group}\Prager Bulk Book Loader "; Filename: "{app}\Ldr\BulkAddBooks.exe"
Name: "{group}\{cm:UninstallProgram,Prager Bulk Book Loader }"; Filename: "{uninstallexe}"
Name: "{userdesktop}\Prager Bulk Book Loader v12.5.0"; Filename: "{pf32}\Prager\Ldr\BulkAddBooks.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Prager Bulk Book Loader "; Filename: "{pf32}\Prager\Ldr\BulkAddBooks.exe"; Tasks: quicklaunchicon


[Code]
 //-------------    Open URL in web browser after uninstall    -------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
ErrorCode: Integer;
begin
if (CurUninstallStep = usPostUninstall) then
  ShellExec('open', 'http://www.pragersoftware.com/feedback.html', '', '', SW_SHOW, ewNoWait, ErrorCode)
end;





