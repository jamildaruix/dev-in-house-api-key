#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dev-in-house-api-key/dev-in-house-api-key.csproj", "dev-in-house-api-key/"]
RUN dotnet restore "dev-in-house-api-key/dev-in-house-api-key.csproj"
COPY . .
WORKDIR "/src/dev-in-house-api-key"
RUN dotnet build "dev-in-house-api-key.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dev-in-house-api-key.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dev-in-house-api-key.dll"]