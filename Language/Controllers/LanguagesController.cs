using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Language_Web_API.Data;
using Language_Web_API.Models;

namespace Language_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LanguagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLanguages()
        {
            return Ok(_context.Language.ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult GetLanguageById(int Id)
        {
            return Ok(_context.Language.Find(Id));
        }

        [HttpPut]
        public IActionResult UpdateLanguage(Language language)
        {
            _context.Language.Update(language);
            _context.SaveChanges();
            return Ok("Data Updated Successfully!");
        }

        [HttpPost]
        public IActionResult AddLanguage(Language language)
        {
            _context.Language.Add(language);
            _context.SaveChanges();
            return Ok("Data Added Successfully!");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteLanguageById(int Id)
        {
            var language = _context.Language.Find(Id);
            _context.Language.Remove(language);
            _context.SaveChanges();
            return Ok("Data Deleted Successfully!");
        }
    }
}
