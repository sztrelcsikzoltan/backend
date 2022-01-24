using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNetWebAPI_VueJS.Models;
using System.IO;

namespace ASPdotNetWebAPI_VueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AutoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select * from auto";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                try
                {
                    myConnection.Open();
                    using (MySqlCommand myCommand = new MySqlCommand
                        (query, myConnection))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myConnection.Close();

                    }
                }
                catch (Exception e)
                {
                    return new JsonResult(e.Message);
                    /*table.Columns.Add(new DataColumn("Üzenet", typeof(String)));
                    DataRow dr = table.NewRow();
                    dr[0] = e.Message;
                    table.Rows.Add(dr);*/
                }
            }
            
            return new JsonResult(table);
        }

        [HttpPost]

        public JsonResult Post(Auto auto)
        {
            string query = @"insert into auto (szoveg,linkkep,ar) values (@Szoveg,@Linkkep,@Ar)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                try
                {
                    myConnection.Open();
                    using (MySqlCommand myCommand = new MySqlCommand
                        (query, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@Szoveg", auto.Szoveg);
                        myCommand.Parameters.AddWithValue("@Linkkep", auto.Linkkep);
                        myCommand.Parameters.AddWithValue("@Ar", auto.Ar);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    return new JsonResult(e.Message);
                }
            }
            return new JsonResult("Új autó adatainak a felvitele sikeresen megtörtént.");
        }

        [HttpPut]

        public JsonResult Put(Auto auto)
        {
            string query = @"update auto set Szoveg=@Szoveg,Linkkep=@Linkkep,Ar=@Ar where id=@Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                int result = 0;
                try
                {
                    myConnection.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@Id", auto.Id);
                        myCommand.Parameters.AddWithValue("@Szoveg", auto.Szoveg);
                        myCommand.Parameters.AddWithValue("@Linkkep", auto.Linkkep);
                        myCommand.Parameters.AddWithValue("@Ar", auto.Ar);
                        myReader = myCommand.ExecuteReader();
                        result = myReader.RecordsAffected;
                        table.Load(myReader);
                        myReader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        return new JsonResult($"A MySQL kiszolgáló nem áll rendelkezésre.");
                    }
                    else
                    {
                        return new JsonResult($"Hiba történt, amelynek részletei következők:\nRészletek: {ex.Message}");
                    }

                }
                
                if (result > 0)
                {
                    return new JsonResult($"A frissítés sikeresen megtörtént. Frissített sorok száma: {result}");
                }
                else
                {
                    return new JsonResult($"A frissítés nem sikerült! Nincs ilyen azonosítóval rendelkező rekord!");
                }
            }
            // return new JsonResult("Adatok módosítása sikeresen megtörtént.");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query1 = @"delete from auto where Id=@Id";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;

            int result1 = 0;
            string torolt_auto_neve = "";
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT `szoveg` FROM `auto` WHERE `id` = {id}", myConnection);
                    myReader = command.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        myReader.Read();
                        torolt_auto_neve = myReader.GetString(0);
                    }
                    myConnection.Close();

                    myConnection.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query1, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@Id", id);
                        myReader = myCommand.ExecuteReader(); // ez töröl
                        result1 = myReader.RecordsAffected;
                        table.Load(myReader);
                        myReader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        return new JsonResult($"A MySQL kiszolgáló nem áll rendelkezésre.");
                    }
                    else
                    {
                        return new JsonResult($"Hiba történt, amelynek részletei következők:\nRészletek: {ex.Message}");
                    }
                }

            }
            if (result1 > 0)
            {
                return new JsonResult($"A törlés sikeresen megtörtént. Törölt autó neve: {torolt_auto_neve}, törölt sorok száma: {result1}");
            }
            else
            {
                return new JsonResult($"A törlés nem sikerült! Nincs ilyen azonosítóval rendelkező rekord!");
            }

            /*
            string query2 = $@"delete from auto where Id={id}";
            int result2 = 0;
            using (MySqlConnection myConnection = new MySqlConnection(sqlDataSource))
            {
                try
                {
                    myConnection.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query2, myConnection))
                    {
                        // myCommand.Parameters.AddWithValue("@Id", id);
                        // myReader = myCommand.ExecuteReader(); // ez töröl
                        // table.Load(myReader);
                        // myReader.Close();
                        result2 = myCommand.ExecuteNonQuery(); // ez töröl


                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        return new JsonResult($"A MySQL kiszolgáló nem áll rendelkezésre ");
                    }
                    else
                    {
                        return new JsonResult($"Hiba történt, amelynek részletei következők:\nRészletek: {ex.Message}");
                    }
                }
            }
            if (result2 >0 )
            {
                return new JsonResult($"A törlés sikeresen megtörtént. Törölt sorok száma: {result2}");
            }
            else
            {
                return new JsonResult($"A törlés nem sikerült! Nincs ilyen azonosítóval rendelkező rekord!");
            }
            */

        }
        
        // fájl feltöltése
        [Route("ImgUpload")]
        [HttpPost]

        public JsonResult ImgUpload()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var path = _env.ContentRootPath + "/Photos/" + fileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                
                         
                
                
                
                return new JsonResult(fileName + " nevű fotó sikeresen feltöltve.");
            }
            catch (Exception ex)
            {

                return new JsonResult("Fénykép feltöltése sikertelen");
            }
        }


    }
}
