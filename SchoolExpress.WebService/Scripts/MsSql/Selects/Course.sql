SET NOCOUNT ON
SELECT 
	[Id],
	ISNULL([Code],'') AS [Code],
	[Description],
	ISNULL([BackgroundColor],'') AS [BackgroundColor],
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status] 
FROM 
	[dbo].[Course]