using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNetWebAPI_VueJS.Models
{
    public class Auto
    {
        public int Id { get; set; }

        public string Szoveg { get; set; }

        public string Linkkep { get; set; }

        public int Ar { get; set; }

        public Auto()
        {

        }

        public Auto(int id,string szoveg,string linkkep,int ar)
        {
            this.Id = id;
            this.Szoveg = szoveg;
            this.Linkkep = linkkep;
            this.Ar = ar;
        }
    }
}
