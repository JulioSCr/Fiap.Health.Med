#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Fiap.Health.Med.API/Fiap.Health.Med.Api.csproj", "Fiap.Health.Med.API/"]
COPY ["Fiap.Health.Med.Application/Fiap.Health.Med.Application.csproj", "Fiap.Health.Med.Application/"]
COPY ["Fiap.Health.Med.Domain/Fiap.Health.Med.Domain.csproj", "Fiap.Health.Med.Domain/"]
COPY ["Fiap.Health.Med.Infrastructure/Fiap.Health.Med.Infrastructure.csproj", "Fiap.Health.Med.Infrastructure/"]
RUN dotnet restore "Fiap.Health.Med.API/Fiap.Health.Med.Api.csproj"

COPY . . 
WORKDIR "/src/Fiap.Health.Med.API"
RUN dotnet build "./Fiap.Health.Med.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fiap.Health.Med.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 4040
ENV ASPNETCORE_URLS=http://*:4040
ENTRYPOINT ["dotnet", "Fiap.Health.Med.Api.dll"]
