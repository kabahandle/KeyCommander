while [ "$1" != "" ]
do
  if [ "$1" != ":" ] ; then
  	CMDLINE="${CMDLINE} $1"
  else
  	CMDLINE="${CMDLINE} | "
  fi
  shift
done

shdos16 -c "${CMDLINE}"

