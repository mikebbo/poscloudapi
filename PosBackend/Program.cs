using PosBackend.models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("POSDatabase")));
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow only React app origin
              .AllowAnyHeader()                  // Allow any headers
              .AllowAnyMethod();                 // Allow GET, POST, PUT, DELETE, etc.
    });
});
builder.Services.AddCors();
// Remove EventLog logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Add Console logger instead


var app = builder.Build();

// Use CORS before other middleware
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
// Use routing
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});




app.Run();

