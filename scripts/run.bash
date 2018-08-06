#!/bin/bash

#SOURCE_URL=$1
#TARGET_PATH=$2
PROJECT_PATH=./iTaaS/AgoraLogger
SOURCE_URL="https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt"
TARGET_PATH="./../output/test.txt"

dotnet run --project $PROJECT_PATH $SOURCE_URL $TARGET_PATH
