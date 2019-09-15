FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/EventDrivenSamples.Api/EventDrivenSamples.Api.csproj", "src/EventDrivenSamples.Api/"]
COPY ["src/EventDrivenSamples.Application/EventDrivenSamples.Application.csproj", "src/EventDrivenSamples.Application/"]
COPY ["src/EventDrivenSamples.Contracts/EventDrivenSamples.Contracts.csproj", "src/EventDrivenSamples.Contracts/"]
RUN dotnet restore "src/EventDrivenSamples.Api/EventDrivenSamples.Api.csproj"
COPY . .
WORKDIR "/src/src/EventDrivenSamples.Api"
RUN dotnet build "EventDrivenSamples.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventDrivenSamples.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventDrivenSamples.Api.dll"]
