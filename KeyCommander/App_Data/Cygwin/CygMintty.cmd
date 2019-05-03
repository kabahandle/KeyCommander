@echo off

set APP=%1
shift
set APPPATH=%1
shift
cd %1
shift
set pg=%1
shift
(
	C:\cygwin64\bin\mintty.exe -e C:\cygwin64\bin\bash.exe --login -i -c "%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9" 2>1 | %APP% %APPPATH%
)

pause