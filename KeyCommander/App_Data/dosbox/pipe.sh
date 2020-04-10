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

shdos16 -c "${CMDLINE}"

