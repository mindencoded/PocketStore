SET IDENTITY_INSERT [dbo].[Degree] ON;
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (1,'Bachiller',GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (2,'Pregrado',GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (3,'Grado',GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (4,'Postgrado',GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (5,'Magíster',GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Degree] ([Id], [Description], [LastModified], [Created], [Status]) VALUES (6,'PhD',GETDATE(), GETDATE(), 1);
SET IDENTITY_INSERT [dbo].[Degree] OFF;