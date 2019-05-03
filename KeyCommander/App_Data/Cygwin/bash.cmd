@echo off
cd /d %1
shift
%cygwinbinpath%\bash  --login -i -c "%1 %2 %3 %4 %5 %6 %7 %8 %9"

