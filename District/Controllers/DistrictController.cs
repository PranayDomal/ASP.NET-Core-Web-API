using District_webapi.Data;
using District_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace District_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DistrictController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDistrict()
        {
            return Ok(_context.District.ToList());
        }

        [HttpPost]
        public IActionResult AddDistrict(District district)
        {
            _context.District.Add(district);
            _context.SaveChanges();
            return Ok("Data Added Successfully!");
        }

        [HttpGet("{Id}")]
        public IActionResult GetDistrictById(int Id)
        {
            return Ok(_context.District.Find(Id));
        }

        [HttpPut]
        public IActionResult UpdateDistrict(District district)
        {
            _context.District.Update(district);
            _context.SaveChanges();
            return Ok("Data Updated Successfully!");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteDistrict(int Id)
        {
            var district = _context.District.Find(Id);
            _context.District.Remove(district);
            _context.SaveChanges();
            return Ok("Data Deleted Successfully!");
        }
    }
}
