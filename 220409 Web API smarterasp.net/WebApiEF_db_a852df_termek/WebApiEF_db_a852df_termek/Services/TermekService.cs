using System.Collections.Generic;
using System.Linq;
using WebApiEF_db_a852df_termek.Models;

namespace WebApiEF_db_a852df_termek.Services
{
    public class TermekService
    {
        private readonly db_a852df_termekContext context;
        public TermekService(db_a852df_termekContext context)
        {
            this.context = context;
        }

        public IEnumerable<Termekek> GetTermekek()
        {
            return context.Termekeks;
        }

        public Termekek GetTermekById(int id)
        {
            return context.Termekeks.Where(t => t.Id == id).FirstOrDefault();
        }

       public string AddTermek(Termekek termek)
        {
            context.Termekeks.Add(termek);
            context.SaveChanges();
            return ($"{termek.Nev} hozzáadva.");
        }

        public string UpdateTermek(Termekek termek)
        {
            context.Termekeks.Update(termek);
            context.SaveChanges();
            return ($"{termek.Nev} frissítve.");
        }

        public string DeleteTermek(int id)
        {
            Termekek termek = context.Termekeks.Where(t => t.Id == id).First();
            if (termek == null) {
                return $"{termek.Nev} törlése nem sikerült";
            }
            else
            {
                context.Termekeks.Remove(termek);
                context.SaveChanges();
                return $"{termek.Nev} törölve";
            }

        }

    }
}
