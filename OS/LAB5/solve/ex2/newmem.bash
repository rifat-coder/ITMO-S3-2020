#!/bin/bash
declare -a array
declare -a numbers=(1,2,3,4,5,6,7,8,9,10)
rm -f report.log
step=0
if [[ $# == 0 ]]; then
	N=18600000
else
	N=$1
fi
while true
do
	array+=(${numbers[@]})
	let step++
	if [[ "${#array[@]}" > "$N" ]]; then
		echo "$N"
		exit 0
	fi
done
