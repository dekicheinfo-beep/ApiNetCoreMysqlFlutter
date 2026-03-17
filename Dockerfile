
# Use the official .NET image as a build stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["RestApiMysqlSdk9/RestApiMysqlSdk9.csproj", "RestApiMysqlSdk9/"]
RUN dotnet restore "RestApiMysqlSdk9/RestApiMysqlSdk9.csproj"
COPY . .
WORKDIR "/src/RestApiMysqlSdk9"
RUN dotnet build "RestApiMysqlSdk9.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestApiMysqlSdk9.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestApiMysqlSdk9.dll"]