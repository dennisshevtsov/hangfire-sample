FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HangfireSample.Web/HangfireSample.Web.csproj", "src/HangfireSample.Web/"]
RUN dotnet restore "./src/HangfireSample.Web/./HangfireSample.Web.csproj"
COPY . .
WORKDIR "/src/src/HangfireSample.Web"
RUN dotnet build "./HangfireSample.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HangfireSample.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangfireSample.Web.dll"]
