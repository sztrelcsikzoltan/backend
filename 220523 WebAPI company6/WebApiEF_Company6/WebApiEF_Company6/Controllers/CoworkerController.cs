using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApiEF_Company6.DTOs;
using WebApiEF_Company6.Models;

namespace WebApiEF_Company6.Controllers
{
    [ApiController]
    [Route("api")]
    public class CoworkerController : Controller
    {
        private readonly company6Context context;
        public CoworkerController(company6Context context)
        {
            this.context = context;
        }

        [HttpGet("GetCoworkerByEmail")]
        public IActionResult GetCoworkerByEmail([Required] string email)
        {
            try
            {
                Coworker coworker = context.Coworkers.Include(co => co.Notebooks).Include(co => co.Phones).FirstOrDefault(co => co.Email == email);

                if (coworker == null)
                {
                    return NotFound($"A munkatárs nem található a(z) '{email}' email címmel.");
                }
                
                return Ok(coworker);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCoworkerNumber")]
        public IActionResult GetCoworkerNumber()
        {
            try
            {
                int count = context.Coworkers.Count();
                if (count == 0)
                {
                    return NotFound($"Nem található munkatárs az adatbázisban!");
                }

                return Ok(count);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

       
        [HttpPost("AddCoworker")]
        public IActionResult AddCoworker(CoworkerDto coworkerDto, string uid)
        {
            try
            {
                if (Program.UID != uid)
                {
                    return Unauthorized($"Nem jogosult a kérés végrehajtására!");
                }
                if (coworkerDto.Name.Length < 4 || coworkerDto.Email.Length < 4)
                {
                    return BadRequest($"A mezőket ki kell tölteni!");
                }
                bool coworkerExists = context.Coworkers.Any(co => co.Email == coworkerDto.Email);
                if (coworkerExists)
                {
                    return BadRequest($"Munkatárs már létezik a(z) '{coworkerDto.Email}' email címmel!");
                }

                Coworker coworker = new Coworker()
                {
                    Name = coworkerDto.Name,
                    Email = coworkerDto.Email
                };
                context.Coworkers.Add(coworker);
                context.SaveChanges();
                return Ok($"A munkatárs a(z) {coworker.Id} azonosítóval hozzáadásra került.");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCoworker")]
        public IActionResult UpdateCoworker(Coworker coworker, string uid)
        {
            try
            {
                if (Program.UID != uid)
                {
                    return Unauthorized($"Nem jogosult a kérés végrehajtására!");
                }
                if (coworker.Id < 1 || coworker.Name.Length < 4 || coworker.Email.Length < 4)
                {
                    return BadRequest($"A mezőket ki kell tölteni!");
                }
                Coworker coworker1 = context.Coworkers.Find(coworker.Id);

                if (coworker1 == null)
                {
                    return BadRequest($"a munkatárs nem létezik a(z) '{coworker.Id}' azonosítóval!");
                }

                coworker1.Name = coworker.Name;
                coworker1.Email = coworker.Email;
                context.SaveChanges();
                return Ok($"A munkatárs a(z) {coworker.Id} azonosítóval módosításra került.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCoworker")]
        public IActionResult DeleteCoworker([Required] int coworkerId, string uid)
        {
            try
            {
                if (Program.UID != uid)
                {
                    return Unauthorized($"Nem jogosult a kérés végrehajtására!");
                }
                if (coworkerId < 1)
                {
                    return BadRequest($"A mezőket ki kell tölteni!");
                }
                Coworker coworker = context.Coworkers.Find(coworkerId);

                if (coworker == null)
                {
                    return BadRequest($"a munkatárs nem létezik a(z) '{coworkerId}' azonosítóval!");
                }
                context.Coworkers.Remove(coworker);
                context.SaveChanges();
                return Ok($"A munkatárs a(z) {coworker.Id} azonosítóval törlésre került.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
