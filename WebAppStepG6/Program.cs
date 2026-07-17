using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppStepG6.Filtters;
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
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());//global filter (app scop)
            //});
            builder.Services.AddDbContext<StepsContext>(optionsBuilder =>
            {
                 optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });//register StepsContext,dbcontextoptions
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout= TimeSpan.FromMinutes(30);
            });//used default
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<StepsContext>();



            //3) Custom service need to register
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IService,Service>();

            var app = builder.Build();

            // Configure the HTTP request pipeline. //Middleware
            #region Custom PipleLine
            //inline middleware
            //app.Use(async (httpContxt,nextMiddleware) => {
            //    await httpContxt.Response.WriteAsync("1- Middleware 1 \n");
            //    //------------
            //    await nextMiddleware.Invoke();
            //    //----------------
            //    await httpContxt.Response.WriteAsync("1-1 Middleware 1-1 \n");

            //});
            //app.Use(async (httpContxt, nextMiddleware) => {
            //    await httpContxt.Response.WriteAsync("2- Middleware 2 \n");
            //    //------------
            //    await nextMiddleware.Invoke();
            //    //----------------
            //    await httpContxt.Response.WriteAsync("2-2 Middleware 2-2 \n");

            //});
            //app.Run(async(httpContext) => {
            //    await httpContext.Response.WriteAsync("3- Middleware 3 \n");
            //});

            #endregion
            #region builtin Pipleline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//Department/index   //assets/img/icon.png

            app.UseSession();//write session ,csreat session

            app.UseRouting();//security (Mapping) seeltc specifi crout to execute

            app.UseAuthorization();

            //app.MapControllerRoute(name: "rout1", pattern: "r1/{age:int:range(20,60)}/{name?}",
            //    defaults:new {controller="Route",action="Method1" });//route
            //app.MapControllerRoute(name: "rout1", pattern: "{controller=Home}/{action=Index}/{id?}");//route constrint

            //app.MapControllerRoute(name: "rout2", pattern: "r2",
            //    defaults: new { controller = "Route", action = "Method2" });

            //app.MapControllerRoute(name: "emp", pattern: "e/{action}",
            //    defaults: new { controller = "Employee", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//staff (decalre route ,execute)
            #endregion
            app.Run();
        }

    }
}
