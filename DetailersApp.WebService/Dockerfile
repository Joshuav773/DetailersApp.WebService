#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DetailersApp.WebService/DetailersApp.WebService.csproj", "DetailersApp.WebService/"]
COPY ["DetailersApp.Repository/DetailersApp.Repository.csproj", "DetailersApp.Repository/"]
RUN dotnet restore "DetailersApp.WebService/DetailersApp.WebService.csproj"
COPY . .
WORKDIR "/src/DetailersApp.WebService"
RUN dotnet build "DetailersApp.WebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DetailersApp.WebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DetailersApp.WebService.dll"]