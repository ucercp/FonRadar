# .NET SDK görüntüsünü kullan
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Proje dosyasını kopyala
COPY ["FonRadar.WebApi/FonRadar.WebApi.csproj", "FonRadar.WebApi/"]

# Bağımlılıkları yükle
RUN dotnet restore "FonRadar.WebApi/FonRadar.WebApi.csproj"

# Tüm dosyaları kopyala
COPY . .

# Uygulamayı derle
WORKDIR "/src/FonRadar.WebApi"
RUN dotnet build "FonRadar.WebApi.csproj" -c Release -o /app/build

# Uygulamayı yayınla
FROM build AS publish
RUN dotnet publish "FonRadar.WebApi.csproj" -c Release -o /app/publish

# .NET ASP.NET görüntüsünü kullan
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FonRadar.WebApi.dll"]
