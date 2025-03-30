using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore;
using System.Reflection;
using TestAPI.Services;
using TestAPI;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Runtime;
using TestAPI.Objects;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<AppConfigService, AppConfigService>();

var OpenSenseMapApi = new OpenSenseMapApi();
builder.Configuration.GetRequiredSection(nameof(OpenSenseMapApi)).Bind(OpenSenseMapApi);
builder.Services.AddScoped<OpenSenseMapApiService, OpenSenseMapApiService>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<SenseBoxService, SenseBoxService>();

builder.Services.AddHttpClient<OpenSenseMapApiService>(c =>
{
    c.BaseAddress = new Uri(OpenSenseMapApi.BaseUrl);
    c.DefaultRequestHeaders.Accept.Clear();
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
