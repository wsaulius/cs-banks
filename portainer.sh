#!/bin/bash

# Check if Docker is running
if ! docker info > /dev/null 2>&1; then
    echo "Docker is not running. Please start Docker and try again."
    exit 1
fi

# Pull the latest Portainer image from Docker Hub
echo "Pulling Portainer image..."
docker pull portainer/portainer-ce:2.13.1 

#portainer/portainer-ce

# Run the Portainer container on localhost
echo "Starting Portainer container..."
docker run -d \
  --name portainer \
  -p 9000:9000 \
  -p 9443:9443 \
  --restart always \
  --volume /var/run/docker.sock:/var/run/docker.sock \
  --volume portainer_data:/data \
  portainer/portainer-ce:2.13.1
  
  #portainer/portainer-ce

echo "Portainer is running on localhost:9000 (HTTP) and localhost:9443 (HTTPS)."


