@echo off
del /q "DataSources"
for %%i in ("Scripts\MsSql\Selects\*.sql") do sqlcmd -S (LocalDb)\MSSQLLocalDB -d SchoolExpressDb -E -u -s "|" -W -i %%i | findstr /V /C:"-" /B > "DataSources\%%~ni.csv"