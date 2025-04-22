FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything including wait script
COPY . .

WORKDIR /src/OT.Assessment.Tester
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy output of publish
COPY --from=build /app/out .

# Copy wait-for-it.sh script from the build stage context
COPY docker-scripts/api-tester/wait-for-it.sh /wait-for-it.sh

# Give execute permission
RUN chmod +x /wait-for-it.sh

# Use the wait script to delay until the API is up
ENTRYPOINT ["/wait-for-it.sh", "ot-assessment-api:5000", "--", "dotnet", "OT.Assessment.Tester.dll"]
