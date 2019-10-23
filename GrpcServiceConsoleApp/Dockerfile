FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
EXPOSE 6003

COPY . .
ENTRYPOINT ["dotnet", "GrpcServiceConsoleApp.dll"]