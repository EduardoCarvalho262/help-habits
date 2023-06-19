using Habits.Domain.Profiles;
using Habits.Infra.Interfaces;
using Habits.Infra.Repositories;
using Habits.Service.Interfaces;
using Habits.Service.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IHabitService, HabitService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(CosmosDbRepository<>));
builder.Services.AddAutoMapper(typeof(HabitProfile));
var conectionString = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
var databasename = "HelpHabits";

builder.Services.AddScoped<ICosmosDBContext>(_ =>
{
    var cosmosClient = new CosmosClient(conectionString);
    return new CosmosDbRepository(cosmosClient, database);
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
