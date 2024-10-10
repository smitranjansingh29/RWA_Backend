using Microsoft.EntityFrameworkCore;
using RWA.Data; // Add this for your DataContext
using RWA.Models;
using RWA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext with a connection string
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddSingleton<SmtpService>();
builder.Services.AddSingleton<Fast2SmsService>();
builder.Services.AddSingleton<OtpService>();
builder.Services.AddControllers();

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from specific origins (frontend URL)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder => builder
         .WithOrigins("https://192.168.29.20:7031") // Allow both localhost and LAN URL
        .AllowAnyOrigin()
        .AllowAnyHeader()
            .AllowAnyMethod());
            //.AllowCredentials());  // Include this if credentials (e.g., cookies) are involved
});

/*
// Configure Kestrel for HTTP and HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5077); // HTTP port
    options.ListenAnyIP(7031, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS port with default dev certificate
    });
});
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply the CORS policy globally
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
