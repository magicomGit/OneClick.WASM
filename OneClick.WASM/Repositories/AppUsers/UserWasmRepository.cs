using OneClick.Domain.Domain.Customers;
using OneClick.WASM.UseCases;
using System.Net.Http.Json;

namespace OneClick.WASM.Repositories.AppUsers
{
    public class UserWasmRepository : IUserWasmRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        public UserWasmRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("Auth");
        }

        public async Task<List<Customer>> Get()
        {
            List<Customer> customers = [];

            try
            {
                customers = await _httpClient.GetFromJsonAsync<List<Customer>>("api/users/get");                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }


            return customers;
        }
    }
}
