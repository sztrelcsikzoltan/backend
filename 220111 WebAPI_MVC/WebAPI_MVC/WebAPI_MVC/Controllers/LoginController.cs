using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_MVC.Data;

namespace WebAPI_MVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]
        public string Post(string bNev, string jelszo)
        {
            List<User> users = new List<User>();
            using (var context = new MyDbContext())
            {
                try
                {
                    List<Data.User> user = new List<User>(context.Users.Where(u => u.BNev == bNev && u.Jelszo == jelszo));
                    if (user.Count > 0)
                    {

                        if (user[0].Aktiv == 1) // ha aktív, akkor bejelentkezhet
                        {
                        string guid = Guid.NewGuid().ToString();
                        Data.LoggedUsers loggedUser = new Data.LoggedUsers();
                        // loggedUsers.user.BNev = bNev;
                        // loggedUsers.user.Jelszo = jelszo;
                        loggedUser.user = user[0];
                        loggedUser.Uid = guid;
                        lock(Program.loggedUsers)
                         {
                            Program.loggedUsers.Add(loggedUser);
                         }

                        Console.WriteLine(guid);
                        return guid;
                            // return "Sikeres bejelentkezés.";
                        }
                        else // ha nem aktív, akkor figyelmeztetjük
                        {
                            return "Felfüggesztett felhasználó!";
                        }


                    }
                    else
                    {
                        return "Hibás bejelentkezési adatok!";
                    }
                }
                catch (Exception e)
                {

                    if (e.Message.Substring(0, 8) == "An error")
                    {
                        return "Hiba történt!";
                    }
                    else if (e.Message.Substring(0, 12) == "An exception")
                    {
                        return "Hiba az adatbázishoz történő csatlakozáskor!";
                    }
                    else
                    {
                        string error = e.Message.ToString();
                        Console.WriteLine(error);
                        if (e.Message.ToString().Contains("actually affected 0 row(s)"))
                        {
                            return $"Nincs ilyen felhasználó az adatbázisban!";
                        }
                    }
                }



                /*
                try
                {
                    if (bNev != "" && jelszo !="") // ha nincs megadva id
                    {
                        // adatbázisból összes User adat lekérése
                        User user = (User)context.Users.ToList().Where( u => u.BNev == bNev);
                        Console.WriteLine($"user adatok: {user}  {user.BNev}  {user.Jelszo}");

                        if (user == null)
                        {
                            return "Nincs ilyen felhasználó!";
                        }


                        
                        // szűréssel
                        // List<Data.User> user = new List<User>(context.Users.Where(u => u.BNev == bNev));
                        // int statusCode = this.HttpContext.Response.StatusCode;  // statusCode lekérdezése
                        // return user.ToString();

                        
                    }
                    else
                    {
                        return "Meg kell adni a felhasználónevet és jelszót!";
                    }

                }
                catch (Exception e)
                {

                    if (e.Message.Substring(0, 8) == "An error")
                    {
                        return "Hiba történt!";
                    }
                    else if (e.Message.Substring(0, 12) == "An exception")
                    {
                        return "Hiba az adatbázishoz történő csatlakozáskor!";
                    }
                    else
                    {
                        string error = e.Message.ToString();
                        Console.WriteLine(error);
                        if (e.Message.ToString().Contains("actually affected 0 row(s)"))
                        {
                            return $"Nincs ilyen felhasználó az adatbázisban!";
                        }
                    }
                }
                */

            }


            return "";
        }
        
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
