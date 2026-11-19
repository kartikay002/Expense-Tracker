
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get Supabase connection string
var connectionString = builder.Configuration
    .GetConnectionString("Supabase");

// Validate connection string
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Supabase connection string is missing."
    );
}

// Register PostgreSQL DataSource
builder.Services.AddSingleton<NpgsqlDataSource>(
    _ => NpgsqlDataSource.Create(connectionString)
);

var app = builder.Build();

// Configure Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
