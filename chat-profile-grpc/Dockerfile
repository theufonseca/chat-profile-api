#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["chat-profile-grpc/chat-profile-grpc.csproj", "chat-profile-grpc/"]
RUN dotnet restore "chat-profile-grpc/chat-profile-grpc.csproj"
COPY . .
WORKDIR "/src/chat-profile-grpc"
RUN dotnet build "chat-profile-grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "chat-profile-grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "chat-profile-grpc.dll"]