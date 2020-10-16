#!/bin/bash
for i in $(ps -a -x -o pid | tail -n +2)
do
	VmSize = $(readlink /proc/$i/status | grep -E -h -i "VMSIZE" | grep -E -s -o "[0-9]\+")
	if [[ -z $VmSize ]]
	then
		VmSize=0
	else
		echo $i " " $VmSize
	fi	
done | sort -k2 | tail -n 1 > at6.txt
top 
