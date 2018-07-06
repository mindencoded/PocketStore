SET NOCOUNT ON
DECLARE @filepath nvarchar(200)
SET @filepath = N'$(filepath)'
DECLARE @tablename nvarchar(200)
SET @tablename = N'$(tablename)'
DECLARE @sql NVARCHAR(2000) 
SELECT @tablename
SET @sql = N'BULK INSERT [dbo].[' + @tablename + '] FROM ''' + @filepath + ''' WITH (CODEPAGE = ''65001'',FIRSTROW = 2, FIELDTERMINATOR = ''|'', ROWTERMINATOR = ''\n'', TABLOCK);';
EXEC(@sql)