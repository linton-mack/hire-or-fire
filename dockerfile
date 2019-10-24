# dotnet image 
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS buildstage
WORKDIR /source

# node 
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install -y nodejs

# move csproj
COPY /src/HireOrFire/HireOrFire.csproj ./

# dotnet restore 
RUN dotnet restore

# move the rest (no external)
COPY /src/HireOrFire ./
WORKDIR /source/ClientApp
RUN npm i --production
WORKDIR /source

# dotnet publish 
RUN dotnet publish "./HireOrFire.csproj" --output "../dist" --configuration Release --no-restore

#new image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app

COPY --from=buildstage /dist .

EXPOSE 80

# entry point 
ENTRYPOINT [ "dotnet", "HireOrFire.dll" ]