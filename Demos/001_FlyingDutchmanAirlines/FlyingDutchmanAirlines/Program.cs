using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FlyingDutchmanAirlines
{
  class Program
  {
    static void Main(string[] args)
    {
      InitalizeHost();
    }

    private static void InitalizeHost()
    {
      Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder =>
                {
                  builder.UseStartup<Startup>();
                  builder.UseUrls("http://0.0.0.0:8080");
                }).Build().Run();
    }

  }

  class Startup
  {
    public void Configure(IApplicationBuilder app)
    {
      app.UseRouting();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
    }
  }
}
