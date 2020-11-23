#!/bin/bash
filename=$1
recover() {
    path=$1
    file=$2
    ln $trash/$file $path
}
if [ $# != 1 ]; then
    exit 1
fi
trash=~/.trash
trashlog=~/.trash.log
if [ ! -f $trashlog ]; then
    exit 1
fi
if [ ! -d $trash ]; then
    exit 1
fi
grep $filename $trashlog |
while read filepath; do
    file=$(echo $filepath | cut -d " " -f 1)
    trashed=$(echo $filepath | cut -d " " -f 2)
    echo "Do you want to recover $trashed? (yes/no)"
    read answer < /dev/tty
    if [ $answer == "yes" ]; then
        dir=$(dirname $file) &&
        if [ -d $dir ]; then
            $(recover $file $trashed)
        else
            $(recover $HOME/$filename $trashed) &&
            echo "recover in $HOME"
        fi &&
        rm $trash/$trashed && {
            sed -i "#$filepath#d" $trashlog
            echo "recover $file"
        }
    fi
done
