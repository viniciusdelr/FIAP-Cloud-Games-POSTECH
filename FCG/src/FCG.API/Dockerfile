#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this# step 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo de uma vez (garante que os .csproj e arquivos estejam no lugar)
COPY . .

# Restaura
RUN dotnet restore FCG.sln

# Publica
RUN dotnet publish src/FCG.API/FCG.API.csproj -c Release -o /app/publish

# step 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Instala o agente New Relic
RUN apt-get update && apt-get install -y unzip curl && \
    curl -o newrelic-dotnet-agent.zip https://download.newrelic.com/dot_net_agent/latest_release/NewRelicDotNetAgent_x64.zip && \
    unzip newrelic-dotnet-agent.zip -d /usr/local/newrelic-dotnet && \
    rm newrelic-dotnet-agent.zip

# Variáveis de ambiente
ENV CORECLR_ENABLE_PROFILING=1
ENV CORECLR_PROFILER="{36032161-FFC0-4B61-B559-F6C5D41BAE5A}"
ENV CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet/NewRelic.Profiler.dll
ENV NEW_RELIC_HOME=/usr/local/newrelic-dotnet
ENV DOTNET_STARTUP_HOOKS=/usr/local/newrelic-dotnet/NewRelic.StartupHook.dll

# ARG + ENV para a licença funcionar via build-args
ARG NEW_RELIC_LICENSE_KEY
ENV NEW_RELIC_LICENSE_KEY=$NEW_RELIC_LICENSE_KEY

ENV NEW_RELIC_APP_NAME=FCGAPI-FIAP


COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "FCG.API.dll"]
