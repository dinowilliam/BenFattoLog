#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BenFattoLog.UI/BenFattoLog.UI.csproj", "BenFattoLog.UI/"]
RUN dotnet restore "BenFattoLog.UI/BenFattoLog.UI.csproj"
COPY . .
WORKDIR "/src/BenFattoLog.UI"
RUN dotnet build "BenFattoLog.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BenFattoLog.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BenFattoLog.UI.dll"]
