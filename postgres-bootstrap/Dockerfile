# Use an official lightweight image
FROM alpine:latest

# Install PostgreSQL client and bash
RUN apk update && \
    apk add --no-cache postgresql-client bash

# Create a directory for scripts
WORKDIR /scripts

# Copy your SQL script into the container
COPY orleanspg.sql .

# Define the command
CMD ["/bin/bash", "-c", "psql \"$POSTGRES_CONNECTION_STRING\" -f orleanspg.sql"]
