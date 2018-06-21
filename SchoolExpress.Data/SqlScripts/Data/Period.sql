DELETE FROM Period
DBCC CHECKIDENT ('Period', RESEED, 0);
GO
SET IDENTITY_INSERT Period ON
insert into Period (Id, Description, StartDate, EndDate, LastModified, Created, Status) values (1, '2018 I', NULL, NULL, GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Period OFF