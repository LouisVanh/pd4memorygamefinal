using Microsoft.AspNetCore.Mvc;
using ImagesWebService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ImagesWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaySessionNameController : ControllerBase // DONE, VERY HAPPY :D
    {
        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (MemoryGameContext ctx = new MemoryGameContext())
            {
                var sessionName = ctx.PlaySessionNames.FirstOrDefault(s => s.Id == id);
                if (sessionName == null)
                {
                    return NotFound();
                }
                return Ok(sessionName);
            }
        }

        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpGet]
        public IActionResult GetAll()
        {
            using (MemoryGameContext ctx = new MemoryGameContext())
            {
                var sessionNames = ctx.PlaySessionNames.ToList();
                return Ok(sessionNames);
            }
        }

        [EnableCors("PolicyAll")]
        [HttpPost]
        public IActionResult Create([FromBody] PlaySessionNames sessionName)
        {
            if (sessionName == null)
            {
                return BadRequest("Session name object is null.");
            }

            using (var ctx = new MemoryGameContext())
            {
                // If ID is specified, check if it already exists
                if (sessionName.Id != 0)
                {
                    if (ctx.PlaySessionNames.Any(p => p.Id == sessionName.Id))
                    {
                        return Conflict($"A play session with ID {sessionName.Id} already exists.");
                    }
                }

                // Add the entity
                ctx.PlaySessionNames.Add(sessionName);
                ctx.SaveChanges();

                // Return 201 Created status with the created entity
                return CreatedAtAction(nameof(Get), new { id = sessionName.Id }, sessionName);
            }
        }


        // UPDATE (PUT) -) change existing data
        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PlaySessionNames updatedSessionName)
        {
            if (updatedSessionName == null || updatedSessionName.Id != id)
            {
                return BadRequest();
            }

            using (MemoryGameContext ctx = new MemoryGameContext())
            {
                var sessionName = ctx.PlaySessionNames.Find(id);
                if (sessionName == null)
                {
                    return NotFound();
                }

                sessionName.Name1 = updatedSessionName.Name1;
                sessionName.Name2 = updatedSessionName.Name2;
                ctx.SaveChanges();
                return NoContent();
            }
        }

        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (MemoryGameContext ctx = new MemoryGameContext())
            {
                var sessionName = ctx.PlaySessionNames.Find(id);
                if (sessionName == null)
                {
                    return NotFound();
                }

                ctx.PlaySessionNames.Remove(sessionName);
                ctx.SaveChanges();
                return NoContent();
            }
        }
        // DELETE ALL
        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            using (MemoryGameContext ctx = new MemoryGameContext())
            {
                var sessionNames = ctx.PlaySessionNames.ToList();
                ctx.PlaySessionNames.RemoveRange(sessionNames);
                ctx.SaveChanges();

                // Reset the identity seed
                ctx.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('PlaySessionNames', RESEED, 0)");

                return NoContent();
            }
        }

    }
}
