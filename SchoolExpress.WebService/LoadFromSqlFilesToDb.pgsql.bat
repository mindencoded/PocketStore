@ECHO off
chcp 65001 > nul
FOR /F "eol=; tokens=1* delims==" %%i IN (sqlparams.conf) DO SET %%i=%%j
IF .%DataSources%.==.. SET DataSources=%CD%\DataSources\Npgsql\Sql
SET PGPASSWORD=%Password%
(
    @ECHO off
    ECHO CREATE OR REPLACE FUNCTION restart_sequence^^^(name CHAR^^^(150^^^)^^^) RETURNS void AS $$
    ECHO DECLARE result RECORD;
    ECHO DECLARE _sequence VARCHAR^^^(100^^^);
    ECHO BEGIN
    ECHO FOR result IN SELECT table_schema, table_name, column_name  FROM information_schema.columns WHERE column_default LIKE 'nextval%%' AND table_name = name LOOP
    ECHO SELECT pg_get_serial_sequence^^^(format^^^('"%%1$s"."%%2$s"', result.table_schema, result.table_name^^^), result.column_name^^^) INTO _sequence;
    ECHO EXECUTE format^^^('ALTER SEQUENCE %%s RESTART WITH 1;', _sequence^^^);
    ECHO END LOOP;
    ECHO END;
    ECHO $$ LANGUAGE plpgsql;
    ECHO CREATE OR REPLACE FUNCTION set_sequence^^^(name CHAR^^^(150^^^)^^^) RETURNS void AS $$ 
    ECHO DECLARE result RECORD; 
    ECHO BEGIN 
    ECHO FOR result IN SELECT table_schema, table_name, column_name FROM information_schema.columns WHERE column_default LIKE 'nextval%%' AND table_name = name LOOP 
    ECHO EXECUTE format^^^('SELECT setval^^^(pg_get_serial_sequence^^^(''"%%1$s"."%%2$s"'', ''%%3$s''^^^), CAST^^^(^^^(SELECT MAX("%%3$s"^^^) FROM "%%1$s"."%%2$s"^^^) AS INTEGER^^^)^^^);', result.table_schema, result.table_name, result.column_name ^^^); 
    ECHO END LOOP;
    ECHO END; 
    ECHO $$ LANGUAGE plpgsql;
    FOR %%a in (%Names%) DO (
        ECHO SELECT restart_sequence^^^('%%a'^^^);
        type %DataSources%\%%a.sql
        ECHO SELECT set_sequence^^^('%%a'^^^);
    )
) | psql -h %Server% -p 5432 -d %Database% -U %Username% -w

    
   




   

   