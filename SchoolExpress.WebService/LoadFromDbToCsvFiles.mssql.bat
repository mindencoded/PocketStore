@ECHO off
chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i IN (sqlparams.conf) DO SET %%i=%%j
SET Credentials=-U %Username% -P %Password%
IF .%Username%.==.. SET Credentials=-E
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources\System.Data.SqlClient\Csv
(
    @ECHO off
    FOR %%a IN (%Names%) DO (	
        sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -s "|" -Q "SET NOCOUNT ON; SELECT * FROM [dbo].[%%a];" | FINDSTR /V /C:"-" /B | replace-null.exe > %DataSources%\%%a.csv
    )
)