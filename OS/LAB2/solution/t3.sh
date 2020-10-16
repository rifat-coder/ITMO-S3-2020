#!/bin/bash
"" > at3.txt
ps -a -o pid,start | sort -n -k 2 | tail -n 1 >> at3.txt
cat at3.txt
