INSERT INTO "dbo"."ClassRoom" ("Id", "Description", "CampusId", "LastModified", "Created", "Status") VALUES (1, '101', 1, NOW(), NOW(), true);
INSERT INTO "dbo"."ClassRoom" ("Id", "Description", "CampusId", "LastModified", "Created", "Status") VALUES (2, '102', 1, NOW(), NOW(), true);
INSERT INTO "dbo"."ClassRoom" ("Id", "Description", "CampusId", "LastModified", "Created", "Status") VALUES (3, '103', 1, NOW(), NOW(), true);
INSERT INTO "dbo"."ClassRoom" ("Id", "Description", "CampusId", "LastModified", "Created", "Status") VALUES (4, '201', 1, NOW(), NOW(), true);
INSERT INTO "dbo"."ClassRoom" ("Id", "Description", "CampusId", "LastModified", "Created", "Status") VALUES (5, '202', 1, NOW(), NOW(), true);
SELECT setval(pg_get_serial_sequence('"dbo"."ClassRoom"', 'Id'), CAST((SELECT MAX("Id") FROM "dbo"."ClassRoom") AS INTEGER));