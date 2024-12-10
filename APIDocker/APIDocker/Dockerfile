FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["APIDocker.csproj", "."]

RUN dotnet restore "./APIDocker.csproj"
COPY . .
WORKDIR "/src/."

RUN dotnet build "APIDocker.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "APIDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# WORKDIR /app/publish
ENV ASPNETCORE_URLS: http://+:5000
ENTRYPOINT ["dotnet", "APIDocker.dll"]