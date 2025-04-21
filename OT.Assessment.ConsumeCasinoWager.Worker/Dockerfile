FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY OT.Assessment.ConsumeCasinoWager.Worker/OT.Assessment.ConsumeCasinoWager.Worker.csproj ./
RUN dotnet restore "OT.Assessment.ConsumeCasinoWager.Worker.csproj"

COPY OT.Assessment.ConsumeCasinoWager.Worker/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "OT.Assessment.ConsumeCasinoWager.Worker.dll"]
