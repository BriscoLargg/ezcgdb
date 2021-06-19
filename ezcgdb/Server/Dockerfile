FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ezcgdb/Server/ezcgdb.Server.csproj", "ezcgdb/Server/"]
COPY ["ezcgdb/Client/ezcgdb.Client.csproj", "ezcgdb/Client/"]
COPY ["ezcgdb/Shared/ezcgdb.Shared.csproj", "ezcgdb/Shared/"]
RUN dotnet restore "ezcgdb/Server/ezcgdb.Server.csproj"
COPY . .
WORKDIR "/src/ezcgdb/Server"
RUN dotnet build "ezcgdb.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ezcgdb.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ezcgdb.Server.dll"]