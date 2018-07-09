@ECHO off
@chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i in (sqlparams.conf) do SET %%i=%%j
SET names=Campus ClassRoom Course Degree Career CareerDetail Module Period Person Speaker Student CareerSchedule CareerScheduleDetail Enrollment EnrollmentDetail
sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -i %CD%\SqlQueries\System.Data.SqlClient\CleanTables.sql
sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -i %CD%\SqlQueries\System.Data.SqlClient\ResetIdentities.sql
( @ECHO off
	FOR %%a in (%names%) DO ( sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -i '%CD%\SqlQueries\System.Data.SqlClient\Data\%%a.sql )
)