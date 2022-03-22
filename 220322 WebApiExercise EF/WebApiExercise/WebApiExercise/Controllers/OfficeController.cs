using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(string officeCode) // get
        {
            List<Office> offices = new List<Office>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (officeCode == null)
                    {
                    return new JsonResult(context.Offices.ToList()); // get all offices
                    }
                    else
                    {
                        List<Office> office = new List<Office>(context.Offices.Where(o => o.OfficeCode == officeCode));
                        return new JsonResult(office); // get one office
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Office office) // insert new office
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Offices.Add(office);
                    context.SaveChanges();
                    return new JsonResult("Iroda felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Office office) // update office
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Offices.Update(office);
                    context.SaveChanges();
                    return new JsonResult("Az adatok módosítása megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpDelete]
        public JsonResult Delete(string officeCode) // delete office
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Office office = context.Offices.Find(officeCode);
                    Office office = new Office();
                    office.OfficeCode = officeCode;
                    context.Offices.Remove(office);
                    context.SaveChanges();
                    return new JsonResult("Törlés sikeresen megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }


    }
}
