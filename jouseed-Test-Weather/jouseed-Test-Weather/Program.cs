using jouseed_Test_Weather.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DI for repository class
builder.Services.AddSingleton<IWeatherForecastRepo, WeatherForecastRepo>();

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
//Changing the routing to serachCity
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=weatherforecast}/{action=searchcity}/");

app.Run();
