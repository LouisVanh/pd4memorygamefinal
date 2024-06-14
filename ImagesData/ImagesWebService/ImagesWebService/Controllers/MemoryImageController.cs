using Microsoft.AspNetCore.Mvc;
using ImagesWebService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ImagesWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemoryImageController : ControllerBase
    {
        [EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            MemoryGameContext ctx = new MemoryGameContext();
            Image img = ctx.Images.Where(i => i.Id == id).First();
            Response.ContentType = "image/png";
            byte[] data = img.Image1;
            return File(data, "image/png");
            //DEBUG IN CASE IT DOES NOT WORK, CHECK IF IT SHOWS THIS RESPONSE IN SWAGGER
            //string test = "TEST";
            //return Content(test);
        }

        //[EnableCors("PolicyAll")] // allows any webservice to access this
        [HttpGet]
        public DbSet<Image> Get()
        {
            MemoryGameContext ctx = new MemoryGameContext();
            return ctx.Images;
        }


    }
}