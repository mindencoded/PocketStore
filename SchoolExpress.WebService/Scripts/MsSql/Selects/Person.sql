SET NOCOUNT ON
SELECT 
	[Id], 
	ISNULL([IdentityCard],'') AS [IdentityCard],
	[Name],
	ISNULL([LastName],'') AS [LastName],
	[Email],
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status]
FROM 
	[dbo].[Person] 