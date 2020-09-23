#!/bin/bash
txt=""
arr=()
while ( [ "${txt}" != "q" ] ) do
	read txt
	arr+=( ${txt} )
done
echo ${arr[@]}
