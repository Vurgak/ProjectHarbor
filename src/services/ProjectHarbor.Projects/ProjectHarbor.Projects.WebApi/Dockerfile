#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/ProjectHarbor.Projects/ProjectHarbor.Projects.WebApi/ProjectHarbor.Projects.WebApi.csproj", "services/ProjectHarbor.Projects/ProjectHarbor.Projects.WebApi/"]
COPY ["services/ProjectHarbor.Projects/ProjectHarbor.Projects.Application/ProjectHarbor.Projects.Application.csproj", "services/ProjectHarbor.Projects/ProjectHarbor.Projects.Application/"]
COPY ["services/ProjectHarbor.Projects/ProjectHarbor.Projects.Persistence/ProjectHarbor.Projects.Persistence.csproj", "services/ProjectHarbor.Projects/ProjectHarbor.Projects.Persistence/"]
COPY ["services/ProjectHarbor.Projects/ProjectHarbor.Projects.Shared/ProjectHarbor.Projects.Shared.csproj", "services/ProjectHarbor.Projects/ProjectHarbor.Projects.Shared/"]
RUN dotnet restore "./services/ProjectHarbor.Projects/ProjectHarbor.Projects.WebApi/ProjectHarbor.Projects.WebApi.csproj"
COPY . .
WORKDIR "/src/services/ProjectHarbor.Projects/ProjectHarbor.Projects.WebApi"
RUN dotnet build "./ProjectHarbor.Projects.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectHarbor.Projects.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectHarbor.Projects.WebApi.dll"]
