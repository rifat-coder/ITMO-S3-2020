#!/bin/bash
rm -f queue
mkfifo queue
while true; do
	read LINE
	
	if [[ $LINE == "QUIT" ]]
	then
		echo $LINE > queue
		echo "QUIT gen file"
		kill -9 $$
	fi

	if [[ $LINE != "+" && $LINE != "*" && ! $LINE =~ [0-9]+ ]]
	then
		echo "ERROR" > queue
		echo "Error! Not a number gen file"
		kill -9 $$
	fi

	echo $LINE > queue
done
