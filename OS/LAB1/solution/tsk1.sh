#!/bin/bash
max1=$1
for i in $2 $3
do
if [[ "${max1}" -lt "${i}" ]]
then
max1=${i}
fi
done
echo ${max1}
