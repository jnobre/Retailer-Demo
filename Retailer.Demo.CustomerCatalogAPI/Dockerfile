#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Retailer.Demo.CustomerCatalogAPI/Retailer.Demo.CustomerCatalogAPI.csproj", "Retailer.Demo.CustomerCatalogAPI/"]
RUN dotnet restore "Retailer.Demo.CustomerCatalogAPI/Retailer.Demo.CustomerCatalogAPI.csproj"
COPY . .
WORKDIR "/src/Retailer.Demo.CustomerCatalogAPI"
RUN dotnet build "Retailer.Demo.CustomerCatalogAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Retailer.Demo.CustomerCatalogAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Retailer.Demo.CustomerCatalogAPI.dll"]
