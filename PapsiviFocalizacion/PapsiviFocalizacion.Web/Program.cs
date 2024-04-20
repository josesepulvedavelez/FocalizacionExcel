using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PapsiviFocalizacion.Web;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();

var appSettings = new MyAppSettings();
builder.Configuration.Bind("MyAppSettings", appSettings);

builder.Services.AddScoped(sp =>
{
    return new HttpClient
    {
        BaseAddress = new Uri(appSettings.BaseUrl)
    };
});

await builder.Build().RunAsync();
