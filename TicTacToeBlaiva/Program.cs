using TicTacToeBlaiva.Components;
using TicTacToeBlaiva.DAL;
using TicTacToeBlaiva.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Inyección del Contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

//Inyección del Service
builder.Services.AddScoped<JugadoresService>();
builder.Services.AddScoped<PartidasService>();
builder.Services.AddScoped<MovimientosService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();