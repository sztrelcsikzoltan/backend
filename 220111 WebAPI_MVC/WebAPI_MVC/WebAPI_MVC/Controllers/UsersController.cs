using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAPI_MVC.Data;
using Newtonsoft.Json;

namespace WebAPI_MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        // lista, User típusú objektum visszatérési értékkel
        public IEnumerable<Data.User> Get(string uId, int id)
        {
            List<User> users = new List<User>();
            if (Program.Check(uId) >= 5)
            {

                using (var context = new MyDbContext())
                {
                    try
                    {
                        if (id == 0) // ha nincs megadva id
                        {
                            // adatbázisból összes User adat lekérése, DE csak jogosult felhasználónak


                            return context.Users.ToList();
                        }
                        else
                        {
                            // szűréssel
                            List<Data.User> user = new List<User>(context.Users.Where(u => u.Id == id));
                            int statusCode = this.HttpContext.Response.StatusCode;  // statusCode lekérdezése
                            return user;
                        }


                    }
                    catch
                    {


                    }
                }
            }
            return users;
        }
        
        // User beszúrása
        [HttpPost]
        public string Post(string bNev, string jelszo, string fNev, int jog, int aktiv)
        {
            User user = new User(0, bNev, jelszo, fNev, jog, aktiv);
            using (var context = new MyDbContext())
            {
                try
                {
                    // User felvétele az adatbázisba
                    context.Users.Add(user);
                    context.SaveChanges();

                }
                catch (Exception e)
                {

                    if (e.Message.Substring(0, 8)=="An error")
                    {
                        return JsonConvert.SerializeObject(  "Már van felhasználó ilyen bejelentkezési névvel!");
                    }
                    else
                    {
                        return "Hiba az adatbázishoz történő csatlakozáskor!";
                    }
                }
            }
            return "A felhasználó felvétele sikeresen megtörtént.";
        }

        // User frissítése - Házi feladat
        [HttpPut]
        public string Put(int id, string bNev, string jelszo, string fNev, int jog, int aktiv)
        {
            User user = new User(id, bNev, jelszo, fNev, jog, aktiv);
            using (var context = new MyDbContext())
            {
                try
                {
                    // User felvétele az adatbázisba
                    context.Users.Update(user);
                    context.SaveChanges();

                }
                catch (Exception e)
                {

                    if (e.Message.Substring(0, 8) == "An error")
                    {
                        return JsonConvert.SerializeObject("A felhasználó frissítése nem sikerült!");
                    }
                    else if(e.Message.Substring(0,12) == "An exception")
                    {
                        return JsonConvert.SerializeObject("Hiba az adatbázishoz történő csatlakozáskor!");
                    }
                    else
                    {
                        string error = e.Message.ToString();
                        Console.WriteLine(error);
                        if (e.Message.ToString().Contains("actually affected 0 row(s)"))
                        {
                        return $"Nincs ilyen id-val ({id}) rendelkező felhasználó az adatbázisban!";
                        }
                    }
                }
            }
            return "A felhasználó frissítése sikeresen megtörtént.";
        }

        // User törlése - Házi feladat
        [HttpDelete]

        public string Delete(int id)
        {

            using (var context = new MyDbContext())
            {
                User user = new User();
                user.Id = id;

                try
                {
                    context.Users.Remove(user);
                    context.SaveChanges();

                }
                catch (Exception e)
                {


                    if (e.Message.ToString().Contains("actually affected 0 row(s)"))
                    {
                        return $"Nincs ilyen id-val ({id}) rendelkező felhasználó az adatbázisban! (Delete)";
                    }
                    else if (e.Message.Substring(0, 8) == "An error")
                    {
                        Console.WriteLine(e.Message);
                        return JsonConvert.SerializeObject("A felhasználó törlése nem sikerült!");
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                        return "Hiba az adatbázishoz történő csatlakozáskor!";
                    }
                }
            }
            return "A felhasználó törlése sikeresen megtörtént.";
        }

        public string Delete1(int id)
        {

            using (var context = new MyDbContext())
            {
                try
                {

                    // User törlése az adatbázisból
                    List<Data.User> userDb = new List<User>(context.Users.Where(u => u.Id == id));
                    bool userExists = userDb.Count > 0 ? true : false;
                    if (userExists == false)
                    {
                        return $"A megadott felhasználó (Id={id}) nem létezik! (Delete1)";
                    }
                    context.Users.Remove(userDb[0]);
                    context.SaveChanges();

                }
                catch (Exception e)
                {

                    if (e.Message.Substring(0, 8) == "An error")
                    {
                        Console.WriteLine(e.Message);
                        return JsonConvert.SerializeObject("A felhasználó törlése nem sikerült!");
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                        return "Hiba az adatbázishoz történő csatlakozáskor!";
                    }
                }
            }
            return "A felhasználó törlése sikeresen megtörtént.";
        }

        


        /*
        public IActionResult Index()
        {
            
            
            return View();
        }
        */
    }
}
