@echo off
set APP=%1
shift
set APPPATH=%1
shift
cd /D %1
shift
set pg=%1
shift
(
	%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9 2>1 | %APP% %APPPATH%
)


pause