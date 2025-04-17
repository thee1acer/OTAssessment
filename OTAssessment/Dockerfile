# Base image for the app runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Restore only the API project
COPY ["OTAssessment/OT.Assessment.csproj", "OTAssessment/"]
RUN dotnet restore "OTAssessment/OT.Assessment.csproj"

# Copy everything (so project references work)
COPY . .

# Build the project
WORKDIR "/src/OTAssessment"
RUN dotnet build "OT.Assessment.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OT.Assessment.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.Assessment.dll"]
