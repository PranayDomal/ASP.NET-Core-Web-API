using Image_Upload.DTO;
using Image_Upload.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Image_Upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer =
                await _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(
            [FromForm] CustomerDTO custDto)
        {
            var customer =
                await _customerRepository.AddCustomer(custDto);

            return Ok(customer);
        }


        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(
            [FromForm] CustomerDTO custDto)
        {
            var customer =
                await _customerRepository.UpdateCustomer(custDto);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result =
                await _customerRepository.DeleteCustomer(id);

            if (!result)
            {
                return NotFound("Customer not found");
            }

            return Ok("Customer deleted successfully");
        }
    }
}
