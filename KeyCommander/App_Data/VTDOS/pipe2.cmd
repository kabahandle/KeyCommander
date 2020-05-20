@echo off
set pg=%1
shift

:next
if "%pg%"==":" (set pg="%pg% | "
) else if "%1"==":[" ( set pg="%pg% < "
) else if "%1"==":]" ( set pg="%pg% > "
) else (set pg=%pg% %1
)
shift
if "%1"=="" goto final
goto next

:final
cmd /c "%pg%"
