var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Pastikan ini ada
builder.Services.AddSwaggerGen(); // Tambahkan Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Tambahkan ini
    app.UseSwaggerUI(); // Tambahkan ini
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
