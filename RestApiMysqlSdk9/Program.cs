using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestApiMysqlSdk9.Data;

var builder = WebApplication.CreateBuilder(args);

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

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
//);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        new MySqlServerVersion(new Version(8, 0, 21)),
//        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
//    ));

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
//        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
//    )
//);

var connectionString = "Server=metro.proxy.rlwy.net;Port=39390;Database=railway;Uid=root;Pwd=HtNaPJHWGYDxjJPbBxVYMbPELReecJbr;SslMode=None;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null)
    )
);


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