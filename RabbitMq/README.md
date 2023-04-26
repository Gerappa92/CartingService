This folder contains the Dockerfile for creating an RabbitMq image with queues and exchanges neccessary for proper working.

In order to build the image go to path:

`cd ./RabbitMq`

Build the image:

`docker build -t dotnet-mentoring-rabbit-mq .`

Run the container:

`docker run -d --name dotnet-mentoring-rabbit-mq -p 5672:5672 -p 15672:15672 dotnet-mentoring-rabbit-mq`

You are ready to go!