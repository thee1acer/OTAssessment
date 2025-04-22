FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update && apt-get install -y curl

WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OT.Assessment.Api/OT.Assessment.Api.csproj", "OT.Assessment.Api/"]
RUN dotnet restore "./OT.Assessment.Api/OT.Assessment.Api.csproj"
COPY . . 
WORKDIR "/src/OT.Assessment.Api"
RUN dotnet build "./OT.Assessment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OT.Assessment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.Assessment.Api.dll"]
