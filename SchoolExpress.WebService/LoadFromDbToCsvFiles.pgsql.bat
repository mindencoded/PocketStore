@ECHO off
CHCP 65001 > null
FOR /F "eol=; tokens=1* delims==" %%i in (sqlparams.conf) do SET %%i=%%j
SET PGPASSWORD=%Password%
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources
SET names=Campus ClassRoom Course Degree Career CareerDetail Module Period Person Speaker Student CareerSchedule CareerScheduleDetail Enrollment EnrollmentDetail
SET PGPASSWORD=%Password%
(@ECHO off 
    FOR %%a in (%names%) DO ( ECHO COPY "dbo"."%%a" TO '%DataSources%\%%a.csv' DELIMITER '^^^|' CSV HEADER; )
) | psql -h %Server% -p 5432 -d %Database% -U %Username% -w