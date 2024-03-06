using Client.Components;
using Client.Services;
using MudBlazor.Services;
using Shared.DTOs;
using Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();


builder.Services.AddHttpClient("messageApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5175");
});

builder.Services.AddSingleton<IRepository<UserDto>, UserService>();
builder.Services.AddSingleton<IRepository<MessageDto>, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
     app.UseExceptionHandler("/Error", createScopeForErrors: true);
     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
     app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
