using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ToDo_List_server.Data;
using ToDo_List_server.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<DB>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDB"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IRepository, SQLRepository>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
