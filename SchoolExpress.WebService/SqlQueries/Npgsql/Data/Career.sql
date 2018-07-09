INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (1, 'Administración de Negocios Internacionales', 3, NOW(), NOW(), true);
INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (2, 'Contabilidad', 3, NOW(), NOW(), true);
INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (3, 'Maestría en Administración de Negocios (MBA Internacional)', 5, NOW(), NOW(), true);
INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (4, 'Maestría en Gestión de Tecnologías de la Información', 5, NOW(), NOW(), true);
INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (5, 'Maestría en Derecho de la Empresa', 5, NOW(), NOW(), true);
INSERT INTO "dbo"."Career"("Id", "Description", "DegreeId", "LastModified", "Created", "Status") VALUES (6, 'Maestría en Gestión Minera y Ambiental', 5, NOW(), NOW(), true);
SELECT setval(pg_get_serial_sequence('"dbo"."Career"', 'Id'), CAST((SELECT MAX("Id") FROM "dbo"."Career") AS INTEGER));