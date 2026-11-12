using Microsoft.EntityFrameworkCore;
using P5AspEntity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PizzaDb>(options => options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Appliquer la création de la base de données (SQLite) au démarrage
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaDb>();
    db.Database.EnsureCreated();

    if (!db.Pizzas.Any())
    {
        db.Pizzas.AddRange(
            new Pizza { Name = "Margherita", Description = "Tomate, mozzarella, basilic" },
            new Pizza { Name = "Pepperoni", Description = "Tomate, mozzarella, pepperoni" },
            new Pizza { Name = "Végétarienne", Description = "Tomate, mozzarella, légumes grillés" }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Ok(new { message = "API P5AspEntity - Minimal API avec EF Core et SQLite", endpoints = new[] { "/pizzas", "/swagger" } }));

app.MapGet("/pizzas", async (PizzaDb db) =>
    await db.Pizzas.ToListAsync());

app.MapGet("/pizzas/{id:int}", async (int id, PizzaDb db) =>
    await db.Pizzas.FindAsync(id) is Pizza pizza
        ? Results.Ok(pizza)
        : Results.NotFound());

app.MapPost("/pizzas", async (Pizza pizza, PizzaDb db) =>
{
    db.Pizzas.Add(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizzas/{pizza.Id}", pizza);
});

app.MapPut("/pizzas/{id:int}", async (int id, Pizza inputPizza, PizzaDb db) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();

    pizza.Name = inputPizza.Name;
    pizza.Description = inputPizza.Description;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/pizzas/{id:int}", async (int id, PizzaDb db) =>
{
    if (await db.Pizzas.FindAsync(id) is Pizza pizza)
    {
        db.Pizzas.Remove(pizza);
        await db.SaveChangesAsync();
        return Results.Ok(pizza);
    }

    return Results.NotFound();
});

app.Run();

// Rendre la classe Program accessible pour les tests éventuels
public partial class Program { }
