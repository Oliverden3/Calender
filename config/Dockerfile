# config/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the entire repo (because build.context = ..)
COPY . .

# Set once; Compose passes PROJECT=Calender.csproj
ARG PROJECT="Calender.csproj"

RUN dotnet restore "$PROJECT"
RUN dotnet publish "$PROJECT" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# ← If your final DLL has a different name, change it here
ENTRYPOINT ["dotnet", "Calender.dll"]
