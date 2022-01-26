

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLibCoreWeb();
builder.Services.AddLibDapperCore(config =>
{
    config.SetDefaultConnectionString(WebApplication1.SharedSettings.ConnectionString);
    config.UseFileLogging();
});
//builder.Services.AddLibLocalizationWeb(config =>
//{
//    config.SetConnectionString(WebApplication1.SharedSettings.ConnectionString);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
