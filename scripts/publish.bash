#!/bin/bash

SOLUTION_PATH=./iTaaS/
PROJECT_PATH=${SOLUTION_PATH}AgoraLogger

dotnet restore $SOLUTION_PATH

dotnet publish $PROJECT_PATH -c release -r ubuntu.16.10-x64
dotnet publish $PROJECT_PATH -c release -r win10-x64
