#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/MovieRating/MovieRating.Application/MovieRating.Application.csproj", "Services/MovieRating/MovieRating.Application/"]
COPY ["Services/MovieRating/MovieRating.Domain/MovieRating.Domain.csproj", "Services/MovieRating/MovieRating.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["Services/MovieRating/MovieRating.Infrastructure/MovieRating.Infrastructure.csproj", "Services/MovieRating/MovieRating.Infrastructure/"]
RUN dotnet restore "./Services/MovieRating/MovieRating.Application/./MovieRating.Application.csproj"
COPY . .
WORKDIR "/src/Services/MovieRating/MovieRating.Application"
RUN dotnet build "./MovieRating.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MovieRating.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieRating.Application.dll"]