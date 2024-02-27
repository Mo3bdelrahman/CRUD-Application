using CRUD_Application.Models;
using CRUD_Application.Models.Data;
using CRUD_Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(d =>
            {
                d.UseSqlServer("Data Source=.;Initial Catalog=EFApplication;Integrated Security=True;Trust Server Certificate=True");
            });
            builder.Services.AddScoped<IRepo<Student>,StudentRepo>();
            builder.Services.AddScoped<IRepo<Department>,DepartmentRepo>();
            builder.Services.AddScoped<IRepo<Course>,CourseRepo>();
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
        }
    }
}
