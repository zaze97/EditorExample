#!/bin/sh

find ./ -name "*.mm" -or -name "*.m" -or -name "*.cs" -or -name "*.h" -or -name "*.hpp" -or -name "*.cpp" -or -name "*.lua" |xargs grep -v "^$"|wc -l