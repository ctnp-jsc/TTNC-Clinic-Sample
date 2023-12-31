#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

RUN apt-get update && \
    apt-get -y install libfontconfig1

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", ""]
COPY ["Sample.Migrations/Sample.Migrations.csproj", "Sample.Migrations/"]
COPY ["Sample.Entities/Sample.Entities.csproj", "Sample.Entities/"]
COPY ["Sample/Sample.csproj", "Sample/"]
RUN dotnet restore "Sample/Sample.csproj"
COPY . .
WORKDIR "/src/Sample"
RUN dotnet build "Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.dll"]
