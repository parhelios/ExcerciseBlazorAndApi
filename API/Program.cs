using API.Extensions;
using DataAccess;
using DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//TODO: Add services to the container.
builder.Services.AddSingleton(new MongoDbOptions()
{
     Host = builder.Configuration["MongoDb:Host"],
     Database = builder.Configuration["MongoDb:Database"]
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();

//TODO: Configure the HTTP request pipeline.
app.MapMessageEndpoints();
app.MapUserEndpoints();

app.Run();
