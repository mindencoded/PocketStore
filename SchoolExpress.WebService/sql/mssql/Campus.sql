SET IDENTITY_INSERT [dbo].[Campus] ON;
INSERT INTO [dbo].[Campus] ([Id], [Description], [Address], [Location], [LastModified], [Created], [Status]) VALUES (1, 'Campus Principal', '', '', GETDATE(), GETDATE(), 1);
SET IDENTITY_INSERT [dbo].[Campus] OFF;