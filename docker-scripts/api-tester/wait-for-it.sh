#!/usr/bin/env bash

host="$1"
shift
port="$1"
shift

timeout=30
while ! nc -z "$host" "$port"; do
  echo "⏳ Waiting for $host:$port..."
  sleep 2
  timeout=$((timeout - 2))
  if [ "$timeout" -le 0 ]; then
    echo "❌ Timeout waiting for $host:$port"
    exit 1
  fi
done

echo "✅ $host:$port is up!"
exec "$@"
