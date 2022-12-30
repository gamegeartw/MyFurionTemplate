using System.Security.Claims;
using System.Text;
using Furion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace MyTemplate.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();

        // 啟用認證,這裡使用Cookie
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.LoginPath = "/Auth/Login";
            options.LogoutPath = "/";
            options.AccessDeniedPath = "/Auth/AccessDenied";
        });

        services.AddRazorPages(options =>
            {
                // 如果要啟用整個資料夾的授權,在這裡加
                options.Conventions.AuthorizeFolder("/Admin","RequireAdmin"); // 這裡加上限制條件的魔術字串,指定位置在AddAuthorization
                options.Conventions.AuthorizeFolder("/User");
            })
            .AddInjectBase();
        
        // 授權的策略,
        services.AddAuthorization(options =>
        {
            // 增加一條策略,角色是Admin的成員會被賦予RequireAdmin
            options.AddPolicy("RequireAdmin",policy=>policy.RequireRole("Admin"));
            options.AddPolicy("Over18",policy=>policy.RequireClaim("Over18","true"));
        });
        // services.AddAuthorization(options => 
        //     options.AddPolicy("Admin", policy => 
        //         policy.RequireRole("Admin")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInjectBase();

        app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
    }
}