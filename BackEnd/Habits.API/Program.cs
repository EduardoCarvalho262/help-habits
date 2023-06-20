using Habits.Domain.Profiles;
using Habits.Infra.Interfaces;
using Habits.Infra.Repositories;
using Habits.Service.Interfaces;
using Habits.Service.Services;
using Microsoft.Azure.Cosmos;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHabitService, HabitService>();
builder.Services.AddScoped(typeof(IHabitsRepository), typeof(HabitRepository));
builder.Services.AddAutoMapper(typeof(HabitProfile));
builder.Host.UseSerilog();
var conectionString = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
var database = "HelpHabits";
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

builder.Services.AddScoped<ICosmosDBContext>(_ =>
{
    var cosmosClient = new CosmosClient(conectionString);
    return new CosmosDbRepository(database, cosmosClient);
});


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

app.Run();
