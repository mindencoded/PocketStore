DELETE FROM Campus
DBCC CHECKIDENT ('[Campus]', RESEED, 0);
GO
SET IDENTITY_INSERT Campus ON
insert into Campus(Id, Description, Address, Location, LastModified, Created, Status) values (1, 'Campus Principal', '', '', GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Campus OFF