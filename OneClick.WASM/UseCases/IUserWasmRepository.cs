using OneClick.Domain.Domain.Customers;

namespace OneClick.WASM.UseCases
{
    public interface IUserWasmRepository
    {
        Task<List<Customer>> Get();
    }
}
