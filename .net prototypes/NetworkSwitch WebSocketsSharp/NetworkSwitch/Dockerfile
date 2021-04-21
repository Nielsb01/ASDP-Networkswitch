# AIM SD ASD 2020/2021 S2 project 
# Project name: ASD-project
# This file is created by team: 5	
# Goal of this file: Used to create a docker image

FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY bin/Release/net5.0 App/
WORKDIR /App
CMD ["NetworkSwitch.exe"]
EXPOSE 8088