DELETE FROM Module
DBCC CHECKIDENT ('Module', RESEED, 0);
GO
SET IDENTITY_INSERT Module ON
insert into Module (Id, Description, LastModified, Created, Status) values (1, 'Ciclo I', GETDATE(), GETDATE(), 1)
insert into Module (Id, Description, LastModified, Created, Status) values (2, 'Ciclo II', GETDATE(), GETDATE(), 1)
insert into Module (Id, Description, LastModified, Created, Status) values (3, 'Ciclo III', GETDATE(), GETDATE(), 1)
insert into Module (Id, Description, LastModified, Created, Status) values (4, 'Ciclo IV', GETDATE(), GETDATE(), 1)
insert into Module (Id, Description, LastModified, Created, Status) values (5, 'Ciclo V', GETDATE(), GETDATE(), 1)
insert into Module (Id, Description, LastModified, Created, Status) values (6, 'Ciclo VI', GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Module OFF
