#!/bin/bash
filename=$1
chname=0
if [ $# != 1 ]; then	
	exit 1 
fi
if [ -d $filename ]; then
        echo "Error it's folder"
        exit 1
fi
if [ ! -e $filename ]; then
	echo "Error file"
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
    let "$chname+=1" 
    trashname=$filename-$chname
done
ln -P $filename $trash/$trashname
rm $filename && echo $(realpath $filename) $trashname >> $trashlog
