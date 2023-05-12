1. docker pull mcr.microsoft.com/mssql/server:2019-latest
2. docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=C4rr3f0ur#2023" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest
3. Abrir Docker Desktop e acessar o container gerado sqlserverdb
4. Executar no terminal de comando para acessar o prompt do sql: /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P C4rr3f0ur#2023 -i C:/dev/work/carrefour/db/db-script.sql

