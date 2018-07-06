@ECHO OFF
netsh.exe http add urlacl url="https://+:444/" user="Servicio Local"
PAUSE