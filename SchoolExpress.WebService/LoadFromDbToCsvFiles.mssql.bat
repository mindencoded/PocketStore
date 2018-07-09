@ECHO off
CHCP 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i in (sqlparams.conf) do SET %%i=%%j
SET Credentials=-U %Username% -P %Password%
IF .%Username%.==.. SET Credentials=-E
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources
SET names=Campus ClassRoom Course Degree Career CareerDetail Module Period Person Speaker Student CareerSchedule CareerScheduleDetail Enrollment EnrollmentDetail
(@ECHO off
FOR %%a in (%names%) DO (	
	sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -s "|" -Q "SET NOCOUNT ON; SELECT * FROM [dbo].[%%a];" | FINDSTR /V /C:"-" /B | replace-null.exe > %DataSources%\%%a.csv
))