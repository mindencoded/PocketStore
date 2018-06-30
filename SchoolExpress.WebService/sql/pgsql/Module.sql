INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (1, 'Ciclo I',   NOW(), NOW(), true);
INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (2, 'Ciclo II',  NOW(), NOW(), true);
INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (3, 'Ciclo III', NOW(), NOW(), true);
INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (4, 'Ciclo IV',  NOW(), NOW(), true);
INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (5, 'Ciclo V',   NOW(), NOW(), true);
INSERT INTO "dbo"."Module" ("Id", "Description", "LastModified", "Created", "Status") VALUES (6, 'Ciclo VI',  NOW(), NOW(), true);
SELECT setval(pg_get_serial_sequence('"dbo"."Module"', '"Id"'), CAST((SELECT MAX("Id") FROM "dbo"."Module") AS INTEGER));
