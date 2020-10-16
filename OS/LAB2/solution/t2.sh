#!/bin/bash
#!/bin/bash
"" > at2.txt
for i in $(ps -a -x -o pid | tail -n +2)
do
	readlink /proc/$i/exe | grep "/sbin" | awk '{printf("%s\n", $1)}'>> at2.txt
done
cat at2.txt
