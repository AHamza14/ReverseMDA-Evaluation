using SchoolManagement.WindowsApp.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using SchoolManagement.Infrastructure;
using SchoolManagement.Core.Interafces;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Core.Services;
using SchoolManagement.Core.Entities;
using SchoolManagement.SharedKernel.Interfaces;

namespace SchoolManagement.WindowsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddDbContext<StudentManagementContext>(options => options.UseSqlServer(@"Server=.;Database=StudentManagementDB;Trusted_Connection=True;"));
                 services.AddSingleton<StudentForm>();
                 services.AddLogging(configure => configure.AddConsole());
                 services.AddScoped<IStudentRepository, StudentRepository>();
                 services.AddScoped<IAsyncRepository<Course>, EfRepository<Course>>();

                 services.AddScoped<IStudentService, StudentService>();
                 //services.AddScoped<ICourseRepository, CourseRepository>();
                 //services.AddScoped<ICourseService, CourseService>();

             });

            var host = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var forms = services.GetRequiredService<StudentForm>();
                    Application.Run(forms);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            }

        }
    }
}
