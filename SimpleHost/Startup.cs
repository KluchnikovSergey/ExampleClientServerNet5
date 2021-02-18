using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStrings = Configuration.GetSection("ConnectionStrings").GetSection("MSSQLSERVER_SimpleDB").Value;

            ////uncomment for use ms sql server
            //services.AddDbContext<DataAccessLayer.Context.StorageDBContext>(options => 
            //        options.UseSqlServer(connectionStrings)
            //               .UseLazyLoadingProxies());

            services.AddDbContext<DataAccessLayer.Context.StorageDBContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "database_name"));

            services.AddTransient<BusinessLogicLayer.Interface.ICategoryService, BusinessLogicLayer.Service.CategoryService>();
            services.AddTransient<BusinessLogicLayer.Interface.IProductService, BusinessLogicLayer.Service.ProductService>();
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleHost", Version = "v1" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Primary Data Filling
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {   
                using (var context = serviceScope.ServiceProvider.GetService<DataAccessLayer.Context.StorageDBContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Categories.Any())
                    {
                        var paper = new DataAccessLayer.Entity.Category() { Name = "Paper" };
                        var a3 = new DataAccessLayer.Entity.Category() { Name = "A3" };
                        var a4 = new DataAccessLayer.Entity.Category() { Name = "A4" };

                        var lomond_a3 = new DataAccessLayer.Entity.Product()
                        {
                            Name = "Lomond - À3",
                            PriceSell = 12.3f,
                            PriceBayConfidiceal = 5.05f
                        };

                        var lomond_a4 = new DataAccessLayer.Entity.Product()
                        {
                            Name = "Lomond - À4",
                            PriceSell = 12.3f,
                            PriceBayConfidiceal = 5.15f
                        };

                        var svetoCopy_a4 = new DataAccessLayer.Entity.Product() 
                        { 
                            Name = "SvetoCopy - À4", 
                            PriceSell = 12.3f,
                            PriceBayConfidiceal = 2.97f
                        };

                        var svetoCopy_a3 = new DataAccessLayer.Entity.Product() 
                        { 
                            Name = "SvetoCopy - À3", 
                            PriceSell = 11.52f, 
                            PriceBayConfidiceal = 2.62f
                        };

                        a3.Products.Add(svetoCopy_a3);
                        a3.Products.Add(lomond_a3);

                        a4.Products.Add(svetoCopy_a4);
                        a4.Products.Add(lomond_a4);

                        paper.Categories.Add(a3);
                        paper.Categories.Add(a4);

                        
                        context.Categories.Add(paper);

                        context.SaveChanges();
                    }
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleHost v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
