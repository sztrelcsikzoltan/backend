using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : Controller
    {
        [HttpPost]

        public string Post(string uId)
        {
            Program.Remove(uId);
            return "Sikeres logout.";
        }
        
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
