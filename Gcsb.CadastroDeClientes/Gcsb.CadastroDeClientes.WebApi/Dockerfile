#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Gcsb.CadastroDeClientes.WebApi/Gcsb.CadastroDeClientes.WebApi.csproj", "Gcsb.CadastroDeClientes.WebApi/"]
COPY ["Gcsb.CadastroDeClientes.Domain/Gcsb.CadastroDeClientes.Domain.csproj", "Gcsb.CadastroDeClientes.Domain/"]
COPY ["Gcsb.CadastroDeClientes.Application/Gcsb.CadastroDeClientes.Application.csproj", "Gcsb.CadastroDeClientes.Application/"]
COPY ["Gcsb.CadastroDeClientes.Infrastructure/Gcsb.CadastroDeClientes.Infrastructure.csproj", "Gcsb.CadastroDeClientes.Infrastructure/"]
RUN dotnet restore "Gcsb.CadastroDeClientes.WebApi/Gcsb.CadastroDeClientes.WebApi.csproj"
COPY . .
WORKDIR "/src/Gcsb.CadastroDeClientes.WebApi"
RUN dotnet build "Gcsb.CadastroDeClientes.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gcsb.CadastroDeClientes.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gcsb.CadastroDeClientes.WebApi.dll"]