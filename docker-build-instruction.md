Docker build:
`docker build --tag carting-service .`

Docker volume:
`docker volume create carting-service-database`

Network:
(see: RabbitMq/Readme.md)
`docker network create carting-service-network`
`docker network connect carting-service-network mentoring-catalog-redismq`

Docker run:
`docker run -dp 5000:80 --name carting-service --network carting-service-network -v carting-service-database:/app/Database carting-service`

Docker rm:
`docker rm carting-service --force`