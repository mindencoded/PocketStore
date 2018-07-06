@ECHO OFF
netsh.exe http delete urlacl url="https://+:444/"
PAUSE