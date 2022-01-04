using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MVC.Data
{
    public class User : Record
    {
        public string BNev { get; set; }
        public string Jelszo { get; set; }
        public string FNev { get; set; }
        public int Jog { get; set; }
        public int Aktiv { get; set; }

        public User() : base()
        {

        }

        public User(int id, string bNev, string jelszo, string fNev, int jog, int aktiv):base(id)
        {
            this.Id = id;
            this.BNev = bNev;
            this.Jelszo = jelszo;
            this.FNev = fNev;
            this.Jog = jog;
            this.Aktiv = aktiv;
        }
    }
}
