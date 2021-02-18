using AutoMapper;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTest.BussinesLogic
{
    public class CategoryService
    {
        private IServiceProvider _services;

        [OneTimeSetUp]
        public void OneSetUp()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<SimpleHost.Startup>()
                .Build();

            _services = SimpleHost.Program.CreateHostBuilder(new string[] { }).Build().Services;
        }

        [Test]
        public async Task Test_GetCategories()
        {
            var categoryService = _services.GetRequiredService<BusinessLogicLayer.Interface.ICategoryService>();

            var data = await categoryService.GetCategories();

            Assert.IsNotNull(data != null);

            if(data.Length > 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Catogories not found");
            }
        }
    }
}