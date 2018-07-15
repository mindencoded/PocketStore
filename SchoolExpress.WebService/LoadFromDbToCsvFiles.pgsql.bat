@ECHO off
chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i IN (sqlparams.conf) DO SET %%i=%%j
SET PGPASSWORD=%Password%
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources\Npgsql\Csv
SET PGPASSWORD=%Password%
(
    @ECHO off 
    FOR %%a IN (%Names%) DO ( 
        ECHO COPY "dbo"."%%a" TO '%DataSources%\%%a.csv' DELIMITER '^^^|' CSV HEADER; 
    )
) | psql -h %Server% -p 5432 -d %Database% -U %Username% -w