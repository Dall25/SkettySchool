using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkettySchool.Data;
using SkettySchoolServices.Implementation;
using SkettySchoolServices.Interfaces;
using SkettySchoolServices.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SkettySchool
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SkettySchoolContext>();
            services.AddScoped<ISkettySchoolRepository, SkettySchoolRepository>();
            services.AddScoped<IPupilService, PupilService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();

            services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<TeacherValidator>();
                options.DisableDataAnnotationsValidation = true;
            });


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();

            

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
