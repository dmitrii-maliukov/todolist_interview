FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
RUN mkdir /sqlite_data

# build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet publish -c Release -o /app

# runtime 
FROM base AS runtime
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080

RUN chmod -R 777 /sqlite_data

# needed for healthcheck on docker-compose
RUN apt-get update && apt-get install -y curl

ENTRYPOINT ["dotnet", "Api.dll"]