using AgendaLive.Api.Models;
using AgendaLive.Api.Repository;
using AgendaLive.Api.Repository.Interfaces;
using AgendaLive.Api.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace AgendaLive.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AgendaLiveDatabaseSettings>(Configuration.GetSection(nameof(AgendaLiveDatabaseSettings)));

            services.AddSingleton<IAgendaLiveDatabaseSettings>(al => al.GetRequiredService<IOptions<AgendaLiveDatabaseSettings>>().Value);
            services.AddScoped<LiveService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {                     
                    Title = "Api Agenda Live", 
                    Description = "Api CRUD agenda de lives",
                    Version = "v1",
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaLive.Api v1"));
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
