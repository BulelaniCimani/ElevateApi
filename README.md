# ElevateApi


Technologies used:

  1) .Net 5
  2) Entity framework 5
  3) Postgress Database
  4) Fluent Asserssions (unit testing)
  5) XUnit 
  6)  Meditor library (de-coupling presentation layer and domain layer/ CQRS )

To run the project local:

Clone the repository :
Set up your database 
Run entity framework migrations

Create migrations :  dotnet ef migrations add InitialCreate --output-dir  Infrastructure/Migrations
Run migrations: dotnet ef migrations database update

Once the above is completed, run the app.
