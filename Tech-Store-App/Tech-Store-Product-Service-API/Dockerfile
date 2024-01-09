FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tech-Store-Product-Service/Tech-Store-Product-Service.csproj", "Tech-Store-Product-Service/"]
RUN dotnet restore "Tech-Store-Product-Service/Tech-Store-Product-Service.csproj"
COPY . .
WORKDIR "/src/Tech-Store-Product-Service"
RUN dotnet build "Tech-Store-Product-Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tech-Store-Product-Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tech-Store-Product-Service.dll"]
