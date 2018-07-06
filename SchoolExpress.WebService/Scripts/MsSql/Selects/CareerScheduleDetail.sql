SET NOCOUNT ON
SELECT
	[Id],
	ISNULL(CONVERT(varchar(25), [StartTime], 120), '') AS [StartTime],
	ISNULL(CONVERT(varchar(25), [EndTime], 120),'') AS [EndTime],
	ISNULL([Day], '') AS [Day],
	[CareerScheduleId],
	[ClassRoomId],
	[SpeakerId],
	[CareerDetailId],
	CONVERT(varchar(19), [LastModified], 120)  AS [LastModified], 
	CONVERT(varchar(19), [Created], 120)  AS [Created],
	[Status]
FROM
	[dbo].[CareerScheduleDetail]