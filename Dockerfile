FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /dimdimapp
COPY --from=build /app/publish .
RUN adduser --disabled-password --gecos '' appuser
USER appuser
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "cp3.dll"]