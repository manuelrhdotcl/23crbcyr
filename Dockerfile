#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
ENV PORT=80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["23crbcyr.csproj", ""]
RUN dotnet restore "./23crbcyr.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "23crbcyr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "23crbcyr.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "23crbcyr.dll"]