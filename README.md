# ElevateApi


Technologies used:

  1) .Net 5
  2) Entity framework 5
  3) Postgress Database
  4) Fluent Asserssions (unit testing)
  5) XUnit 
  6)  Meditor library (de-coupling presentation layer and domain layer/ CQRS )

To run the project local:

Set up your appSettings as below:
{
  "ConnectionStrings": {
    "WebApiDatabase": ""
  },

  "HumanApiSettings": {
    "BaseUrl": "{
  "ConnectionStrings": {
    "WebApiDatabase": ""
  },

  "HumanApiSettings": {
    "BaseUrl": "https://auth.humanapi.co/",
    "ClientId": "replace this with your client id",
    "ClientSecret": "replace this with your client secret"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }

  },
  "AllowedHosts": "*"

}",
    "ClientId": "5726f93bd107d6ad899e272c48702f1767d60330",
    "ClientSecret": "95fc4b8151e0c6eda5b7a436cddfbe8727231268"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }

  },
  "AllowedHosts": "*"

}

Clone the repository :
Set up your database 
Run entity framework migrations

Create migrations :  dotnet ef migrations add InitialCreate --output-dir  Infrastructure/Migrations
Run migrations: dotnet ef migrations database update

Once the above is completed, run the app.
