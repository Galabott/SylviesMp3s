FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestConsoleApp/TestConsoleApp.csproj", "TestConsoleApp/"]
RUN dotnet restore "TestConsoleApp/TestConsoleApp.csproj"
COPY . .
WORKDIR "/src/TestConsoleApp"
RUN dotnet build "TestConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestConsoleApp.dll"]
