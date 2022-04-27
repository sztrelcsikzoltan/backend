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

        [HttpPost]
        [Route("/Coworker/AddPhone")]
        public string AddPhone([FromBody] Phone phone, int coworkerId)
        {
            return service.AddPhone(phone, coworkerId);
        }

        [HttpPut]
        [Route("/Coworker/UpdatePhone")]
        public string UpdatePhone([FromBody] Phone phone, int coworkerId)
        {
            return service.UpdatePhone(phone, coworkerId);
        }

        [HttpDelete]
        [Route("/Coworker/DeletePhone")]
        public string DeletePhone(int id)
        {
            return service.DeletePhone(id);
        }

        [HttpPut]
        [Route("/Coworker/TransferPhone")]
        public string TransferPhone(int phoneId, int newCoworderId)
        {
            return service.PhoneTransfer(phoneId, newCoworderId);
        }
    }
}
