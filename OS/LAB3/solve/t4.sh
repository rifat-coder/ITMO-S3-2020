#!/bin/bash
./4_1.sh &
pid0=$!
./4_2.sh &
pid1=$!
./4_3.sh & 
pid2=$!
renice 10 -p $pid0
kill $pid2
