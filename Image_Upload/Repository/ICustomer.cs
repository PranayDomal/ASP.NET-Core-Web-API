using Image_Upload.DTO;
using Image_Upload.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Upload.Repository
{
    public interface ICustomer
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer?> GetCustomerById(int id);

        Task<Customer?> AddCustomer(CustomerDTO custDto);

        Task<Customer?> UpdateCustomer(CustomerDTO custDto);

        Task<bool> DeleteCustomer(int id);
    }
}
