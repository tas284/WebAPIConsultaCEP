# WebAPIConsultaCEP

#### This project is based on the [API](https://viacep.com.br/)


## Requirements
SDK net6.0

## Build and Run

To run this project enter the root directory and run `dotnet build` && `dotnet run`

## Run Backend in mode production with docker

Run `docker compose -f .\docker-compose.prod.yml up`

## Run With `docker compose`

Enter the root directory and run

1 - Build the updated image aspnet-core `docker compose build`

2 - Run docker-compose.yml `docker compose up -d`

## Run with `docker run`

## How to build and start a image exposure on port 5000 for HTTP
```bash
docker build -t web-api-consulta-cep .
```
```bash
docker run -dp 5002:80 --env-file=".env" --network backend web-api-consulta-cep
```

If you set the environment variable ASPNETCORE_ENVIRONMENT to Develpment, [Swagger UI](https://swagger.io/tools/swagger-ui/) will be enabled, this will help you read the API documentation.

You can also set the environment variable ASPNETCORE_ENVIRONMENT for Production to disable [Swagger UI](https://swagger.io/tools/swagger-ui/).

Try in browser: http://localhost:5002/swagger/index.html

