using System.Reflection;
using Copilot.Data;
using Copilot.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("DivineShopDb"));

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Configure Swagger documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Divine Shop API",
        Version = "v1",
        Description = "RESTful API for the Divine Shop e-commerce application",
        Contact = new OpenApiContact
        {
            Name = "Divine Shop",
            Email = "contact@divineshop.com",
            Url = new Uri("https://divineshop.com")
        }
    });

    // Include XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    // Enable XML comments for API documentation
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Divine Shop API V1");
        options.RoutePrefix = "swagger"; // Make sure this matches launchUrl in launchSettings.json
    });

    // Seed the database
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAllOrigins");

// Enable serving static files such as images
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
