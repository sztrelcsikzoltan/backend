using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MVC
{
    public class Program
    {
        // ez a lista tárolja a bejelentkezett felhasználókat
        public static List<Data.LoggedUsers> loggedUsers = new List<Data.LoggedUsers>();
        
        public static int Check(string uid)
        {
            int jog = -1; // nincs ilyen user bejelentkezve
            int i = 0;
            while (jog == -1 && i <loggedUsers.Count)
            {
                if (loggedUsers[i].Uid == uid)
                {
                    jog = loggedUsers[i].user.Jog;
                }
                i++;
            }
            return jog;
        }

        public static void Remove(string uid)
        {
            int i = 0;
            bool removed = false;
            while (i < loggedUsers.Count && removed == false)
            {
                if (loggedUsers[i].Uid == uid)
                {
                    removed = true;
                    loggedUsers.RemoveAt(i);
                    Console.WriteLine(i);
                }
                i++;
            }

        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
