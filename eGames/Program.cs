using eGames.Data;
using eGames.Data.Cart;
using eGames.Data.Services;
using eGames.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Services configuration
builder.Services.AddScoped<IDevelopersService, DevelopersService>();
builder.Services.AddScoped<IPublishersService, PublishersService>();
builder.Services.AddScoped<IPlatformsService, PlatformsService>();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(serviceProvicer => ShoppingCart.GetShoppingCart(serviceProvicer));

// Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Shared/NotFound");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "catchall",
            pattern: "{*url}",
            defaults: new { controller = "Games", action = "NotFound" });
});

// Seed Database
AppDbInitializer.Seed(app);
await AppDbInitializer.SeedUsersAndRolesAsync(app);

app.Run();