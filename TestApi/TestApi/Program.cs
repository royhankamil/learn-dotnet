using TestApi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Pastikan ini ada
builder.Services.AddSwaggerGen(); // Tambahkan Swagger

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Tambahkan ini
    app.UseSwaggerUI(); // Tambahkan ini
}

app.UseAuthorization();
app.MapControllers();

app.Run();
