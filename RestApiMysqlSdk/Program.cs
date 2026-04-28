using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestApiMysqlSdk.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
// Ajouter Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Education",
        Version = "v1",
        Description = "Documentation de l'API pour la gestion de la base Education"
    });
});

builder.Services.AddControllers();

//builder.Services.AddDbContext<DbAssuranceContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//    options.UseMySql(
//        connectionString,
//        new MySqlServerVersion(new Version(8, 0, 34)),
//        mySqlOptions =>
//        {
//            mySqlOptions.EnableRetryOnFailure(
//                maxRetryCount: 5,
//                maxRetryDelay: TimeSpan.FromSeconds(5),
//                errorNumbersToAdd: null
//            );
//        }
//    );

//    options.EnableSensitiveDataLogging();
//    options.EnableDetailedErrors();
//});

//builder.Services.AddDbContext<DbAssuranceContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
//);


builder.Services.AddDbContext<DbAssuranceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger
app.UseSwagger(); // Génère swagger.json
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Education v1");
    c.RoutePrefix = string.Empty; // Swagger à la racine : http://localhost:5000/
});

// CORS
app.UseCors("AllowSpecificOrigins");

app.UseDeveloperExceptionPage();

// HTTPS
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

//var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
//app.Run($"http://0.0.0.0:{port}");

app.Run();
