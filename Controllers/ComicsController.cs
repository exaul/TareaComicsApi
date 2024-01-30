using Apicomics.Data;
using Apicomics.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apicomics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public ComicsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<ComicsController>
        [HttpGet]
        public IEnumerable<Comic> Get()
        {
            return dbContext.Comics;
        }

        // GET api/<ComicsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id no debe de ser 0");
            }
            Comic comic = dbContext.Comics.Find(id);
            if (comic == null)
            {
                return NotFound("El comic no existe");
            }
            return Ok(comic);
        }

        // POST api/<ComicsController>
        [HttpPost]
        public IActionResult Post([FromBody] Comic newComic)
        {
            if (newComic == null)
            {
                return BadRequest("Los datos del comic están vacíos");
            }
            if ((string.IsNullOrEmpty(newComic.TiTle)) || string.IsNullOrEmpty(newComic.Language))
            {
                return BadRequest("Los campos son obligatorios");
            }
            dbContext.Comics.Add(newComic);
            dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<ComicsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comic updatedComic)
        {
            if (updatedComic == null)
            {
                return BadRequest("los datos son nulos");
            }

            var existingComic = dbContext.Comics.Find(id);

            if (existingComic == null)
            {
                return BadRequest("Canción NO encontrada");
            }


            existingComic.TiTle = updatedComic.TiTle;
            existingComic.Language = updatedComic.Language;

            dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<ComicsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Comic id)
        {
            var comicToDelete = dbContext.Comics.Find(id);
            if (comicToDelete != null)
            {
                dbContext.Comics.Remove(comicToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
