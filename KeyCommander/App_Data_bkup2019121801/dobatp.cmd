rem @echo off
set drv=%1
echo drv = %drv%
shift
cd %1
cd
pause
shift
set pg=%1
shift
(
	%drv%
	%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9
)
pause
