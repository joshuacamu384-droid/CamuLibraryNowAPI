var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var renderPort = Environment.GetEnvironmentVariable("PORT");

if (!string.IsNullOrEmpty(renderPort))
{
    // Production environment on Render
    app.Urls.Add($"0.0.0:{renderPort}");
}
else
{
    // Local development environment
    app.Urls.Add("http://localhost:5100");
    app.Urls.Add("https://localhost:5101");
}

app.UseSwagger();
app.UseSwaggerUI();

if (string.IsNullOrEmpty(renderPort))
{
    app.UseHttpsRedirection();
}

app.MapGet("/", () => "CamuLibraryNowAPI is running 🚀");
app.MapControllers();

app.Run();
