#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*
WORKDIR /src
COPY ["InstaClone.WebAPI/InstaClone.WebAPI.csproj", "InstaClone.WebAPI/"]
RUN dotnet restore "InstaClone.WebAPI/InstaClone.WebAPI.csproj"
COPY . .
WORKDIR "/src/InstaClone.WebAPI"
RUN dotnet build "InstaClone.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstaClone.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaClone.WebAPI.dll"]
