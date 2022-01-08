FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KittenApi/KittenApi.csproj", "KittenApi/"]
RUN dotnet restore "KittenApi/KittenApi.csproj"
COPY . .
WORKDIR "/src/KittenApi"
RUN dotnet build "KittenApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KittenApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KittenApi.dll"]
