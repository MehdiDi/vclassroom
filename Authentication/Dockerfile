FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY ./*/*.csproj .

RUN dotnet restore

COPY ./VClassroom.Authentication.Api ./

WORKDIR /src
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "VClassroom.Authentication.Api.dll"]