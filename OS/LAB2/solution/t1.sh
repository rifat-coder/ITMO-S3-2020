#!/bin/bash
ps -u $USER -o pid,command -a | wc --lines > out-t1.txt; ps -u $USER -o pid,command -a | awk '{printf $1 " " $2 "\n"}' >> out-t1.txt
cat out-t1.txt
