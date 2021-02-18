using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsClient.Clients
{
    public class ClientICategory : ICategoryService
    {
        private static ClientICategory instance;
        private readonly string _host;

        public static ClientICategory Instance
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

                    instance = new ClientICategory(connectionStrings);
                }

                return instance;
            }
        }

        private ClientICategory(string host)
        {
            _host = host;
        }

        public async Task<CategoryDto[]> GetCategories()
        {
            Uri uri = new Uri(_host + "/Category/GetContainersTree");

            Task<HttpResponseMessage> result = new HttpClient().GetAsync(uri);
            HttpResponseMessage response = await result;
            var message = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CategoryDto[] categoryDto = JsonConvert.DeserializeObject<CategoryDto[]>(response.Content.ReadAsStringAsync().Result);
                return categoryDto;
            }
            else
            {
                throw new Exception($"Query Result GetContainersTree: {response.StatusCode}");
            }
        }
    }
}
