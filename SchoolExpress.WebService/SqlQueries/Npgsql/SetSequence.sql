CREATE OR REPLACE FUNCTION set_sequence(name CHAR(150)) RETURNS void AS $$
DECLARE result RECORD;
BEGIN
  FOR result IN SELECT table_schema, table_name, column_name  FROM information_schema.columns WHERE column_default LIKE 'nextval%' AND table_name = name LOOP
    EXECUTE format('SELECT setval(pg_get_serial_sequence(''"%1$s"."%2$s"'', ''%3$s''), CAST((SELECT MAX("%3$s") FROM "%1$s"."%2$s") AS INTEGER));', result.table_schema, result.table_name, result.column_name );
  END LOOP;
END;
$$ LANGUAGE plpgsql;