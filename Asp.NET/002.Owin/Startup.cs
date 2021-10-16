using System.Web.Http;
using Owin;

namespace _002.Owin
{
    public class Startup
    {
        // Это соглашение описывает фонфигурацию конвеера обработки сообщений
        // При запуске WEB приложения  катана ищет класс с именем Sturtup.
        // И вызывает его метод Configuration.
        // В этот метод передается с борщик нашего приложения app.
        // к этому приложению мы и сможем подключить все наши модули. 
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule), "OwinLogger: ");

            var config  = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "{controller}");
            app.UseWebApi(config);
            
        }
    }
}