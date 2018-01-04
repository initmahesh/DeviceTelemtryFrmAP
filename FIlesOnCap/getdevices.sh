cd /root/iot-edge/MyIoTfileupload/Filegenration/mytest
if cmp -s ./finallog.txt ./backuplog.txt
then
	echo "No new device detected no action needed"
else
	echo "Calling script to upload to cloud"
	./mystorage_upload.sh
fi
cp ./finallog.txt ./backuplog.txt
arp-scan --interface=wlan0 --localnet |grep "192" >./log.txt
sort ./log.txt  ./backuplog.txt | uniq >./finallog.txt
# if cmp -s ./finallog.txt ./backuplog.txt
# then
#	echo "No new device detected no action needed"
#else
#	echo "Calling script to upload to cloud"
#	./mystorage_upload.sh
#fi
cd /