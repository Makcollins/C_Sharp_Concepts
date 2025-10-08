using Microsoft.EntityFrameworkCore;
using StudentsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

// builder.Services.AddDbContext<CollegeContext>(options =>
// options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Mak.2017;Database=college_db"));
builder.Services.AddDbContext<CollegeContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("CollegeDBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapControllers();
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
