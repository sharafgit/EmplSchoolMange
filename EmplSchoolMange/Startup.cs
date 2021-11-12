using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.BL.Repository;
using EmplSchoolMange.DAL.Database;
using AutoMapper;
using EmplSchoolMange.BL.Mapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace EmplSchoolMange
{
    //*******ConnectionString********
    public class Startup
    {
        public IConfiguration Conf { get; }
        public Startup(IConfiguration configuration)
        {
            Conf = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // services.AddLocalization(opt => opt.ResourcesPath = "");
            // XML ==> Json [{},{},{}]     // Serialize
            // Bascal ==> Camel
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //*******ConnectionString********
            //AddDbContextPool بتفتح اكثر من مسار تنفيذي علي السيكوال
            services.AddDbContextPool<DbContainer>(opts => 
            opts.UseSqlServer(Conf.GetConnectionString("DefaultConnection")));
            
            services.AddAutoMapper(x=>x.AddProfile(new DomainProfile()));

            #region Dependancy Injection
            //**** Dependancy Injection******

            ///1 ===> Take Instance Every Request
            //services.AddTransient<DepartmentRep>();

            //2 ===> Take One Instance For Each User
            services.AddScoped<IDepartmentRep, DepartmentRep>(); 
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();



            //3 ===> Take Shared Instance For All Users
            //services.AddSingleton<DepartmentRep>(); 
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Take Instance From Language
            var supportedCultures = new[] {
            new CultureInfo("ar-EG"),
            new CultureInfo("en-US"),
            };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
