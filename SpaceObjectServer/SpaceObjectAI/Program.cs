using OpenAI;
using SpaceObjectAI.Interfaces;
using SpaceObjectAI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add OpenAIAPI as a service
builder.Services.AddTransient<OpenAIClient>(serviceProvider =>
{
    // Get the API key from configuration (appsettings.json or environment variable)
    string? apiKey = builder.Configuration["OpenAI:ApiKey"];
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("OpenAI API Key is not configurated");
    }

    // Initialize and return the OpenAIAPI instance
    return new OpenAIClient(apiKey);
});
builder.Services.AddControllers();
builder.Services.AddScoped<IAsteroidImageRepository, AsteroidImageRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
