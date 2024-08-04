using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Get connection string configuration
var connectionString = configuration.GetConnectionString("database") ??
                       throw new ArgumentNullException("configuration.GetConnectionString(\"database\")");

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Registers the given context as a service in the IServiceCollection.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adds services for controllers to the specified IServiceCollection.
builder.Services.AddControllers();

// Build the WebApplication.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.UseCors(myAllowSpecificOrigins);

// Run application
app.Run();