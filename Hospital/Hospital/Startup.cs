using Core.Abstractions;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Hospital
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
            services.AddCors((c)=>c.AddPolicy("AllowEverything", (builder)=>builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
            services.AddControllers();
            string connectionString = Configuration.GetConnectionString("MyServer");
            services.AddDbContext<HospitalContext>((options)=>options.UseSqlite(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSwaggerGen((c)=>c.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "HospitalAPI",
                Version = "v1"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowEverything");

            app.UseSwagger();

            app.UseSwaggerUI((c) =>c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
