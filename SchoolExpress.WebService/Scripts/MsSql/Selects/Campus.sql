SET NOCOUNT ON
SELECT 
	[Id], 
	[Description],
	ISNULL([Address], '') AS [Address],
	ISNULL([Location],'') AS [Location],
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status] 
FROM 
	[dbo].[Campus]