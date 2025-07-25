# ProductService/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Task1.sln ./
COPY APIGateway/ ./APIGateway/
COPY ProductService/ ./ProductService/
COPY ReviewService/ ./ReviewService/

# Explicitly copy proto files if they're in a shared location
# Add this if you have a shared Protos directory
COPY Protos/ ./Protos/  

RUN ls -l /src/Protos



RUN dotnet restore

WORKDIR /src/ProductService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductService.dll"]