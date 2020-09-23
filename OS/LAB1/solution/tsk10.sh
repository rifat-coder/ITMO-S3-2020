#!/bin/bash
man bash | grep --ignore-case --only-matching "[a-z]\{4,\}" | sort | uniq -c | sort -rn | head -3 | awk '{print($2)}'
