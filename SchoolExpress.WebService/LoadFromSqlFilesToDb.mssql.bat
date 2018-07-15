@ECHO off
chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i IN (sqlparams.conf) DO SET %%i=%%j
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources\System.Data.SqlClient\Sql

FOR %%a IN (%Names%) DO (
    FOR /f %%i IN ('sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -Q "SET NOCOUNT ON; SELECT OBJECTPROPERTY(OBJECT_ID('%%a'), 'TableHasIdentity');" ^| FINDSTR /V /C:"-" /B') DO (
        IF %%i == 1 (
            FOR /f "delims=" %%q IN (%DataSources%\%%a.sql) DO (  
				sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -Q "SET NOCOUNT ON; DBCC CHECKIDENT ('[dbo].[%%a]', RESEED, 0) WITH NO_INFOMSGS; SET IDENTITY_INSERT [dbo].[%%a] ON; %%q SET IDENTITY_INSERT [dbo].[%%a] OFF;" 
			)
        ) ELSE (
            FOR /f "delims=" %%q IN (%DataSources%\%%a.sql) DO ( 
				sqlcmd -S %Server% -d %Database% %Credentials% %Crypt% -W -u -Q "SET NOCOUNT ON; %%q" 
			)
        )
    )
)


