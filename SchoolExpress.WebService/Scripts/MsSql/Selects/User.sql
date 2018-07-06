SET NOCOUNT ON
SELECT 
	[Id],
	ISNULL([Email],''),
	[EmailConfirmed],
	ISNULL([PasswordHash],'') AS [PasswordHash],
	ISNULL([SecurityStamp],'') AS [SecurityStamp],
	ISNULL([PhoneNumber],'') AS [PhoneNumber],
	[PhoneNumberConfirmed],
	[TwoFactorEnabled],
	ISNULL(CONVERT(varchar(19), [LockoutEndDateUtc], 120),'')  AS [LockoutEndDateUtc], 
	[LockoutEnabled],
	[AccessFailedCount],
	[UserName]
FROM 
	[dbo].[User] 