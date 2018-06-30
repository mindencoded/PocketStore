INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (1,'Bachiller',NOW(), NOW(), true);
INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (2,'Pregrado',NOW(), NOW(), true);
INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (3,'Grado',NOW(), NOW(), true);
INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (4,'Postgrado',NOW(), NOW(), true);
INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (5,'Magíster',NOW(), NOW(), true);
INSERT INTO "dbo"."Degree" ("Id", "Description", "LastModified", "Created", "Status") VALUES (6,'PhD',NOW(), NOW(), true);
SELECT setval(pg_get_serial_sequence('"dbo"."Degree"', 'Id'), CAST((SELECT MAX("Id") FROM "dbo"."Degree") AS INTEGER));
