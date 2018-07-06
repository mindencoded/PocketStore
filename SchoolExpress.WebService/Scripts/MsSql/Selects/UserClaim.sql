SET NOCOUNT ON
SELECT
	[Id],
	[UserId],
	ISNULL([ClaimType],'') AS [ClaimType],
	ISNULL([ClaimValue],'') AS [ClaimValue]	
FROM
	[dbo].[UserClaim] 