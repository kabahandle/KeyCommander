@echo off
cd /d %1
shift
%cygwinbinpath%\mintty.exe -h always -e %cygwinbinpath%\bash -i -t -c "%1 %2 %3 %4 %5 %6 %7 %8 %9"
rem %cygwinbinpath%\mintty.exe -h always -e %cygwinbinpath%\bash  --login -i -c "cd %1"
rem %cygwinbinpath%\mintty.exe -h always -e %cygwinbinpath%\bash --login -i -t -c "%1 %2 %3 %4 %5 %6 %7 %8 %9"

