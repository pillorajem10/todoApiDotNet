using todoApiDotNet.Config;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load .env variables
Env.Load();

// Add services
builder.Services.AddControllers();

// Register DB connection
builder.Services.ConfigureDatabase(builder.Configuration);

var app = builder.Build();

// Test DB connection
app.TestDatabaseConnection();

app.MapGet("/", () => "Todo API is running...");
app.MapControllers();

app.Run();
