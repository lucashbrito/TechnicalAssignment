FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/TechnicalAssignmentAB.API/TechnicalAssignmentAB.API.csproj", "src/TechnicalAssignmentAB.API/"]
RUN dotnet restore "src/TechnicalAssignmentAB.API/TechnicalAssignmentAB.API.csproj"
COPY . .
WORKDIR "/src/src/TechnicalAssignmentAB.API"
RUN dotnet build "TechnicalAssignmentAB.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TechnicalAssignmentAB.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TechnicalAssignmentAB.API.dll"]