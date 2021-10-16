using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _003.Asp.NetCoreWebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string credentials = Configuration.GetConnectionString("TestDatabase");
            Console.WriteLine(credentials);
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
        }

        // С помощью билдера мы будем настраивать те модули которые мы в него и добавляем.
        // Н-р: контролеллеры, модули логирования.
        public void Configure(IApplicationBuilder app)
        {
            //
            app.UseRouting();
            // использовать точки входа. В качестве точек входы будем использовать контроллеры.
            // и перенаправлять запросы в в контроллеры.
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
