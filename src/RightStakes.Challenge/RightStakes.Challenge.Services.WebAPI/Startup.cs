using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RightStakes.Challenge.Infra.CrossCutting.IoC;
using RightStakes.Challenge.Infra.Data.Context;
using RightStakes.Challenge.Services.Crawler;
using RightStakes.Challenge.Services.Crawler.Factories;
using RightStakes.Challenge.Services.Crawler.Jobs;
using RightStakes.Challenge.Services.Crawler.Schedules;
using RightStakes.Challenge.Services.WebAPI.Configurations;
using System.IO;

namespace RightStakes.Challenge.Services.WebAPI
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
            services.AddDbContext<RightStakesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v1"));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAutoMapperSetup();
            services.AddMediatR(typeof(Startup));
            services.AddMemoryCache();

            #region Config Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "RightStakes Challenge",
                    Version = "v1",
                    Description = "API REST created to meet the challenge proposed by RightStakes",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "André Oliveira",
                        Url = new System.Uri("https://www.rightstakes.com"),
                        Email = "andredeveloper59@gmail.com"
                    }
                });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
            #endregion


            #region Configure Crawlers
            // Add Quartz services
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            // Add our job
            services.AddSingleton<CurrencyConvertionApiCrawlerJob>();
            services.AddSingleton<CryptoCurrencyApiCrawlerJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CurrencyConvertionApiCrawlerJob),
                cronExpresion: "* 0/5 * * * ?"));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CryptoCurrencyApiCrawlerJob),
                cronExpresion: "* 0/5 * * * ?"));

            services.AddHostedService<RightStakesCrawlerHostedService>();
            #endregion

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "RigthStakes Challenge");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
