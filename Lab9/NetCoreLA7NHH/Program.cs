// Author: NHH

using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7NHH.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NHHAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NHHConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NHHAppDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/NHHHome/NHHError");
    app.UseHsts();
}

var supportedCultures = new[] { new CultureInfo("en-US") };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
localizationOptions.RequestCultureProviders.Clear();
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=NHHDashboard}/{action=NHHIndex}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NHHHome}/{action=NHHIndex}/{id?}");

app.Run();
