using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Database=memorygame;User=root;Password=password;Port=3306;CharSet=utf8;SslMode=none";
builder.Services.AddDbContext<MemoryGameContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddConnections();

builder.Services.AddDbContext<RankingContext>(options =>
    options.UseMySQL("Data Source=localhost;Database=memorygame;User ID=root;Password=password;Port=3306;sslmode=none;CharSet=utf8;")
   );

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL("Data Source=localhost;Database=memorygame;User ID=root;Password=password;Port=3306;sslmode=none;CharSet=utf8;")
    );


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

app.MapControllers();

app.Run();
