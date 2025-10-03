using ECommerce.Data;
using ECommerce.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EcommerceDBConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceDBContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(ICommerceRepository<>), typeof(CommerceRepository<>));

//cors
builder.Services.AddCors(options => options.AddPolicy("MyTestCORS", policy =>
{
    //allow all origins
    // policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    // allow specific origins
    policy.WithOrigins("http://localhost3000");
}));

//disable CreatedATAction method from Supressing the Async Suffix
builder.Services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    // app.UseOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseCors("MyTestCORS");
app.UseHttpsRedirection();

app.Run();


