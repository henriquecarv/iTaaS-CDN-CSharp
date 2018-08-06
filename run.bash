#!/bin/bash

#SOURCEURL=$1
#TARGETPATH=$2

SOURCEURL="https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt"
TARGETPATH="./../output/test.txt"
cd iTaaS && dotnet run --project ConsoleLog/ $SOURCEURL $TARGETPATH