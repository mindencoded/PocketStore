INSERT INTO "dbo"."Period" ("Id", "Description", "StartDate", "EndDate", "LastModified", "Created", "Status") VALUES (1, '2018 I', NULL, NULL, NOW, NOW, true);
SELECT setval(pg_get_serial_sequence('"dbo"."Period"', '"Id"'), CAST((SELECT MAX("Id") FROM "dbo"."Period") AS INTEGER));

