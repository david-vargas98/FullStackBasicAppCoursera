using ServerAppdotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(builder =>
   {
      builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); 
   });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.MapGet("/api/productlist", () =>
{
    var products = new List<Product>
    {
        new(
            Id: 1, Name: "Laptop", Price: 1200.50m, Stock: 25, Category: new Category( Id: 101, Name: "Electronics")
        ),
        new(
            Id: 2, Name: "Headphones", Price: 50.00m, Stock: 100, Category: new Category( Id: 102, Name: "Accessories")
        )
    };

    return TypedResults.Ok(new
    {
        data = products,
        count = products.Count
    });
});

app.Run();