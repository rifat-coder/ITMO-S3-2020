#!/bin/bash
K=10
N=186000000
for i in $(seq 1 $K); do
	./newmem.bash $N&
done
