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
    public class ProductService
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
        public async Task Test_GetProducts()
        {
            var dbContext = _services.GetRequiredService<DataAccessLayer.Context.StorageDBContext>();
            var productService = _services.GetRequiredService<IProductService>();

            var expectedProduct = await dbContext.Products.FirstOrDefaultAsync();

            Assert.IsNotNull(expectedProduct);
            
            var products = await productService.GetProducts(expectedProduct.ParentCategoryId);

            if (products.Length > 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("No products found in group");
            }            
        }

        [Test]
        public async Task Test_GetProduct()
        {
            var dbContext = _services.GetRequiredService<DataAccessLayer.Context.StorageDBContext>();
            var productService = _services.GetRequiredService<IProductService>();

            var expectedProduct = dbContext.Products.FirstOrDefault();

            Assert.IsNotNull(expectedProduct);
            
            var actualProduct = await productService.GetProduct(expectedProduct.Id);

            Assert.IsNotNull(actualProduct);
            Assert.AreEqual(expectedProduct.Id, actualProduct.Id);            
        }
    }
}