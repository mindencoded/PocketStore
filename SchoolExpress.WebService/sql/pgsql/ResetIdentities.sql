ALTER SEQUENCE "dbo"."Campus_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."ClassRoom_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Module_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Period_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Degree_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Course_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Career_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."CareerDetail_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Person_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Speaker_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Student_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."CareerSchedule_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."CareerScheduleDetail_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."Enrollment_Id_seq" RESTART WITH 1;
ALTER SEQUENCE "dbo"."UserClaim_Id_seq" RESTART WITH 1;


SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Campus"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Campus") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."ClassRoom"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."ClassRoom") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Module"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Module") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Period"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Period") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Degree"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Degree") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Course"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Course") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Career"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Career") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."CareerDetail"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."CareerDetail") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Person"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Person") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Speaker"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Speaker") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Student"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Student") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."CareerSchedule"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."CareerSchedule") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."CareerScheduleDetail"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."CareerScheduleDetail") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."Enrollment"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."Enrollment") AS INTEGER));
SELECT setval((SELECT pg_get_serial_sequence('"dbo"."UserClaim"', 'Id')), CAST((SELECT MAX("Id") FROM "dbo"."UserClaim") AS INTEGER));
 
