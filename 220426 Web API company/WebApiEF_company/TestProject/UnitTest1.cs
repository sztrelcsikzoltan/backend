using System;
using Xunit;
using WebApiEF_company.Models;
using WebApiEF_company.Services;

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
            Coworker results = service.GetCoworkerByEmail("coworker1@company.com");
            Assert.Equal("Coworker 1", results.Name);
            Assert.Equal(4, results.Notebooks.Count);
            Assert.Equal(4, results.Phones.Count);
        }
    }
}
