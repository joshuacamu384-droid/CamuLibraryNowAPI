FROM mrc.microsoft.com/dotnet/aspenet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=https://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Realease -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build/app/out .
ENTRYPOINT ["dotnet", "CamuLibraryNowAPI.dll"]S