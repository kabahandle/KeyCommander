set d=%1
rem RefURL:  http://simple.hatenablog.jp/entry/BAT/002
set drv=%~d1
shift

set pg="c:\dos220\exec.bat" %1 %2 %3 %4 %5 %6 %7 %8 %9
rem D:\220again_dosbox\dos220\dosbox.exe -c "mount c d:\220again_dosbox" -c "mount d d:\\" -c "c:"  -c "%pg%
rem c:\220again\dos220\dosbox.exe -noautoexec -conf "c:\220again\dos220\dosbox.conf" -c "mount c c:\220again" -c "c:\dos220\chej\chej jp" -c "mount d c:\\cygwin-3" -c "c:"  -c "%pg%"
c:\220again\dos220\dosbox.exe -conf "c:\\220again\\dos220\\dosbox.conf" -c "mount c c:\\220again" -c "c:\\dos220\\chej\\chej jp" -c "mount d m:\\cygwin64" -c "mount m m:\\ " -c " %drv% " -c "cd %d% " -c "%pg%"
