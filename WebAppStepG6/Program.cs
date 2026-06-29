using Microsoft.EntityFrameworkCore;
using WebAppStepG6.Models;
using WebAppStepG6.Repository;

namespace WebAppStepG6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.//Day6
            //Type of Service
            //1) built in service already register
            //2) built in service need to register 
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StepsContext>(optionsBuilder =>
            {
                 optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });//register StepsContext,dbcontextoptions

            //3) Custom service need to register
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IService,Service>();

            var app = builder.Build();

            // Configure the HTTP request pipeline. //Middleware
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
        }
    }
}
