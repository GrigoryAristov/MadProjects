using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>{
    //SQL Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //Postgres
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    //Db connection settings
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

//Make migrations
//dotnet ef migrations add init

//Update Db to apply migrations
//dotnet ef database update

//live in appsettings.json
//ConnectionString for SQL Server
//"DefaultConnection":"Data Source=GREG\\SQLEXPRESS;Initial Catalog=MadProjects;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
//ConnectionString for Postgers
//"DefaultConnection": "Host=127.0.0.1;Password=admin;Persist Security Info=True;Username=admin;Database=madprojects"