@echo off
rem *************************************************
rem  Autoexec.bat for 220again
rem *************************************************
REM loadhigh C:\WINDOWS\nlsfunc.exe c:\country.sys
REM SET PATH=C:\PROGRA~1\NORTON~1;C:\PROGRA~1\BORLAND\CBUILDER\BIN
REM SET LMOUSE=C:\PROGRA~1\MOUSE

rem C:\dos220\fontn\fontnx /P=C:\dos220\font\
rem C:\dos220\dispv\dispvb
rem C:\dos220\chej\chej jp
rem C:\dos220\dispv\vmx 70

rem ADDDRV C:\ATOK.SYS
rem ADDDRV C:\ATOKA.SYS /UCF=c:\appli\ATOK8\ATOK8.UCF

rem atok.bat


rem LOADHIGH c:\DOS\NLSFUNC.EXE d:\COUNTRY.SYS

rem SET COMSPEC=c:\\COMMAND.COM /p /e:4096

rem COUNTRY=081,932,C:\dos220\DOS\COUNTRY.SYS
rem loadhigh c:\dos220\fontn\fontnx /p=c:\dos220\font\
loadhigh c:\dos220\fontn\fontnx /p=c:\dos220\dosemu\
rem loadhigh c:\dos220\DOS\$DISP.SYS /HS=lc
rem loadhigh c:\dos220\dispv\dispvb.exe /f1 /hs=all
loadhigh c:\dos220\dispv\dispvb.exe /f1 /hs=lc
LOADHIGH c:\dos220\DOS\NLSFUNC.c:\dos220\DOS\COUNTRY.SYS >nul
C:\dos220\dispv\vmx 70
c:\dos220\chej\chej jp

rem adddrv atok.sys

REM call dosime.bat

rem mngdev fep
c:\dos220\mngdev c:\dos220\atok
rem mngdev wxp.sys

@echo off
rem ------ 総合環境c
set ROOT=c:\dos220
set HOME=c:\dos220
set ZIP=z:
set CDROM=d:
set TMP=c:\dos220\tmp
set TMP=c:\dos220\tmp
set WORK=%TMP%
SET TZ=JST-9
set LOGNAME=KaBA
set PAGER=less

rem ------ PATH
PATH %ROOT%\usr;%ROOT%\bat;%ROOT%\dos;%ROOT%\mml\lsic\bin;D:\bin

rem ------- 補助環境
rem PROMPT [COM]$P$G
set VmtMode=70 80,34
set YGVIEWR=more
set pager=less
set 5dsp=%home%\dic\5tk
set editor=vz
set manpath=%root%\man
SET SCSI_UTILITY=%root%\util\ZIPTOOLS
set lsoptions=-cCF

rem ------ GNU-Win 環境
rem set GCC_EXEC_PREFIX = D:\sygnus\H-i386-cygwin32\lib\gcc-lib\
rem path %path%;d:\cygnus\H-i386-c\bin
rem path d:\cygnus\H-i386-cygwin32\bin;%path%

rem ------ Vz 環境
set vzdef=%ROOT%\vz\macro\kabaibm2.def
rem set vzdef=%ROOT%\vz\macro\kabaibm3.def
set vzbak=\trash
set vzdir=%ROOT%\vz
set vzpath=%ROOT% %ROOT%\home\work %ROOT%\vz\macro %ROOT%\term\ktx\pool %ROOT%\term\ktx\macro\autonif %HOME%\home\pim %ZIP%\log
set lxschd=/S:C:\dos220\pim\lxschd\ /D:c:\dos220\pim\lxschd\ /F:10 /A:+

rem ----- Ktx 環境
set autonif=%ROOt%\term\ktx\macro\autonif
set ledscr=%ROOT%\term\led\spt
set ledout=d:\log

rem ----- XTR 環境
rem set data=
rem set sedfile=%ROOT%\appli\xtr\tex2xtr
rem set xtrpath=%ROOT%\appli\xtr\macro

rem ----- Awk Environment
set awkpath=%ROOT%\bat\awk
set awklib=%ROOT%\bat\awk\awklib
set s2fmacro=%ROOT%\bat\awk
set s2fhostdb=%ROOT%\bat\awk

rem ----- TeX 環境
set go32=ansi handle 30
REM set TEXINPUTS=.;c:/appli/jtex/jmacros;c:/appli/jtex/macros
set go32TMP=c:\dos220\tmp
REM set TEXPOOL=c:/appli/jtex/bin
REM set TEXFORMATS=.;c:/appli/jtex/bin
REM set TEXFONTS=c:/appli/jtex/jfms;c:/appli/jtex/tfm
REM set TEXEDIT=edlin
rem set TEXEDIT=mifes %s+%d
rem ↑ エラーの際 E と入力したときに起動するエディタの指定。%s の部分にファイ
rem    ル名、%d の部分に行番号が代入されてエディタが起動されます。(注10)標準で
rem    はパスデリミタは \ に変換してエディタに渡されます。また、%S と大文字で
rem    書くとパスデリミタが / のままでエディタにわたされます。

rem ------ Dviout 環境
REM set TEXPK=c:\appli\jtex\pkfont\^d\^s.pk;c:\appli\jtex\jfms\^s.tfm
rem set TEXKNJ=c:\appli\jtex\jfonts\kanji^d.pk
REM set TEXCFG=c:\appli\jtex\bin

rem ------ TSR 環境 （Windows 起動時)
vwx -m1 -x3 -v3
rem mode con rate=32 delay=1

rem ------ TSR環境 （220Again起動時）
REM ctrlcaps
REM vfat

rem ------ goto HOME
cd %root%

REM ------ go into getty.bat pseudo login shell
rem getty.bat

rem %root%\ksh

rem %root%vz\vwx.com

cd %1
shift

%1 %2 %3 %4 %5 %6 %7 %8 %9
