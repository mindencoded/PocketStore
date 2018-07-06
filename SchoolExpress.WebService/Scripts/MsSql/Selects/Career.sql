SET NOCOUNT ON
SELECT
	[Id], 
	[Description],
	[DegreeId], 
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status]
FROM [dbo].[Career]