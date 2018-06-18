DELETE FROM Degree
DBCC CHECKIDENT ('[Degree]', RESEED, 0);
GO
SET IDENTITY_INSERT Degree ON
insert into Degree (Id, Description, LastModified, Created, Status) values(1,'Bachiller',GETDATE(), GETDATE(), 1)
insert into Degree (Id, Description, LastModified, Created, Status) values(2,'Pregrado',GETDATE(), GETDATE(), 1)
insert into Degree (Id, Description, LastModified, Created, Status) values(3,'Grado',GETDATE(), GETDATE(), 1)
insert into Degree (Id, Description, LastModified, Created, Status) values(4,'Postgrado',GETDATE(), GETDATE(), 1)
insert into Degree (Id, Description, LastModified, Created, Status) values(5,'Magíster',GETDATE(), GETDATE(), 1)
insert into Degree (Id, Description, LastModified, Created, Status) values(6,'PhD',GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Degree OFF