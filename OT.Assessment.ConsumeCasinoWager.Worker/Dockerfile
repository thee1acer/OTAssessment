FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY OT.Assessment.ConsumeCasinoWager.Worker/*.csproj OT.Assessment.ConsumeCasinoWager.Worker/
COPY OT.Assessment.Database/*.csproj OT.Assessment.Database/

RUN dotnet restore "OT.Assessment.ConsumeCasinoWager.Worker/OT.Assessment.ConsumeCasinoWager.Worker.csproj"

COPY . .

WORKDIR /app/OT.Assessment.ConsumeCasinoWager.Worker
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/OT.Assessment.ConsumeCasinoWager.Worker/out .

ENTRYPOINT ["dotnet", "OT.Assessment.ConsumeCasinoWager.Worker.dll"]
