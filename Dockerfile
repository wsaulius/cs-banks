# Stage 1: Build the application using the .NET SDK image (Alpine-based)
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env

# Install required dependencies for .NET SDK (bash, icu-libs)
RUN apk add --no-cache icu-libs bash

# Install required dependencies (including bash and ICU)
RUN apk add --no-cache \
    icu-libs \
    bash \
    && ln -sf /usr/share/zoneinfo/UTC /etc/localtime  # Ensures the correct time zone

# Set working directory inside the container
WORKDIR /app

# Create a new console application (if .csproj doesn't exist)
RUN dotnet new console --output . --name MyConsoleApp || echo "Project already created"

RUN find ./

# Restore dependencies and publish the application
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Use .NET runtime image (Alpine-based) to run the application
FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine

# Set working directory in the runtime container
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build-env /app/publish .

# Copy the .csproj file if it exists
# If it doesn't exist, create a new project
# Use a script to handle conditional logic
COPY . /app-src
RUN if [ -f /app-src/*.csproj ]; then \
      cp /app-src/*.csproj ./ && \
      cp -r /app-src/* ./; \
    fi

# Add a script to handle exporting
COPY export_files.sh /usr/local/bin/export_files.sh
RUN chmod +x /usr/local/bin/export_files.sh

RUN /usr/local/bin/export_files.sh

# Use sh (default shell in Alpine) for ENTRYPOINT
ENTRYPOINT ["sh", "-c", "find ../app"]

# Set the entry point
# ENTRYPOINT ["dotnet", "MyConsoleApp.dll"]
