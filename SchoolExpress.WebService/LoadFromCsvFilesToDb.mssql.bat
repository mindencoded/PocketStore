@ECHO off
chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i IN (sqlparams.conf) DO SET %%i=%%j
SET Credentials=-U %Username% -P %Password%
IF .%Username%.==.. SET Credentials=-E
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources\System.Data.SqlClient\Csv
( 
    @ECHO off
    FOR %%a IN (%Names%) DO (
        sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -Q "SET NOCOUNT ON; BULK INSERT [dbo].[%%a] FROM '%DataSources%\%%a.csv' WITH (CODEPAGE = '65001',FIRSTROW = 2, FIELDTERMINATOR = '|', ROWTERMINATOR = '\n', TABLOCK);"
    )
)