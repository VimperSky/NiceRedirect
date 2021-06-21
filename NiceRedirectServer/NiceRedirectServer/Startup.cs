using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NiceRedirectServer.Data;
using NiceRedirectServer.Logic;
using NiceRedirectServer.Storage;

namespace NiceRedirectServer
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
            services.AddDbContext<RedirectContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<EndPointOptions>(Configuration.GetSection(EndPointOptions.Name));
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "NiceRedirectServer", Version = "v1"});
            });

            services.AddScoped<IStorage, DbStorage>();
            services.AddScoped<RedirectCreator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NiceRedirectServer v1"));
            }
            
            app.UseRouting();
            
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200"));
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("redirect", 
                    "/{*key}", 
                    new {controller = "Redirect", action = "DoRedirect"});
            });
        }
    }
}