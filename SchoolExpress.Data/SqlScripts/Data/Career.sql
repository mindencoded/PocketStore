DELETE FROM Career
DBCC CHECKIDENT ('[Career]', RESEED, 0);
GO
SET IDENTITY_INSERT Career ON
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (1, 'Administraci�n de Negocios Internacionales', 3, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (2, 'Contabilidad', 3, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (3, 'Maestr�a en Administraci�n de Negocios (MBA Internacional)', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (4, 'Maestr�a en Gesti�n de Tecnolog�as de la Informaci�n', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (5, 'Maestr�a en Derecho de la Empresa', 5, GETDATE(), GETDATE(), 1)
insert into Career(Id, Description, DegreeId, LastModified, Created, Status) values (6, 'Maestr�a en Gesti�n Minera y Ambiental', 5, GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Career OFF