#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Torc.Challenge.Api/Torc.Challenge.Api.csproj", "Torc.Challenge.Api/"]
COPY ["Torc.Challenge.Application.IoC/Torc.Challenge.Application.IoC.csproj", "Torc.Challenge.Application.IoC/"]
COPY ["Torc.Challenge.Application/Torc.Challenge.Application.csproj", "Torc.Challenge.Application/"]
COPY ["Torc.Challenge.Application.Interfaces/Torc.Challenge.Application.Interfaces.csproj", "Torc.Challenge.Application.Interfaces/"]
COPY ["Torc.Challenge.Infrastructure/Torc.Challenge.Infrastructure.csproj", "Torc.Challenge.Infrastructure/"]
COPY ["Torc.Challenge.Infrastructure.Interfaces/Torc.Challenge.Infrastructure.Interfaces.csproj", "Torc.Challenge.Infrastructure.Interfaces/"]
COPY ["Torc.Challenge.Domain/Torc.Challenge.Domain.csproj", "Torc.Challenge.Domain/"]
COPY ["Torc.Challenge.Infrastructure.IoC/Torc.Challenge.Infrastructure.IoC.csproj", "Torc.Challenge.Infrastructure.IoC/"]
RUN dotnet restore "./Torc.Challenge.Api/Torc.Challenge.Api.csproj"
COPY . .
WORKDIR "/src/Torc.Challenge.Api"
RUN dotnet build "./Torc.Challenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Torc.Challenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Torc.Challenge.Api.dll"]