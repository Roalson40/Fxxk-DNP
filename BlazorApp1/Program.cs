using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;
using Client.HttpClientServices.ClientInterface;
using Client.HttpClientServices.ClientServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5030") });
builder.Services.AddScoped<IPlayerHttpServices, PlayerHttpServices>();
await builder.Build().RunAsync();