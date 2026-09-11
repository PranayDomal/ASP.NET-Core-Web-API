using Image_Upload.Data;
using Image_Upload.DTO;
using Image_Upload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Image_Upload.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CustomerRepository(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customer
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customer
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> AddCustomer(CustomerDTO custDto)
        {
            string? fileName = null;

            if (custDto.Image != null)
            {
                fileName = await SaveImage(custDto.Image);
            }

            var customer = new Customer
            {
                Id = custDto.Id,
                Name = custDto.Name,
                Email = custDto.Email,
                Mobile = custDto.Mobile,
                Image = fileName
            };

            _context.Customer.Add(customer);

            await _context.SaveChangesAsync();

            return customer;
        }


        public async Task<Customer?> UpdateCustomer(CustomerDTO custDto)
        {
            var customer = await _context.Customer
                .FirstOrDefaultAsync(c => c.Id == custDto.Id);

            if (customer == null)
            {
                return null;
            }

            customer.Name = custDto.Name;
            customer.Email = custDto.Email;
            customer.Mobile = custDto.Mobile;


            if (custDto.Image != null)
            {
                DeleteImage(customer.Image);

                var newFileName = await SaveImage(custDto.Image);

                customer.Image = newFileName;
            }

            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customer
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return false;
            }

            DeleteImage(customer.Image);

            _context.Customer.Remove(customer);

            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            var uploadFolder = Path.Combine(
                _env.WebRootPath,
                "api",
                "Uploads"
            );

            Directory.CreateDirectory(uploadFolder);

            var filePath = Path.Combine(
                uploadFolder,
                fileName
            );

            using var stream = new FileStream(
                filePath,
                FileMode.Create
            );

            await image.CopyToAsync(stream);

            return fileName;
        }

        private void DeleteImage(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            var filePath = Path.Combine(
                _env.WebRootPath,
                "api",
                "Uploads",
                fileName
            );

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
