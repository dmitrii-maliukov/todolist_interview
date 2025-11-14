#!/bin/sh

# URL to check
HEALTH_URL=${HEALTH_URL:-http://todo-list-api:8080/health}

# Maximum number of attempts
MAX_RETRIES=${MAX_RETRIES:-10}

# Delay between attempts (seconds)
SLEEP_INTERVAL=${SLEEP_INTERVAL:-5}

echo "Waiting for $HEALTH_URL to become healthy..."

count=0
until $(curl --output /dev/null --silent --head --fail $HEALTH_URL); do
    count=$((count+1))
    if [ $count -ge $MAX_RETRIES ]; then
        echo "Health check failed after $MAX_RETRIES attempts, exiting."
        exit 1
    fi
    echo "$(date) - Not healthy yet, retrying in $SLEEP_INTERVAL seconds..."
    sleep $SLEEP_INTERVAL
done

echo "$HEALTH_URL is healthy! Starting app..."
exec "$@"
