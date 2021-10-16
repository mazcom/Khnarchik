using _003.Asp.NetCoreWebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Source_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Настроить web host или web узел.
            // отвечает за запуск приложения, за его управление и время существования.
            // Т.е. запустит приложение, потом его запустит.
            WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build().Run();
        }        
    }
}
