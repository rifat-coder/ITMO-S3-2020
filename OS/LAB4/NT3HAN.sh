#!/bin/bash
rm -f a.log
echo $$ > parpid
mode="good"
not_good(){
	mode="not"
}
trap 'not_good' USR1
while true;
do
	case $mode in
		"good")
			echo "GOOD" >> a.log
			;;
		"not")
			echo "Not good" >> a.log
			exit 1
			;;
	esac
	sleep 1
done
