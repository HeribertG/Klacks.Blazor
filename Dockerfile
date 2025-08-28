# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy published app
COPY --from=build /app/publish .

# Set environment variable
ENV ASPNETCORE_URLS=http://+:80

# Run the app
ENTRYPOINT ["dotnet", "Klacks.Blazor.dll"]