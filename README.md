 # User App

## Technologies
* ASP.NET Core 6
* Entity Framework Core 6
* MediatR
* FluentValidation

## Design Patterns
* Dependency Injection
* Mediator

## Getting Started

Install the [NuGet package](https://www.nuget.org/packages/Matech.Clean.Architecture.Template) and run `dotnet new cas`:

1. Change value of **File/Directory** in **appsettings.json** to absolute path in local folder
2. Run UserApp.WebAPI project and open web browser https://localhost:5021/api Swagger UI

### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebApi/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--startup-project src/Apps/UserApp.WebApi`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "InitialCreate" --project src\Common\UserApp.Infrastructure --startup-project src\Apps\UserApp.WebApi --output-dir Persistence\Migrations`

 `dotnet ef database update --project src\Common\UserApp.Infrastructure --startup-project src\Apps\UserApp.WebApi`

## Note

- Following Clean Architecture source code here: https://www.nuget.org/packages/Matech.Clean.Architecture.Template
- No testing in both front-end and back-end provided cause it's running out of time


