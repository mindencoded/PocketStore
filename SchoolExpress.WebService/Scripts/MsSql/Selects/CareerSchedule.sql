SET NOCOUNT ON
SELECT 
	[Id], 
	[Description],
	[CareerId], 
	[PeriodId], 
	[ModuleId], 
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status] 
FROM 
	[dbo].[CareerSchedule]