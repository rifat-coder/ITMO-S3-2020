#!/bin/bash
echo $$ > .pid1
declare -a array
declare -a numbers=(1,2,3,4,5,6,7,8,9,10)
step=0
while true
do
	array+=(${numbers[@]})
	let step++
	if [[ $step == 1000000 ]]; then
		echo "${#array[@]}" >> report.log
		step=0
	fi
done
