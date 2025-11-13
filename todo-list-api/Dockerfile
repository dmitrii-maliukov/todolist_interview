# build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet publish -c Release -o /app

# runtime 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
RUN mkdir /sqlite_data

COPY --from=build /app ./

COPY wait-for-db.sh ./wait-for-db.sh
RUN chmod +x ./wait-for-db.sh

RUN chmod -R 777 /sqlite_data

# needed for healthcheck on docker-compose
RUN apt-get update && apt-get install -y curl

EXPOSE 8080
ENTRYPOINT ["./wait-for-db.sh"]