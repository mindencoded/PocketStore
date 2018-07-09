@ECHO off
CHCP 65001 > nul     
FOR /F "eol=; tokens=1* delims==" %%i in (sqlparams.conf) do SET %%i=%%j
SET Credentials=-U %Username% -P %Password%
IF .%Username%.==.. SET Credentials=-E
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources
SET names=Campus ClassRoom Course Degree Career CareerDetail Module Period Person Speaker Student CareerSchedule CareerScheduleDetail Enrollment EnrollmentDetail
sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -i %CD%\Scripts\MsSql\CleanTables.sql
sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -i %CD%\Scripts\MsSql\ResetIdentities.sql
(@ECHO off
FOR %%a in (%names%) DO (
	sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -Q "SET NOCOUNT ON; BULK INSERT [dbo].[%%a] FROM '%DataSources%\%%a.csv' WITH (CODEPAGE = '65001',FIRSTROW = 2, FIELDTERMINATOR = '|', ROWTERMINATOR = '\n', TABLOCK);"
))