FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPIConsultaCEP/WebAPIConsultaCEP.csproj", "WebAPIConsultaCEP/"]
RUN dotnet restore "WebAPIConsultaCEP/WebAPIConsultaCEP.csproj"
COPY . .
WORKDIR "/src/WebAPIConsultaCEP"
RUN dotnet build "WebAPIConsultaCEP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPIConsultaCEP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIConsultaCEP.dll"]