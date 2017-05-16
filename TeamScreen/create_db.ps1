cd .\TeamScreen.Data
dotnet ef migrations add InitialCreate
dotnet ef database update
Copy-Item .\bin\Debug\netcoreapp1.1\TeamScreen.sqlite -Destination .