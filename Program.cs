using System.Collections;
using Microsoft.EntityFrameworkCore;
using whttngs_backend;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("MYSQL_URL") ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<WhttngsDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080"; // Fallback to 8080 if not set
builder.WebHost.UseKestrel()
    .ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(int.Parse(port)); // Listen on 0.0.0.0
    });

var app = builder.Build();

// Test the database connection and query
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WhttngsDbContext>();

    try
    {
        // Attempt to connect to the database
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database connection successful.");

            // Try a simple query on an empty table
            var postCount = dbContext.Posts.Count();
            Console.WriteLine($"Connected to the database. Post count: {postCount}");
        }
        else
        {
            Console.WriteLine("Database connection failed.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection error: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();