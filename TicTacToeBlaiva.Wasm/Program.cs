using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicTacToeBlaiva.Wasm;
using TicTacToeBlaiva.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/") });

builder.Services.AddScoped<IJugadoresApiService, JugadoresApiService>();
builder.Services.AddScoped<IPartidasApiService, PartidasApiService>();
builder.Services.AddScoped<IMovimientosApiService, MovimientosApiService>();

await builder.Build().RunAsync();
