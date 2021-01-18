@echo off
driverquery /fo table /nh /v > drivers.txt
sort /r drivers.txt /o driversSorted.txt