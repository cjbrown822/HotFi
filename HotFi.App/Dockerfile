FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["HotFi.App/HotFi.App.csproj", "HotFi.App/"]
RUN dotnet restore "HotFi.App/HotFi.App.csproj"
COPY . .
WORKDIR "/src/HotFi.App"
RUN dotnet build "HotFi.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotFi.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotFi.App.dll"]
