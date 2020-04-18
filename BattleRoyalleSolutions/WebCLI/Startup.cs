using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebCLI.Domain.Interfaces.Services;
using WebCLI.Application.Services;
using Microsoft.Extensions.Configuration;
using WebCLI.Application.Settings;

namespace WebCLI
{
    public class Startup
    {
        private readonly IServiceInformation _serviceInformation;
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
            _serviceInformation = new ServiceInformation(_configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IServiceInformation, ServiceInformation>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddControllers();

            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(OnStart);
            applicationLifetime.ApplicationStopping.Register(OnShutdown);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void OnStart()
        {
            _serviceInformation.Subscribe();
        }

        private void OnShutdown()
        {
            _serviceInformation.Unsubscribe();
        }
    }
}
