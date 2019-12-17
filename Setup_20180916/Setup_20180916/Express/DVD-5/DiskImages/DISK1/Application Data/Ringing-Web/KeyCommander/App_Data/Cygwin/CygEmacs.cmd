@echo off
set pg=emacs %1 %2 %3 %4 %5 %6 %7 %8 %9

rem C:\cygwin64\bin\bash --login -i -c "%pg%"
rem C:\cygwin643\bin\mintty.exe -e "%pg%"
C:\cygwin64\bin\mintty.exe -e "D:\cygwin64\bin\bash.exe" --login -i -c "%pg%"
