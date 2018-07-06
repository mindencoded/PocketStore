SET IDENTITY_INSERT [dbo].[Career] ON;
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (1, 'Administración de Negocios Internacionales', 3, GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (2, 'Contabilidad', 3, GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (3, 'Maestría en Administración de Negocios (MBA Internacional)', 5, GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (4, 'Maestría en Gestión de Tecnologías de la Información', 5, GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (5, 'Maestría en Derecho de la Empresa', 5, GETDATE(), GETDATE(), 1);
INSERT INTO [dbo].[Career]([Id], [Description], [DegreeId], [LastModified], [Created], [Status]) VALUES (6, 'Maestría en Gestión Minera y Ambiental', 5, GETDATE(), GETDATE(), 1);
SET IDENTITY_INSERT [dbo].[Career] OFF;