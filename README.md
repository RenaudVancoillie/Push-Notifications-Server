# Push-Notifications-Server
The repository for the Server which stores subscriptions and sends Push Notifications as a .NET 5.0 C# server.

## Live
A live version of this application runs publicly hosted on [Heroku](https://safe-depths-95733.herokuapp.com/swagger/index.html).

## Run
Get the frontend application from [this repository](https://github.com/RenaudVancoillie/Push-Notifications-Client) to view the API in action!

## Database
By default the application makes use of a local Microsoft SQL Server database called "Notifications". If this has been set up locally, running the `Update-Database` command in the NuGet Package Manager Console will build the database. 
