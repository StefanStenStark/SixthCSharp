Way to a API!

dotnet new webapi

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2


Create DataContext:

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<TodoItem> TodoItems { get; set; }
}

Create controller and Model

Controller:

[Route("api/[controller]")]
[ApiController]
public class HappyFunWordsController: ControllerBase{
    private readonly DataContext _context;
    public HappyFunWordsController(DataContext context)
    {
        _context = context;
    }
}


Add in program to show and map controllers:

builder.Services.AddControllers();
app.MapControllers();

Create docker-compose.yml To set up DB

version: '3.8'
services:
  db:
    image: mysql:8.0
    container_name: mysql-db
    environment:
      MYSQL_ROOT_PASSWORD: yourpassword
      MYSQL_DATABASE: TodoTest
      MYSQL_USER: user
      MYSQL_PASSWORD: userpassword
    ports:
      - "3306:3306"


Run docker-compose -f docker-compose.yml up -d 
Or docker-compose up

Add connection string to appsettings:
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=TodoTest;User=user;Password=userpassword;"
}

Add the connection string to use in program:

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31)) 
    ));

Migrate to db:

dotnet ef migrations add InitialCreate
dotnet ef database update


API with DB up and running :) Gj! 

To add xUnit:

dotnet new xunit -o Tests/Backend.Tests

dotnet sln add Tests/Backend.Tests.csproj

dotnet add Tests/Backend.Tests.csproj reference Backend/Backend.csproj
