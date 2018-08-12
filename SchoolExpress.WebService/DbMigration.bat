@echo off
if [%1]==[] (migrate.exe "SchoolExpress.WebService.exe" /startupConfigurationFile="SchoolExpress.WebService.exe.config" /force /verbose) ^
else (migrate.exe "SchoolExpress.WebService.exe" /startupConfigurationFile="SchoolExpress.WebService.exe.config" /force /verbose /targetMigration=%1)
pause