using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TechFlixApi.Models.CacheService;
using TechFlixApi.Models.Catelogue;
using TechFlixApi.Models.Response;
using TechFlixApi.Services;

namespace TechFlixApi
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
            services.AddTransient<IFilmsService, FilmsService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<ICatalogueService, CatalogueService>();
            services.AddTransient<IMetadataService, MetadataService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<IFeaturesService, FeaturesService>();
            services.AddSingleton<ICacheService, CacheService>();
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}