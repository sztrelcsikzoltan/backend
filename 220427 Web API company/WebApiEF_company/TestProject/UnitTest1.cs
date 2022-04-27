using System;
using Xunit;
using WebApiEF_company.Models;
using WebApiEF_company.Services;
using System.Linq;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly companyContext context;
        private readonly CoworkerService service;
        public UnitTest1()
        {
            this.context = new companyContext();
            this.service = new CoworkerService(context);
        }

        [Fact]
        public void Test_GetCoworkerNumber()
        {
            Assert.Equal(6, service.GetCoworkerNumber());
        }

        [Fact]
        public void Test_GetCoworkerByEmail()
        {
            Coworker actual = service.GetCoworkerByEmail("coworker1@company.com");
            Assert.Equal("Coworker 1", actual.Name);
            Assert.Equal(4, actual.Notebooks.Count);
            // Assert.Equal(4, actual.Phones.Count);
        }

        [Fact]
        public void Test_BrandSamsungExits()
        {
            Coworker actual = service.GetCoworkerByEmail("coworker1@company.com");
            Phone phone = actual.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault();
            string brand = actual.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault().Brand;
            Assert.NotNull(actual.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault());
            Assert.NotNull(phone);
            Assert.NotNull(brand);

            Assert.True(actual.Phones.Count >= 3);
        }

        [Fact]
        public void Test_AddPone()
        {
            Phone phone = new Phone
            {
                Brand = "Test1",
                Type = "test1"
            };

            // PHone törlése, ha létezik
            Phone phone0 = context.Phones.Where(p => p.Brand == "Test1").FirstOrDefault();
            if (phone0 != null)
            {
                service.DeletePhone(phone0.Id);
            }

            service.AddPhone(phone, 1); // külön megadott coworkerId a JsonIgnore miatt
            bool phoneExists = context.Phones.Any(p => p.Brand == "Test1");

            Assert.True(phoneExists);
        }
        
        [Fact]
        public void Test_UpdatePhone()
        {
            Phone phone = new Phone
            {
                Id = 3,
                Brand = "Huwaei",
                Type = "type1"
            };
            service.UpdatePhone(phone, 1); // külön megadott coworkerId a JsonIgnore miatt
            bool phoneExists = context.Phones.Any((p) => p.Type == "type1" && p.CoworkerId == 1);

            Assert.True(phoneExists);
        }

        [Fact]
        public void Test_PhoneTransfer()
        {
            int phoneId = 9;
            int newCoworkerId = 1;
            service.PhoneTransfer(phoneId, newCoworkerId);

            bool phoneExists = context.Phones.Any(p => p.Id == phoneId && p.CoworkerId == newCoworkerId);
            Assert.True(phoneExists);
        }
        
    }
}
