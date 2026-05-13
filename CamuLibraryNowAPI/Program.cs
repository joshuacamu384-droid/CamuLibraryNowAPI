var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure ports for both Local Development and Render Production
var renderPort = Environment.GetEnvironmentVariable("PORT");

if (!string.IsNullOrEmpty(renderPort))
{
    // Render production environment
    app.Urls.Add($"0.0.0:{renderPort}");
}
else
{
    // Local development environment (supports both HTTP and HTTPS testing)
    app.Urls.Add("http://localhost:5100");
    app.Urls.Add("https://localhost:5101");
}

app.UseSwagger();
app.UseSwaggerUI();

// Only redirect to HTTPS locally; Render handles this automatically in production
if (string.IsNullOrEmpty(renderPort))
{
    app.UseHttpsRedirection();
}

app.MapGet("/", () => "CamuLibraryNowAPI is running 🚀");
app.MapControllers();

app.Run();

