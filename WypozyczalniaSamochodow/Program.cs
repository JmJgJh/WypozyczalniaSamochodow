using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaSamochodow.Components;
using WypozyczalniaSamochodow;
using Microsoft.Extensions.Options;

namespace WypozyczalniaSamochodow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            // Odczyt connection stringa z appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Rejestracja DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "auth_token";
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Wymusza wysy³anie ciasteczek tylko przez HTTPS
                    options.Cookie.SameSite = SameSiteMode.Lax; // Mo¿esz u¿yæ Lax, Strict lub None, w zale¿noœci od wymagañ
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/access-denied";
                    options.Cookie.HttpOnly = true; // Oznacza, ¿e ciasteczko jest dostêpne tylko przez HTTP (nie przez JavaScript)
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireRole("Administrator")));
            builder.Services.AddCascadingAuthenticationState();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection(); // Przekierowuje z HTTP na HTTPS
            }

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
