using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos8Company.Web.RepositoryLayer;
using Pos8Company.Web.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace NatFitPtCompany1.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Add application services.
       

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });


            services.AddControllers()
         .AddNewtonsoftJson(options =>
         {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
          });
           

            //  var con = @"Server = ID67541; Database = Positive8WebSite; User ID = P8WebSite; Password = 6TzpWpbRkXLBiCiB14bD; Integrated Security = False; Connect Timeout = 30;";
            string con = Configuration.GetSection("AppSettings").GetSection("ConnectionString").Value;
            //Dev Connection //  var con = @"Server = 185.216.76.36; Database = Positive8WebSite; User ID = P8WebSite; Password = 6TzpWpbRkXLBiCiB14bD; Integrated Security = False; Connect Timeout = 30;";

            services.AddDbContext<Positive8WebSiteContext>(option => option.UseSqlServer(con));


            services.AddScoped<IPositive8WebSiteRepository, Positive8WebSiteRepository>();

            services.AddOptions();

            services.AddAutoMapper();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseDefaultFiles();
            //  app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //   app.UseAuthorization();

       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
