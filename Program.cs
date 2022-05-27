using ContosoPizza.Services;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// Additional using declarations
using ContosoPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the PizzaContext
//builder.Services.AddEntityFrameworkMySql().AddDbContext<PizzaContext>(ServiceLifetime.Singleton);
//builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");    
builder.Services.AddDbContext<PizzaContext>(Options => 
        Options.UseMySql(@"Server=localhost;database=contosopizza;uid=root;pwd='Tulumbas500*';",
        ServerVersion.AutoDetect(@"Server=localhost;database=contosopizza;uid=root;pwd='Tulumbas500*';")));
// Add the PromotionsContext
builder.Services.AddScoped<PizzaService>();
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

// Add the CreateDbInNotExists method call
app.CreateDbIfNotExists();


app.Run();
