using apiContact.Data;
using apiContact.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact API", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ContactsDB"));

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

// Configure CORS for Angular app (? must be before builder.Build())
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:9887")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API v1");
        c.RoutePrefix = "swagger"; // serves at /swagger/index.html
    });
}

app.UseCors("AngularApp");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
