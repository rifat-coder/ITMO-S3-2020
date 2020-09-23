#!/bin/bash
set -e
function menu() {
	echo -e "\t1) start nano"
	echo -e "\t2) start vi"
	echo -e "\t3) start links"
	echo -e "\t4) exit"
}
menu
read -n 1 command
case "${command}" in
	"1" ) nano;;
	"2" ) vi;;
	"3" ) links;;
	"4" ) exit;;
esac
