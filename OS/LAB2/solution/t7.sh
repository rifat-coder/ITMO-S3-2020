#!/bin/bash 
(for i in $(ls /proc | grep "[0-9]") 
do 
awk '$1 == "rchar:" {print "%d ", $2}' /proc/$i/io » term1.info 
cmd=$(ps -e -o pid,cmd | awk -v id=$i '$1 == id {print $2}') 
echo $i $cmd » term1.info 
done 
sleep 60 
for i in $(ls /proc | grep "[0-9]") 
do 
awk '$1 == "rchar:" {print "%d ", $2}' /proc/$i/io » term2.info 
echo $i » term2.info 
done 
while read str 
do 
pid=$(echo $str | awk '{print $2}') 
mem=$(echo $str | awk '{print $1}') 
awk -v id=$pid -v m=$mem '{if ($2 == id) {printf "PID %d : CMD %s : Memory %d ", $2, $3, m-$1; print "\n"}}' term1.info » term3.info 
done < term2.info 
sort -n -k 8 | tail -n 3 | sort -n -k 8 
rm *.info 
) 2> /dev/null
