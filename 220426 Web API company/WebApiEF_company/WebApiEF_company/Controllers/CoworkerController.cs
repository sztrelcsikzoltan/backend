using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApiEF_company.Models;
using WebApiEF_company.Services;

namespace WebApiEF_company.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoworkerController : ControllerBase
    {
        private readonly CoworkerService service;
        public CoworkerController(CoworkerService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/GetCoworkerByEmail")]
        public Coworker GetCoworkerByEmail([Required] string email)
        {
            return service.GetCoworkerByEmail(email);
        }
        
        [HttpGet]
        [Route("/GetCoworkerNumber")]
        public int GetCoworkerNumber()
        {
            return service.GetCoworkerNumber();
        }
    }
}
