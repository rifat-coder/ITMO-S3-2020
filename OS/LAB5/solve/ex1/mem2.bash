#!/bin/bash
declare -a array
declare -a numbers=(1,2,3,4,5,6,7,8,9,10)
rm -f report2.log
step=0
while true
do
	array+=(${numbers[@]})
	let step++
	if [[ $step == 100000 ]]; then
		echo "${#array[@]}" >> report2.log
		step=0
	fi
done
