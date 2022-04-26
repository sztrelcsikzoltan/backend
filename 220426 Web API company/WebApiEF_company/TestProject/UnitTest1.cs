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
            Assert.Equal(4, actual.Phones.Count);
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

            Assert.True(actual.Phones.Count  >=3 );
        }
    }
}
