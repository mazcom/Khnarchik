using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _002.Owin.Controllers
{
    public class HomeController : ApiController
    {
        
        public IEnumerable<int> GetValues()
        {
            return Enumerable.Range(1, 10);
        }
    }
}
