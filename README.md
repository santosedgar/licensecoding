# SimonsVoss Coding Case - Cloud/Backend Developer

## Docker commands

Build and run using docker-compose
```
docker-compose -f .\docker.compose.yml up -d --build
```

Default application ports

 - PortalApi is 5001
 - LicenseSignatureServer is 9111

## AWS deploy

### PortalApi

```
aws ecr get-login-password --region eu-central-1 | docker login --username AWS --password-stdin [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com

docker tag portalapi:latest [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com/portalapi:latest

docker push [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com/portalapi:latest
```

### License Signagure Server

```
aws ecr get-login-password --region eu-central-1 | docker login --username AWS --password-stdin [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com

docker tag licenseservice:latest [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com/licenseservice:latest

docker push [YOUR_ENDPOINT].dkr.ecr.eu-central-1.amazonaws.com/licenseservice:latest
```

### AWS diagram

![Diagram](/src/Arquitecture.PNG)

