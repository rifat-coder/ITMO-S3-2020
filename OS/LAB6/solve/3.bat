@echo off
net stop Dnscache
timeout /t 10 /nobreak
net start > secondScan.txt
fc /a /t /c firstScan.txt secondScan.txt > different3.txt
net start Dnscache