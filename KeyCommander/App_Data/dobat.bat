@echo off
cd /D %1

shift

:check
if "%1"=="" goto final
if "%1"=="""" goto final
set pg=%pg% %1
shift
goto check
:final

rem set pg=%1
rem shift

%pg% %1 %2 %3 %4 %5 %6 %7 %8 %9



