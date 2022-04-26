using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEF_company.Models;

namespace WebApiEF_company.Services
{
    public class CoworkerService
    {
        private readonly companyContext context;
        public CoworkerService(companyContext context)
        {
            this.context = context;
        }

        public Coworker GetCoworkerByEmail(string email)
        {
            return context.Coworkers.Where(c => c.Email == email).Include(c => c.Notebooks).Include(c => c.Phones).FirstOrDefault();
                
        }

        public int GetCoworkerNumber()
        {
            return context.Coworkers.Count();
        }
    }
}
