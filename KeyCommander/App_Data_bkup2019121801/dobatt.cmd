rem @echo off
set drv=%1
shift
set APP=%1
shift
set APPPATH=%1
shift
rem cd %1
shift
set pg=%1
shift
(
	%drv%
	%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9 2>1 | %APP% %APPPATH%
)

