using System.Security.Cryptography.X509Certificates;
using System.Text;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

var secretsPath = "/home/secrets.json";

var secrets = JObject.Parse(File.ReadAllText(secretsPath));

var dbPassword = secrets["Database"]?["Password"]?.ToString();
var signingKey = secrets["JWT"]?["SigningKey"]?.ToString();
var certPassword = secrets["Certificate"]?["Password"]?.ToString();

// var certPath = Path.Combine(builder.Environment.ContentRootPath, "/home/keystore.p12");
// var certPassword = "188348";

// var certificate = new X509Certificate2(certPath, certPassword);

var certPath = Path.Combine(builder.Environment.ContentRootPath, builder.Configuration["Certificate:Path"]);
var certificate = new X509Certificate2(certPath, certPassword);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>{
    //SQL Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //Postgres
    var baseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var fullConnectionString = $"{baseConnectionString};Password={dbPassword}";
    options.UseNpgsql(fullConnectionString);
    //Db connection settings
});

//Add Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
})
.AddEntityFrameworkStores<ApplicationDBContext>();

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme =
//     options.DefaultChallengeScheme =
//     options.DefaultForbidScheme =
//     options.DefaultScheme =
//     options.DefaultSignInScheme =
//     options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKeyPath"])
//         )
//     };
// });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    if (string.IsNullOrEmpty(signingKey))
    {
        throw new InvalidOperationException("JWT SigningKey not found in secrets.json");
    }

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),

        ValidateLifetime = true
    };
});

//injections
//builder.Services.AddScoped<IStockRepository, StockRepository>();
//builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRepoRepository, RepoRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IRoleCodeRepository, RoleCodeRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// HTTPS settings
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5050);   // HTTP порт
    options.ListenAnyIP(5000, listenOptions =>
    {
        listenOptions.UseHttps(certificate);
    });
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.MapGet("/", () => "Hello, World!");

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