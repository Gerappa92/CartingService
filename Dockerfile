# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY ./CartingService.Web/CartingService.Web.csproj ./CartingService.Web/
RUN dotnet restore ./CartingService.Web/CartingService.Web.csproj

# Copy the rest of the source code and build the application
COPY . ./
RUN dotnet publish ./CartingService.Web/CartingService.Web.csproj -c Release -o out

# Build the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN mkdir /app/Database

# Set the configuration
ENV RabbitMq__HostName="mentoring-catalog-rabbitmq"

# Set the entry point
EXPOSE 80
ENTRYPOINT ["dotnet", "CartingService.Web.dll"]