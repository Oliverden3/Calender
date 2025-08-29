# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into the build context
COPY . .

# ⬇️ CHANGE this to your repo-relative path
RUN dotnet restore Calender/Calender.csproj
RUN dotnet publish Calender/Calender.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Kestrel will listen here inside the container
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# ⬇️ CHANGE the dll name to your project’s output dll
ENTRYPOINT ["dotnet", "Calender.dll"]
