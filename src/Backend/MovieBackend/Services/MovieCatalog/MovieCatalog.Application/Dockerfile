#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/MovieCatalog/MovieCatalog.Application/MovieCatalog.Application.csproj", "Services/MovieCatalog/MovieCatalog.Application/"]
COPY ["Services/MovieCatalog/MovieCatalog.Domain/MovieCatalog.Domain.csproj", "Services/MovieCatalog/MovieCatalog.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["Services/MovieCatalog/MovieCatalog.Infrastructure/MovieCatalog.Infrastructure.csproj", "Services/MovieCatalog/MovieCatalog.Infrastructure/"]
RUN dotnet restore "./Services/MovieCatalog/MovieCatalog.Application/./MovieCatalog.Application.csproj"
COPY . .
WORKDIR "/src/Services/MovieCatalog/MovieCatalog.Application"
RUN dotnet build "./MovieCatalog.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MovieCatalog.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir /app/storage
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieCatalog.Application.dll"]