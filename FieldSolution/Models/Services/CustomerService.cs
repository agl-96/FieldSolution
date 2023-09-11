using FieldSolution.Models.Contract;
using Newtonsoft.Json;

namespace FieldSolution.Models.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
           _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); ;

        }
        public async Task<List<Customer>> Get()
        {
            var response = await _httpClient.GetAsync("https://getinvoices.azurewebsites.net/api/customers");
            List<Customer> result = new List<Customer>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Customer>>(content);
                result = result.OrderBy(x=>x.Id).ToList();
            }
            return result;

        }
        public async Task<bool> Create(Customer customer)
        {
            try
            {
                string jsonCustomer = JsonConvert.SerializeObject(customer);

                var content = new StringContent(jsonCustomer, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("https://getinvoices.azurewebsites.net/api/Customer", content);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Customer created successfully
                }
                else
                {
                    return false; // Customer creation failed
                }
            }
            catch (Exception ex)
            {
                return false; // Customer creation failed
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://getinvoices.azurewebsites.net/api/Customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var customerJson = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                    return customer;
                }
                else
                {
                    // Handle the error, log, or return null if needed
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the request
                // Log the exception or rethrow it as needed
                return null;
            }
        }

        public async Task<bool> Edit(int id, Customer customer)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"https://getinvoices.azurewebsites.net/api/Customer/{id}",customer);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle the error, log, or return null if needed
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"https://getinvoices.azurewebsites.net/api/Customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle the error, log, or return null if needed
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
