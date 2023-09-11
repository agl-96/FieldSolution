namespace FieldSolution.Models.Contract
{
    public interface ICustomerService
    {
        public  Task<List<Customer>> Get();
        public Task<bool> Create(Customer customer);
        public Task<Customer> GetCustomerById(int id);
        public Task<bool> Edit(int id,Customer customer);
        public Task<bool> Delete(int id);
    }
}
