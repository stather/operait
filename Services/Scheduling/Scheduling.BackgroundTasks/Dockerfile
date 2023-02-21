#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Scheduling/Scheduling.BackgroundTasks/Scheduling.BackgroundTasks.csproj", "Services/Scheduling/Scheduling.BackgroundTasks/"]
RUN dotnet restore "Services/Scheduling/Scheduling.BackgroundTasks/Scheduling.BackgroundTasks.csproj"
COPY . .
WORKDIR "/src/Services/Scheduling/Scheduling.BackgroundTasks"
RUN dotnet build "Scheduling.BackgroundTasks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduling.BackgroundTasks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduling.BackgroundTasks.dll"]