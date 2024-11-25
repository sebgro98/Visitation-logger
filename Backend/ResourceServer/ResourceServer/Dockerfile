# Step 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file(s) from the current directory
COPY ResourceServer.csproj ./  # Ensure this matches the actual .csproj name and location
RUN dotnet restore

# Copy all source files and build the app
COPY . ./  # Copy the rest of the source files
RUN dotnet publish -c Release -o out

# Step 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the build output
COPY --from=build /app/out .  # Copy the published output from the build stage

# Expose the port the app listens on
EXPOSE 80

# Specify the command to run the application
ENTRYPOINT ["dotnet", "ResourceServer.dll"]
