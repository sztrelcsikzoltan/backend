using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductlineController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(string productLine) // get
        {
            List<Productline> productlines = new List<Productline>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (productLine == null)
                    {
                    return new JsonResult(context.Productlines.ToList()); // get all productlines
                    }
                    else
                    {
                        List<Productline> productline = new List<Productline>(context.Productlines.Where(p => p.ProductLine1 == productLine));
                        return new JsonResult(productline); // get one productline
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Productline productline) // insert new productline
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Productlines.Add(productline);
                    context.SaveChanges();
                    return new JsonResult("Termékvonal felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Productline productline) // update productline
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Productlines.Update(productline);
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
        public JsonResult Delete(string productLine) // delete productline
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Productline productline = context.Productlines.Find(productlineCode);
                    Productline productline = new Productline();
                    productline.ProductLine1 = productLine;
                    context.Productlines.Remove(productline);
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
