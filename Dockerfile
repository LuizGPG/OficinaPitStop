FROM mcr.microsoft.com/dotnet/core/sdk:2.2

LABEL version="1.0" maintainer="LuizGuimaraes"

WORKDIR /app

COPY ./OficinaPitStop.Api/.dist .

ENTRYPOINT ["dotnet","OficinaPitStop.Api.dll"]