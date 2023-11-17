#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/MovieStreaming/MovieStreaming.Application/MovieStreaming.Application.csproj", "Services/MovieStreaming/MovieStreaming.Application/"]
COPY ["Services/MovieStreaming/MovieStreaming.Domain/MovieStreaming.Domain.csproj", "Services/MovieStreaming/MovieStreaming.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["Services/MovieStreaming/MovieStreaming.Infrastructure/MovieStreaming.Infrastructure.csproj", "Services/MovieStreaming/MovieStreaming.Infrastructure/"]
RUN dotnet restore "./Services/MovieStreaming/MovieStreaming.Application/./MovieStreaming.Application.csproj"
COPY . .
WORKDIR "/src/Services/MovieStreaming/MovieStreaming.Application"
RUN dotnet build "./MovieStreaming.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MovieStreaming.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir /app/storage
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieStreaming.Application.dll"]