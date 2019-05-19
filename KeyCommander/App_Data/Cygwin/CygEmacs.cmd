@echo off
set pg=emacs %1 %2 %3 %4 %5 %6 %7 %8 %9

%cygwinbinpath%\mintty.exe -e "C:\cygwin64-3\bin\bash.exe" --login -i -c "%pg%"
