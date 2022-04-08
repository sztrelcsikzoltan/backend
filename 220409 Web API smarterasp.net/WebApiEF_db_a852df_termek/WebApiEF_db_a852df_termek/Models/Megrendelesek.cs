using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF_db_a852df_termek.Models
{
    public partial class Megrendelesek
    {
        public int Id { get; set; }
        public int MegrendeloId { get; set; }
        public int TermekId { get; set; }
        public int Db { get; set; }
        public int ArOsszesen { get; set; }

        public virtual Termekek Termek { get; set; }
    }
}
