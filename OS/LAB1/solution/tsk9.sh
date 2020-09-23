#!/bin/bash
awk 'BEGIN{cl=0}{cl+=$1}END{print(cl)}' /var/log/*\.log
