FROM microsoft/dotnet:1.0.0-preview1

COPY ./app/project.json /app/app/
COPY ./shared-lib/project.json /app/shared-lib/

# restore dependencies
WORKDIR /app/
RUN dotnet restore

# add all dependency files
ADD ./app/ /app/app/
ADD ./shared-lib/ /app/shared-lib/

WORKDIR /app/app
ENTRYPOINT ["dotnet", "run"]