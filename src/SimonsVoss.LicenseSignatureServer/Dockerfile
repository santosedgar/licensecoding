# Application build steps
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as builder

WORKDIR /src

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /published SimonsVoss.LicenseSignatureServer/SimonsVoss.LicenseSignatureServer.csproj

# Runtime image creation
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Uncomment the line below if running with HTTPS
# ENV ASPNETCORE_URLS=http://*:$PORT

WORKDIR /app

COPY --from=builder /published .

ENTRYPOINT [ "dotnet", "SimonsVoss.LicenseSignatureServer.dll" ]