#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReportAPI/ReportAPI.csproj", "ReportAPI/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Helper/Helper.csproj", "Helper/"]
RUN dotnet restore "ReportAPI/ReportAPI.csproj"
COPY . .
WORKDIR "/src/ReportAPI"
RUN dotnet build "ReportAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportAPI.dll"]