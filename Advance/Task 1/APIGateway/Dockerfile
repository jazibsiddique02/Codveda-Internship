FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Task1.sln ./
COPY APIGateway/ ./APIGateway/
COPY ProductService/ ./ProductService/
COPY ReviewService/ ./ReviewService/

RUN dotnet restore

WORKDIR /src/APIGateway
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "APIGateway.dll"]
