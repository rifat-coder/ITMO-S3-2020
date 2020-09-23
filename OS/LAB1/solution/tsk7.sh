#!/bin/bash
egrep -i -o -s --binary-files=without-match -h "[a-z0-9.-_]+@[a-z0-9.-_]+\.[a-z]+" -r /etc/ | uniq | awk '{ printf("%s, ", $1 ) }' | sed 's/..$//' > emails.lst
