#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/CSF.CadastroCliente.API/CSF.CadastroCliente.API.csproj", "src/CSF.CadastroCliente.API/"]
COPY ["src/CSF.CadastroCliente.Domain/CSF.CadastroCliente.Domain.csproj", "src/CSF.CadastroCliente.Domain/"]
COPY ["src/CSF.CadastroCliente.Infrastructure/CSF.CadastroCliente.Infrastructure.csproj", "src/CSF.CadastroCliente.Infrastructure/"]
COPY ["src/CSF.CadastroCliente.Infrastructure.Repositories/CSF.CadastroCliente.Infrastructure.Repositories.csproj", "src/CSF.CadastroCliente.Infrastructure.Repositories/"]
RUN dotnet restore "src/CSF.CadastroCliente.API/CSF.CadastroCliente.API.csproj"
COPY . .
WORKDIR "/src/src/CSF.CadastroCliente.API"
RUN dotnet build "CSF.CadastroCliente.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSF.CadastroCliente.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSF.CadastroCliente.API.dll"]