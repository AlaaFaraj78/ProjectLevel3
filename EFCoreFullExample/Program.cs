using Microsoft.EntityFrameworkCore;
using Pioneersacademy.Domains.Interfaces;
using Pioneersacademy.Infrastacture;
using Pioneersacademy.Services;

namespace Pioneersacademy.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContextPool<TaskManagmentSystemDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUser, UserServices>();
        builder.Services.AddScoped<ITaskItem, TaskItemServices>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=User}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
