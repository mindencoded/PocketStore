CREATE OR REPLACE FUNCTION restart_sequence(name CHAR(150)) RETURNS void AS $$
DECLARE result RECORD;
  DECLARE _sequence VARCHAR(100);
BEGIN
  FOR result IN SELECT table_schema, table_name, column_name  FROM information_schema.columns WHERE column_default LIKE 'nextval%' AND table_name = name LOOP
    SELECT pg_get_serial_sequence(format('"%1$s"."%2$s"', result.table_schema, result.table_name), result.column_name) INTO _sequence;
    EXECUTE format('ALTER SEQUENCE %s RESTART WITH 1;', _sequence);
  END LOOP;
END;
$$ LANGUAGE plpgsql;

--SELECT restart_sequence('UserClaim');

