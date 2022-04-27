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

        public string AddPhone(Phone phone, int coworkerId)
        {
            bool phoneExists = context.Phones.Any(p => p.Id == phone.Id);
            bool coworkerExists = context.Coworkers.Any(c => c.Id == coworkerId);
            if (phoneExists == false && coworkerExists == true)
            {
                phone.CoworkerId = coworkerId; // itt külön kell megadni, mert a JsonIgnore miatt nem jelenik meg a Phone-ban mezőként!
                context.Phones.Add(phone);
                context.SaveChanges();
                return $"Phone of brand {phone.Brand} was added to coworker {phone.CoworkerId}. ";
            }
            else
            {
                return "Phone could not be added!";
            }

        }

        public string UpdatePhone(Phone phone, int coworkerId)
        {
            bool phoneExists = context.Phones.Any(p => p.Id == phone.Id);
            bool coworkerExits = context.Coworkers.Any(c => c.Id == coworkerId);
            if (phoneExists && coworkerExits)
            {
                phone.CoworkerId = coworkerId;
                context.Update(phone);
                context.SaveChanges();
                return $"Phone with id {phone.Id} was updated.";
            }
            {
                return "Phone could not be updated!";
            }

        }

        public string DeletePhone(int id)
        {
            Phone phone = context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                context.Phones.Remove(phone);
                context.SaveChanges();
                return $"Phone with id {id} was deleted.";
            }
            else
            {
                return $"Phone with id {id} does not exist!";
            }
        }

        public string PhoneTransfer(int phoneId, int newCoworkerId)
        {
            Phone phone = context.Phones.Find(phoneId);
            bool newCoworkerExists = context.Coworkers.Any(c => c.Id == newCoworkerId);
            
            if (phone != null && newCoworkerExists)
            {
                phone.CoworkerId = newCoworkerId;
                // context.Update(phone);
                context.SaveChanges();
                return $"Phone was transferred to coworker with id {newCoworkerId}";
            }
            else
            {
                return "Phone could not be transferred!";
            }

        }

    }
}
