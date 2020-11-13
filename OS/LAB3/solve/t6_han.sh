#!/bin/bash
echo $$ > .pid
answer=1

term() {
	echo "Stop by generator"
	exit
}

usr1() {
	op="+"
}

usr2() {
	op="*"
}

trap 'usr1' USR1
trap 'usr2' USR2
trap 'term' SIGTERM
while true; do
	case $op in
		"+") 
			let "answer+=2"
			echo $answer 
			;;
		"*") 
			let "answer*=2"
			echo $answer 
			;;
	esac
	sleep 1
done
