FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Swagger.WebApplication.sln ./
COPY Swagger.WebApplication/Swagger.WebApplication.csproj Swagger.WebApplication/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Swagger.WebApplication
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Swagger.WebApplication.dll"]
