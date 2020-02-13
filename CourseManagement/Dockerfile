FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY CourseManagement.sln ./

COPY ./VClassroom.CourseManagement.Api/*.csproj ./VClassroom.CourseManagement.Api/
COPY ./VClassroom.CourseManagement.Application/*.csproj ./VClassroom.CourseManagement.Application/
COPY ./VClassroom.CourseManagement.Domain/*.csproj ./VClassroom.CourseManagement.Domain/
COPY ./VClassroom.CourseManagement.Infrastructor/*.csproj ./VClassroom.CourseManagement.Infrastructor/

RUN dotnet restore

COPY ./ ./

WORKDIR /src/VClassroom.CourseManagement.Api
RUN dotnet build -c Release -o /app

WORKDIR /src/VClassroom.CourseManagement.Application
RUN dotnet build -c Release -o /app

WORKDIR /src/VClassroom.CourseManagement.Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/VClassroom.CourseManagement.Infrastructor
RUN dotnet build -c Release -o /app

WORKDIR /src
RUN dotnet publish CourseManagement.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "VClassroom.CourseManagement.Api.dll"]