FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
EXPOSE 6001

COPY . .
ENTRYPOINT ["dotnet", "GrpcService.dll"]