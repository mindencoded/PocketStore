-- Period: 1, Career: 1
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (1,  '2018 I, Administración de Negocios Internacionales, Ciclo I',				1, 1, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (2,  '2018 I, Administración de Negocios Internacionales, Ciclo II',				1, 1, 2, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (3,  '2018 I, Administración de Negocios Internacionales, Ciclo III',			1, 1, 3, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (4,  '2018 I, Administración de Negocios Internacionales, Ciclo IV',				1, 1, 4, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (5,  '2018 I, Administración de Negocios Internacionales, Ciclo V',				1, 1, 5, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (6,  '2018 I, Administración de Negocios Internacionales, Ciclo VI',				1, 1, 6, NOW(), NOW(), true);
-- Period: 1, Career: 2																								    
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (7,  '2018 I, Contabilidad, Ciclo I',											1, 2, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (8,  '2018 I, Contabilidad, Ciclo II',											1, 2, 2, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (9,  '2018 I, Contabilidad, Ciclo III',											1, 2, 3, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (10, '2018 I, Contabilidad, Ciclo IV',											1, 2, 4, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (11, '2018 I, Contabilidad, Ciclo V',											1, 2, 5, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (12, '2018 I, Contabilidad, Ciclo VI',											1, 2, 6, NOW(), NOW(), true);
-- Period: 1, Career: 3
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (13, '2018 I, Maestría en Administración de Negocios, Ciclo I',					1, 3, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (14, '2018 I, Maestría en Administración de Negocios, Ciclo II',					1, 3, 2, NOW(), NOW(), true);
-- Period: 1, Career: 4
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (15, '2018 I, Maestría en Gestión de Tecnologías de la Información, Ciclo I',	1, 4, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (16, '2018 I, Maestría en Gestión de Tecnologías de la Información, Ciclo II',	1, 4, 2, NOW(), NOW(), true);
-- Period: 1, Career: 5
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (17, '2018 I, Maestría en Derecho de la Empresa, Ciclo I',						1, 5, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (18, '2018 I, Maestría en Derecho de la Empresa, Ciclo II',						1, 5, 2, NOW(), NOW(), true);
-- Period: 1, Career: 6
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (19, '2018 I, Maestría en Gestión Minera y Ambiental, Ciclo I',					1, 6, 1, NOW(), NOW(), true);
INSERT INTO "dbo"."CareerSchedule" ("Id", "Description", "PeriodId", "CareerId", "ModuleId", "LastModified", "Created", "Status") VALUES (20, '2018 I, Maestría en Gestión Minera y Ambiental, Ciclo II',					1, 6, 2, NOW(), NOW(), true);
SELECT setval(pg_get_serial_sequence('"dbo"."CareerSchedule"', 'Id'), CAST((SELECT MAX("Id") FROM "dbo"."CareerSchedule") AS INTEGER));