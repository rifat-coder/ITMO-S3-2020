#!/bin/bash
op="+"
answer=1
(tail -f queue) |
while true
do
	read LINE
	if [[ $LINE == "QUIT" ]]
	then
		echo "exit"
		killall tail
		exit
	elif [[ $LINE == "ERROR" ]] 
	then
		echo "Error! Not a number hand file"
		exit 1
	fi
	case $LINE in
		QUIT)
			echo "exit"
                	killall tail
                	exit
			;;
		ERROR)
			echo "Error! Not a number hand file"
                	exit 1
			;;
		"+")
            		op="+"
        		;;
        	"*")
            		op="*"
        		;;
		[0-9]*)
            		case $op in
                		"+")
                    			let "answer+=$LINE"
                			;;
                		"*")
                    			let "answer+=$LINE"
                			;;
            		esac
            		echo $answer
        		;;
        	*)
            		kill -9 $$
            		exit 1
        ;;
    esac


done
