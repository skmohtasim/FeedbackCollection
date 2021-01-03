using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackCollection.BL.Services;
using FeedbackCollection.DAL;
using FeedbackCollection.DAL.DBContextFC;
using FeedbackCollection.DAL.Models;
using FeedbackCollection.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FeedbackCollection.API
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
            services.AddControllers();
            var connctionString = Configuration.GetConnectionString("FCConnection");
            services.AddDbContext<DBContextFeedbackCollection>(options => options.UseSqlServer(connctionString));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(new string[] { "http://localhost:3000" })
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddSingleton<Config>(new Config(connctionString));

            services.AddScoped<IFeedbackCollection, FeedbackCollection.BL.Services.FeedbackCollection>();
            services.AddScoped<IFeedbackCollectionRepository, FeedbackCollectionRepository>();
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
