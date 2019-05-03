@echo off
rem cd /d %1
rem shift
c:\cygwin64-3\bin\mintty.exe -h always -e %cygwinbinpath%\bash  --login -i -c "%1 %2 %3 %4 %5 %6 %7 %8 %9"
rem c:\cygwin64-3\bin\mintty.exe -h always -e %cygwinbinpath%\bash --login -i -t -c "%1 %2 %3 %4 %5 %6 %7 %8 %9"


