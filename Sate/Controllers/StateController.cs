using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sate_webapi.Data;
using Sate_webapi.Models;
using System.Diagnostics.Metrics;

namespace Sate_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StateController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSates()
        {
            return Ok(_context.State.ToList());
        }

        [HttpPost]
        public IActionResult AddState(State state)
        {
            _context.State.Add(state);
            _context.SaveChanges();
            return Ok("Data Added Successfully!");
        }

        [HttpGet("{Id}")]
        public IActionResult GetStateById(int Id)
        {
            return Ok(_context.State.Find(Id));
        }

        [HttpPut]
        public IActionResult UpdateState(State state)
        {
            _context.State.Update(state);
            _context.SaveChanges();
            return Ok("Data Updated Successfully!");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteState(int Id)
        {
            var state = _context.State.Find(Id);
            _context.State.Remove(state);
            _context.SaveChanges();
            return Ok("Data Deleted Successfully!");
        }
    }
}
