using Country_webapi.Data;
using Country_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;

namespace Country_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.Country.ToList());
        }

        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();
            return Ok("Data Added Successfully!");
        }

        [HttpGet("{Id}")]
        public IActionResult GetCountryById(int Id)
        {
            return Ok(_context.Country.Find(Id));
        }

        [HttpPut]
        public IActionResult UpdateCountry(Country country)
        {
            _context.Country.Update(country);
            _context.SaveChanges();
            return Ok("Data Updated Successfully!");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCountry(int Id)
        {
            var country = _context.Country.Find(Id);
            _context.Country.Remove(country);
            _context.SaveChanges();
            return Ok("Data Deleted Successfully!");
        }
    }
}
