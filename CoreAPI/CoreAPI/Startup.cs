using CoreAPI.Application.Services;
using CoreAPI.Domain.Interfaces.Repositories;
using CoreAPI.Domain.Interfaces.Services;
using CoreAPI.Hubs;
using CoreAPI.Infra.Data.Contexts;
using CoreAPI.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200");
            }));

            services.AddSignalR();

            services.AddDbContext<SQLiteDbContext>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<SQLiteDbContext>();

            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<SQLiteDbContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SubscriptionHub>("/services/subscription");
            });
        }
    }
}
