using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using MemoryGame.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddConnections();

builder.Services.AddDbContext<MemoryGameContext>(options =>
    options.UseMySQL("Data Source=localhost;Database=memorygame;User ID=root;Password=123456;Port=3306;sslmode=none;CharSet=utf8;")
   );

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySQL("Data Source=localhost;Database=memorygame;User ID=root;Password=admin;Port=3306;sslmode=none;CharSet=utf8;")
//    );

// Add authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });


// Add services
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
