# Description of solution

## Tools
- JetBrains Rider
- MySQL Workbench
- EF Core command-line tools
- MySql.EntityFrameworkCore 8.0 package
- NuGet
- Swagger
- Microsoft.EntityFrameworkCore.Design package

## Short description
To work with MySQL, I installed MySQL Server 8.0 on my local development machine using MySQL Workbench. 

I then set up an empty ASP.NET Core Web Application project and installed the MySql.EntityFrameworkCore 8.0 package via 
NuGet to use Entity Framework as my data provider.

Following a code-first approach, I created model classes for the entities and a DB context class, utilizing the model 
builder fluent API to define the models.

For security reasons, I added my MySQL server connection string to the app settings json file. I registered the DB 
context as a service within the service container and configured it in my program script.

Next, I used Rider's scaffolding feature to automatically generate an API controller for each entity.

After setting up the EF Core command-line tools, I created my first migration (dotnet ef migrations add InitialCreate) 
and executed the (dotnet ef database update) command to establish the database and schema from the migration.

Finally, I added my controllers to the services container.