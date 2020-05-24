#!/bin/bash
CMDLINE=""
while [ "$1" != "" ]
do
  if [ "$1" = ":" ] ; then
      CMDLINE="${CMDLINE} | "
  elif [ "$1" = ":[" ] ; then
    CMDLINE="${CMDLINE} < "
  elif [ "$1" = ":]" ] ; then 
        CMDLINE="${CMDLINE} > "
  else
      CMDLINE="${CMDLINE} $1"
  fi
  shift
done

#bash.exe -c "\"${CMDLINE}"\"
#echo bash.exe -c "\"${CMDLINE}"\"
cmd /c "${CMDLINE}"
echo cmd /c "${CMDLINE}"
