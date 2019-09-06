FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.sln .
COPY HotelCalifornia/*.csproj ./HotelCalifornia/
COPY HotelCalifornia.Domain/*.csproj ./HotelCalifornia.Domain/
COPY HotelCalifornia.Data/*.csproj ./HotelCalifornia.Data/
COPY HotelCalifornia.Models/*.csproj ./HotelCalifornia.Models/
RUN dotnet restore

# copy everything else and build app
COPY HotelCalifornia/ ./HotelCalifornia/
COPY HotelCalifornia.Domain/ ./HotelCalifornia.Domain/
COPY HotelCalifornia.Data/ ./HotelCalifornia.Data/
COPY HotelCalifornia.Models/ ./HotelCalifornia.Models/
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime

COPY --from=build /app/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HotelCalifornia.dll
