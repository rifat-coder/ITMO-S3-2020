#!/bin/bash
if [[ "${PWD}" =~ /home/user* ]]; then
	echo ${PWD}
	exit 0
fi
echo "Error from User"
exit 1
