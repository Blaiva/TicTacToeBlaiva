using TicTacToeBlaiva.Components;
using TicTacToeBlaiva.DAL;
using TicTacToeBlaiva.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<JugadoresService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();