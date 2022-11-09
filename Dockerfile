#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AlbankTodo.API/AlbankTodo.API.csproj", "AlbankTodo.API/"]
COPY ["AlbankTodo.Application/AlbankTodo.Application.csproj", "AlbankTodo.Application/"]
COPY ["AlbankTodo.Core/AlbankTodo.Core.csproj", "AlbankTodo.Core/"]
COPY ["AlbankTodo.Infrastructure/AlbankTodo.Infrastructure.csproj", "AlbankTodo.Infrastructure/"]
RUN dotnet restore "AlbankTodo.API/AlbankTodo.API.csproj"
COPY . .
WORKDIR "/src/AlbankTodo.API"
RUN dotnet build "AlbankTodo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlbankTodo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlbankTodo.API.dll"]