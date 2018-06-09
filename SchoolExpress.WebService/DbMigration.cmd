@ECHO OFF
IF [%1]==[] (migrate.exe "SchoolExpress.Data.dll" /startupConfigurationFile="SchoolExpress.WebService.exe.config" /force /verbose) ^
ELSE (migrate.exe "SchoolExpress.Data.dll" /startupConfigurationFile="SchoolExpress.WebService.exe.config" /force /verbose /targetMigration=%1)
PAUSE