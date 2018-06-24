DELETE FROM Career
DBCC CHECKIDENT ('[Career]', RESEED, 0);
GO
SET IDENTITY_INSERT Career ON
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (1, 'Administración de Negocios Internacionales', 3, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (2, 'Contabilidad', 3, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (3, 'Maestría en Administración de Negocios (MBA Internacional)', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (4, 'Maestría en Gestión de Tecnologías de la Información', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (5, 'Maestría en Derecho de la Empresa', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (6, 'Maestría en Gestión Minera y Ambiental', 5, GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Career OFF