using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF_db_a852df_termek.Models
{
    public partial class Megrendelok
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Cim { get; set; }
        public string Irsz { get; set; }
        public string Hsz { get; set; }
        public string EmeletAjto { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Megjegyzes { get; set; }
        public int TermekId { get; set; }

        public virtual Termekek Termek { get; set; }
    }
}
