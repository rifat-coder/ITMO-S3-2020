#!/bin/bash
for i in $(ps -a -o pid | tail -n +2)
do
	VmSize = $(grep -E -h -i "vmsize" /proc/$i/status | grep -E -h -i "VMSIZE" | grep -o "[0-9]\+")
	if [[ -z $VmSize ]]
	then
		VmSize=0
	else
		echo $i ":" $VmSize
	fi	
done | sort -k2 -V | tail -n 1 > at6.txt
top -b -o +VIRT | head -n 10 | tail -n 1 >> at6.txt
cat at6.txt
