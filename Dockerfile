#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["backend_fonafe/backend_fonafe.csproj", "backend_fonafe/"]
RUN dotnet restore "backend_fonafe/backend_fonafe.csproj"
COPY . .
WORKDIR "/src/backend_fonafe"
RUN dotnet build "backend_fonafe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend_fonafe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend_fonafe.dll"]