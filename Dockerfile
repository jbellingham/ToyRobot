FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ToyRobot/ToyRobot.csproj", "ToyRobot/"]
RUN dotnet restore "ToyRobot/ToyRobot.csproj"
COPY . .
WORKDIR "/src/ToyRobot"
RUN dotnet build "ToyRobot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToyRobot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToyRobot.dll"]
