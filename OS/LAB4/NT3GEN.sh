#!/bin/bash
while true; do
	if [[ $(cat a.log | wc -l) -gt 10 ]]
	then
		kill -USR1 $(cat parpid)
		exit 1
	fi
done
