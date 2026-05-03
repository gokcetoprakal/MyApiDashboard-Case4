using MyApiDashboard.Services.CinemaServices;
using MyApiDashboard.Services.CryptoServices;
using MyApiDashboard.Services.ExchangeServices;
using MyApiDashboard.Services.FuelServices;
using MyApiDashboard.Services.LiveMatchServices;
using MyApiDashboard.Services.MusicServices;
using MyApiDashboard.Services.NewsServices;
using MyApiDashboard.Services.QuoteServices;
using MyApiDashboard.Services.RecipeServices;
using MyApiDashboard.Services.WeatherServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICinemaService, CinemaService>();
builder.Services.AddHttpClient<ICryptoService, CryptoService>();
builder.Services.AddHttpClient<IExchangeService, ExchangeService>();
builder.Services.AddHttpClient<IFuelService, FuelService>();
builder.Services.AddHttpClient<ILiveMatchService, LiveMatchService>();
builder.Services.AddHttpClient<IMusicService, MusicService>();
builder.Services.AddHttpClient<INewsService, NewsService>();
builder.Services.AddHttpClient<IQuoteService, QuoteService>();
builder.Services.AddHttpClient<IRecipeService, RecipeService>();
builder.Services.AddHttpClient<IWeatherService, WeatherService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
