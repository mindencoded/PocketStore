@ECHO OFF
netsh.exe http delete sslcert ipport="0.0.0.0:444"
PAUSE