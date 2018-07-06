SET NOCOUNT ON
SELECT 
	[Id], 
	[CampusId], 
	[Description],
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status] 
FROM 
	[dbo].[ClassRoom]