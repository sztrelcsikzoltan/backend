using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF_db_a852df_termek.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Megrendeles = new HashSet<Megrendele>();
            Megrendeloks = new HashSet<Megrendelok>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public string Keplink { get; set; }

        public virtual ICollection<Megrendele> Megrendeles { get; set; }
        public virtual ICollection<Megrendelok> Megrendeloks { get; set; }
    }
}
