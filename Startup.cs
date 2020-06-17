using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDetailsEF.Adapter;
using BusinessDetailsEF.Interfaces;
using BusinessDetailsEF.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BusinessDetailsEF
{
    public class Startup
    {
        public IConfigurationRoot Configurations{ get; set;}
        public static string ConnectionString{get; private set; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IWebHostEnvironment env)
        {
            Configurations = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();

           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBusinessInterface, BusinessService>();
            services.AddSingleton<IBusinessAdapterInterface, BusinessAdapter>();
            services.AddSingleton<IAppointmentInterface, AppointmentsService>();
            services.AddSingleton<IAppointmentsAdapterInterface, AppointmentsAdapter>();
            services.AddCors(options =>
            options.AddPolicy(name: MyAllowSpecificOrigins,
                builder => { builder.WithOrigins("https://appointo.netlify.app", "http://appointo.netlify.app")
                    .AllowAnyHeader().AllowAnyMethod(); }));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConnectionString = Configurations["ConnectionStrings:DefaultConnection"];
        }
    }
}
