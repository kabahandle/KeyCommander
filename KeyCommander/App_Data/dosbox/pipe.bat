@echo off

set pg=

rem command.com /c %1 | %2
rem shdos16 -c "%1 | %2"

:check
if "%1"=="" goto final
if "%1"=="""" goto final
set pg=%pg% %1
shift
goto check
:final

echo shdos16.exe -c "pipe.sh %pg%"
shdos16.exe -c "pipe.sh %pg%"

set pg=

