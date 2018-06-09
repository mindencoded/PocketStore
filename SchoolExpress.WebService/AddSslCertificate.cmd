@ECHO OFF
netsh.exe http add sslcert ipport="0.0.0.0:444" certhash="%1" appid="{B902CE2E-5272-4678-A3C7-959A1DEF0B65}"
PAUSE