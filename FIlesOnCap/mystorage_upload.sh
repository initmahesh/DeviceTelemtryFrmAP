#!/bin/bash
# A simple Azure Storage example to upload a file 
export AZURE_STORAGE_ACCOUNT=<Replace this with your account> eg. yadavsrorageaccount01    
export AZURE_STORAGE_ACCESS_KEY=<Replace thsi with your access key> 
export container_name= <Replace with your container name> eg. mytestcap
export file_to_upload=<point to file that you want to upload>  eg. ~/iot-edge/MyIoTfileupload/Filegenration/mytest/finallog.txt
azure storage blob upload --file $file_to_upload --container $container_name -q
azure storage blob list --container $container_name
