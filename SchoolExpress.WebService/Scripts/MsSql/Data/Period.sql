SET IDENTITY_INSERT [dbo].[Period] ON;
INSERT INTO [dbo].[Period] ([Id], [Description], [StartDate], [EndDate], [LastModified], [Created], [Status]) VALUES (1, '2018 I', NULL, NULL, GETDATE(), GETDATE(), 1);
SET IDENTITY_INSERT [dbo].[Period] OFF;