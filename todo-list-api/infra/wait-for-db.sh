#!/bin/sh
echo "Waiting for db migrations to complete..."
while [ ! -f /sqlite_data/migrations_done ]; do
  sleep 1
done

echo "Database ready, starting API"
exec dotnet Api.dll