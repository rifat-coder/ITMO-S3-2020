#!/bin/bash
while true
do
	read LINE
	
	case $LINE in
        	"TERM")
            		kill -SIGTERM $(cat .pid)
			exit
        		;;
        	"+")
            		kill -USR1 $(cat .pid)
			continue
        		;;
        	"*")
            		kill -USR2 $(cat .pid)
			continue
        		;;
    	esac
done
