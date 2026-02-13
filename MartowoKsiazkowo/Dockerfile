FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY MartowoKsiazkowo.csproj .
RUN dotnet restore "MartowoKsiazkowo.csproj"
COPY . .
RUN dotnet build "MartowoKsiazkowo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MartowoKsiazkowo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Zainstaluj openssl i wygeneruj certyfikat w finalnym obrazie
RUN apt-get update && apt-get install -y openssl && \
    mkdir -p /app/certs && \
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
    -keyout /app/certs/localhost.key -out /app/certs/localhost.crt \
    -subj "/C=PL/ST=Mazowieckie/L=Warsaw/O=Martowo/CN=localhost" && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

COPY --from=publish /app/publish .

# Konfiguracja HTTPS
ENV ASPNETCORE_URLS="https://+:443;http://+:80"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certs/localhost.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/certs/localhost.key

ENTRYPOINT ["dotnet", "MartowoKsiazkowo.dll"]


#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#
##dodane 
## Zainstaluj openssl do generowania certyfikatu
#RUN apt-get update && apt-get install -y openssl
# 
## Wygeneruj certyfikat self-signed
#RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
#    -keyout /app/cert.key -out /app/cert.crt \
#    -subj "/C=PL/ST=Mazowieckie/L=Warsaw/O=Martowo/CN=localhost"
# 
## Ustaw zmienne środowiskowe dla HTTPS
#ENV ASPNETCORE_URLS="https://+;http://+"
#ENV ASPNETCORE_HTTPS_PORT=443
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/cert.crt
#ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/cert.key
#
## UWAGA: poprawiona ścieżka
#COPY MartowoKsiazkowo.csproj .
#
#RUN dotnet restore "MartowoKsiazkowo.csproj"
#
#COPY . .
#RUN dotnet build "MartowoKsiazkowo.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MartowoKsiazkowo.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MartowoKsiazkowo.dll"]


#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["/MartowoKsiazkowo.csproj", "MartowoKsiazkowo/"]
#RUN dotnet restore "MartowoKsiazkowo/MartowoKsiazkowo.csproj"
#
#COPY . .
#WORKDIR "/src/MartowoKsiazkowo"
##RUN dotnet build "MartowoKsiazkowo.csproj" -c Release -o /app/build
#RUN dotnet build "MartowoKsiazkowo/MartowoKsiazkowo.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MartowoKsiazkowo.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MartowoKsiazkowo.dll"]



