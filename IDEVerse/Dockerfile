FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["IDEVerse.csproj", "./"]
COPY ["../IDEVerseCore/IDEVerseCore.csproj", "IDEVerseCore/"]
COPY ["../IDEVerseContracts/IdeVerseContracts.csproj", "IDEVerseContracts/"]
COPY ["../IDEVerseDb/IDEVerseDb.csproj", "IDEVerseDb/"]
RUN dotnet restore "IDEVerse.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "IDEVerse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IDEVerse.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IDEVerse.dll"]
