sc create ServiceAPI binPath= "%~dp0WebCLI.exe"
sc failure ServiceAPI actions= restart/10000/restart/10000/""/10000 reset= 86400
sc start ServiceAPI 
sc config ServiceAPI start=auto

pause