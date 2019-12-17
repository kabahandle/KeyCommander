set pg="c:\dos220\exec.bat" %1 %2 %3 %4 %5 %6 %7 %8 %9
c:\dos220\dosbox.exe -noautoexec -conf "c:\dos220\dosbox.conf" -c "mount c c:\\"  -c "c:"  -c "c:\dos220\chej\chej jp" -c "mount d c:\cygwin64-3" -c "c:"  -c "%pg%"
