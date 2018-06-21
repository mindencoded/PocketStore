DELETE FROM CareerSchedule
DBCC CHECKIDENT ('[CareerSchedule]', RESEED, 0);
GO
SET IDENTITY_INSERT CareerSchedule ON
-- Period: 1, Career: 1
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (1, '2018 I, Administración de Negocios Internacionales, Ciclo I',				1, 1, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (2, '2018 I, Administración de Negocios Internacionales, Ciclo II',			1, 1, 2, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (3, '2018 I, Administración de Negocios Internacionales, Ciclo III',			1, 1, 3, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (4, '2018 I, Administración de Negocios Internacionales, Ciclo IV',			1, 1, 4, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (5, '2018 I, Administración de Negocios Internacionales, Ciclo V',				1, 1, 5, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (6, '2018 I, Administración de Negocios Internacionales, Ciclo VI',			1, 1, 6, GETDATE(), GETDATE(), 1)
-- Period: 1, Career: 2
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (7, '2018 I, Contabilidad, Ciclo I',											1, 2, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (8, '2018 I, Contabilidad, Ciclo II',											1, 2, 2, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (9, '2018 I, Contabilidad, Ciclo III',											1, 2, 3, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (10, '2018 I, Contabilidad, Ciclo IV',											1, 2, 4, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (11, '2018 I, Contabilidad, Ciclo V',											1, 2, 5, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (12, '2018 I, Contabilidad, Ciclo VI',											1, 2, 6, GETDATE(), GETDATE(), 1)
-- Period: 1, Career: 3
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (13, '2018 I, Maestría en Administración de Negocios, Ciclo I',				1, 3, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (14, '2018 I, Maestría en Administración de Negocios, Ciclo II',				1, 3, 2, GETDATE(), GETDATE(), 1)
-- Period: 1, Career: 4
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (15, '2018 I, Maestría en Gestión de Tecnologías de la Información, Ciclo I',	1, 4, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (16, '2018 I, Maestría en Gestión de Tecnologías de la Información, Ciclo II',	1, 4, 2, GETDATE(), GETDATE(), 1)
-- Period: 1, Career: 5
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (17, '2018 I, Maestría en Derecho de la Empresa, Ciclo I',						1, 5, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (18, '2018 I, Maestría en Derecho de la Empresa, Ciclo II',					1, 5, 2, GETDATE(), GETDATE(), 1)
-- Period: 1, Career: 6
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (19, '2018 I, Maestría en Gestión Minera y Ambiental, Ciclo I',				1, 6, 1, GETDATE(), GETDATE(), 1)
insert into CareerSchedule (Id, Description, PeriodId, CareerId, ModuleId, LastModified, Created, Status) values (20, '2018 I, Maestría en Gestión Minera y Ambiental, Ciclo II',				1, 6, 2, GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT CareerSchedule OFF