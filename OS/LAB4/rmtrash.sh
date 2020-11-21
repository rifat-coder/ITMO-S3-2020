#!/bin/bash
filename=$1
chname=0
if [ $# != 1 ]; then	
	exit 1 
fi
trash=~/.trash
trashlog=~/.trash.log
if [ ! -d $trash ]; then 
	mkdir $trash 
fi
if [ ! -f $trashlog ]; then
	touch $trashlog
fi
trashname=$filename
while [ -f $trash/$trashname ]
do
    (( chname++ ))
    trashname=$filename-$chname
done
ln -P $filename $trash/$trashname
rm $filename && echo $(realpath $filename) $trashname >> $trashlog
