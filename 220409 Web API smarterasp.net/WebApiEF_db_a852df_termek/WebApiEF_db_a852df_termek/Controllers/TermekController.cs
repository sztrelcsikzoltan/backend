using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApiEF_db_a852df_termek.Models;
using WebApiEF_db_a852df_termek.Services;

namespace WebApiEF_db_a852df_termek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TermekController : Controller
    {
        private readonly TermekService termekService;
        public TermekController (TermekService termekService)
        {
            this.termekService = termekService;
        }

        [HttpGet]
        [Route("/Termekek")]
        public IEnumerable<Termekek> GetTermekek()
        {
            return this.termekService.GetTermekek();
        }

        [HttpGet]
        public Termekek GetTermekById(int id)
        {
            return termekService.GetTermekById(id);
        }

        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        public string AddTermek(Termekek termek)
        {
            return termekService.AddTermek(termek);
        }

        [HttpPut]
        public string UpdateTermek (Termekek termek)
        {
            return termekService.UpdateTermek(termek);
        }

        [HttpDelete]
        public string DeleteTermek (int id)
        {
            return termekService.DeleteTermek(id);
        }

    }
}
