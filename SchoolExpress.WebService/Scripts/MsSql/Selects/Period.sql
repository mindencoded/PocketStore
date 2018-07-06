SET NOCOUNT ON
SELECT 
	[Id], 
	[Description],
	ISNULL(CONVERT(varchar(19), [StartDate], 120), '') AS [StartDate],
	ISNULL(CONVERT(varchar(19), [EndDate], 120),'') AS [EndDate], 
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status] 
FROM 
	[dbo].[Period]
