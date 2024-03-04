using API.Extensions;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

//TODO: Add services to the container.
builder.Services.AddSingleton(new MongoDbOptions()
{
     Host = builder.Configuration["MongoDb:Host"],
     Database = builder.Configuration["MongoDb:Database"]
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<MessageService>();

var app = builder.Build();

//TODO: Configure the HTTP request pipeline.
app.MapMessageEndpoints();
app.MapUserEndpoints();

app.Run();
