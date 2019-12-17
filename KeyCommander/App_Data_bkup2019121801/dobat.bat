rem @echo off
set drv=%1
shift
cd %1
shift
set pg=%1
shift
%drv%
%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9
pause


