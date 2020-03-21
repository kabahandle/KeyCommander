set d=%1
set pg="%dosboxbindir%\exec.bat" %1 %2 %3 %4 %5 %6 %7 %8 %9
rem c:\dos220\dosbox.exe -noautoexec -conf "c:\dos220\dosbox.conf" -c "mount c c:\\"  -c "c:"  -c "c:\dos220\chej\chej jp" -c "mount d c:\cygwin64" -c "c:"  -c "%pg%"
rem c:\dos220\dosbox.exe  -conf "c:\dos220\dosbox.conf" -c "mount c c:\\"  -c "cd c:\dos220" -c "c:\dos220\chej\chej jp" -c "mount d c:\cygwin64" -c "c:"  -c "%pg%"
%dosboxbindir%\dosbox.exe  -conf "c:\dos220\dosbox.conf" -c "mount c c:\\"  -c "cd c:\dos220" -c "c:\dos220\chej\chej jp" -c "mount d c:\cygwin64" -c "cd /d %d%"  -c "%pg%"

