#!/bin/bash
at now + 1 minutes -f ./t1.sh
tail -n 0 -f ~/report
