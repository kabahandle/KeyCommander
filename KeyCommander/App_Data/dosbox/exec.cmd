rem cd /d %1
set d=%1
rem set d=%~f1
set d=%~sf1
rem refURL: http://simple.hatenablog.jp/entry/BAT/002
set drv=%~d1
shift

set pg="c:\dos220\exec.bat" %d% %1 %2 %3 %4 %5 %6 %7 %8 %9
rem D:\220again_dosbox\dos220\dosbox.exe -c "mount c d:\220again_dosbox" -c "mount d d:\\" -c "c:"  -c "%pg%
rem c:\220again\dos220\dosbox.exe -noautoexec -conf "c:\220again\dos220\dosbox.conf" -c "mount c c:\220again" -c "c:\dos220\chej\chej jp" -c "mount d c:\\cygwin-3" -c "c:"  -c "%pg%"
c:\220again\dos220\dosbox.exe -noautoexec -conf "c:\220again\dos220\dosbox.conf" -c "mount c c:\220again" -c "c:\dos220\chej\chej jp" -c "mount d m:\\cygwin64" -c "mount m m:\ " -c "mount g g:\ " -c " %drv% " -c "cd %d% " -c "%pg%"
