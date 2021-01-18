@echo off
forfiles /S /P "C:\Windows" /C "cmd /c if @fsize GEQ 2097152 copy @path C:\IEWIN7\temp /Z /Y"