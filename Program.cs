using la_mia_pizzeria_static.Models.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//per far partire con db se funziona
builder.Services.AddScoped<IDbPizzaRepository, DbPizzaRepository>();

//per far partire con lista se offline
//builder.Services.AddScoped<IDbPizzaRepository, ListPizzaRepository>();

//per eliminare problema ciclo infinito, da installare ad ogni progetto il seguente pacchetto
//dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.0.0
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//da inserirsi sotto a AddControllersWithViews
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Index}/{id?}");

app.Run();
