DELETE FROM ClassRoom
DBCC CHECKIDENT ('[ClassRoom]', RESEED, 0);
GO
SET IDENTITY_INSERT ClassRoom ON
insert into ClassRoom(Id, Description, CampusId, LastModified, Created, Status) values (1, '101', 1, GETDATE(), GETDATE(), 1)
insert into ClassRoom(Id, Description, CampusId, LastModified, Created, Status) values (2, '102', 1, GETDATE(), GETDATE(), 1)
insert into ClassRoom(Id, Description, CampusId, LastModified, Created, Status) values (3, '103', 1, GETDATE(), GETDATE(), 1)
insert into ClassRoom(Id, Description, CampusId, LastModified, Created, Status) values (4, '201', 1, GETDATE(), GETDATE(), 1)
insert into ClassRoom(Id, Description, CampusId, LastModified, Created, Status) values (5, '202', 1, GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT ClassRoom OFF