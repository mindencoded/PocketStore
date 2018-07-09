@ECHO off
@chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i in (sqlparams.conf) do SET %%i=%%j
SET names=Campus ClassRoom Course Degree Career CareerDetail Module Period Person Speaker Student CareerSchedule CareerScheduleDetail Enrollment EnrollmentDetail
SET PGPASSWORD=%Password%
(	@ECHO off 
	TYPE %CD%\Scripts\PgSql\CleanTables.sql
	TYPE %CD%\Scripts\PgSql\ResetIdentities.sql
	FOR %%a in (%names%) DO (
		TYPE '%CD%\Scripts\PgSql\Data\%%a.sql
	)
) | psql -h %Server% -p 5432 -d %Database% -U %Username% -w