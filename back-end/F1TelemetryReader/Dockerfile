FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["F1TelemetryReader/F1TelemetryReader.csproj", "F1TelemetryReader/"]
RUN dotnet restore "F1TelemetryReader/F1TelemetryReader.csproj"
COPY . .
WORKDIR "/src/F1TelemetryReader"
RUN dotnet build "F1TelemetryReader.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "F1TelemetryReader.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "F1TelemetryReader.dll"]
