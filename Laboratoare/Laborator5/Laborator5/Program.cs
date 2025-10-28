using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Laborator5.Models;

// Nu declara 'builder' de două ori! Începe direct cu var builder = ...
var builder = WebApplication.CreateBuilder(args); 

// Configurare Connection String (ArticlesDB conform Laborator 5)
var connectionString = builder.Configuration.GetConnectionString("ArticlesDB") 
                       ?? throw new InvalidOperationException("Connection string 'ArticlesDB' not found.");

// Configurare MySQL Server Version (folosește versiunea ta reală, ex. 8.0.31)
var serverVersion = ServerVersion.Parse("8.0.31"); 

// Adaugă AppDbContext ca serviciu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Nu declara 'app' de două ori!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articles}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
