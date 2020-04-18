sc create CoreAPI binPath= "%~dp0CoreAPI.exe"
sc failure CoreAPI actions= restart/10000/restart/20000/""/60000 reset= 86400
sc start CoreAPI
sc config CoreAPI start=auto

pause