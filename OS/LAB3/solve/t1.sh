#!/bin/bash
mkdir -p ~/test && 
{
	echo "catalog test was created successfully" > ~/report
	touch ~/test/$(date +'%d-%m-%y_%H:%M:%S')
}	
ping -c 1 www.net_nikogo.ru || echo "$(date +'%d-%m-%y_%H:%M:%S') Host is not available!" >> ~/report
