using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsClient.Clients
{
    public class ClientIProduct : IProductService
    {
        private static ClientIProduct instance;
        private readonly string _host;

        public static ClientIProduct Instance
        {
            get
            {
                if (instance == null)
                {
                    var configurationBulder = new ConfigurationBuilder();

                    configurationBulder.SetBasePath(System.IO.Directory.GetCurrentDirectory());
                    configurationBulder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
                    var config = configurationBulder.Build();

                    string connectionStrings = config.GetSection("AddressServerStrings").GetSection("AppServer").Value;

                    instance = new ClientIProduct(connectionStrings);
                }

                return instance;
            }
        }

        private ClientIProduct(string host)
        {
            _host = host;
        }

        public async Task<ProductDto> GetProduct(Guid idProduct)
        {
            Uri uri = new Uri(_host + $"/Product/GetProduct/{idProduct}");

            Task<HttpResponseMessage> result = new HttpClient().GetAsync(uri);
            HttpResponseMessage response = await result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                return product;
            }
            else
            {
                throw new Exception($"Query Result GetProduct: {response.StatusCode}");
            }
        }

        public async Task<ProductDto[]> GetProducts(Guid idCategory)
        {
            Uri uri = new Uri($"{_host}/Product/GetProducts/{idCategory}");

            Task<HttpResponseMessage> result = new HttpClient().GetAsync(uri);
            HttpResponseMessage response = await result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ProductDto[] products = JsonConvert.DeserializeObject<ProductDto[]>(await response.Content.ReadAsStringAsync());
                return products;
            }
            else
            {
                throw new Exception($"Query Result GetProducts: {response.StatusCode}");
            }
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            Uri uri = new Uri($"{_host}/Product/Update");

            string newProductSerialize = JsonConvert.SerializeObject(productDto);
            HttpContent content = new StringContent(newProductSerialize, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> result = new HttpClient().PostAsync(uri, content);
            HttpResponseMessage response = await result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                return product;
            }
            else
            {
                throw new Exception($"Query Result UpdateProduct: {response.StatusCode}");
            }
        }
    }
}
