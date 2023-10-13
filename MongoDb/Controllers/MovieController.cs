using Microsoft.AspNetCore.Mvc;
using MongoDb.DatabaseContext.MongoDbContext;
using MongoDb.Models;
using MongoDb.Services;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MongoDbContext _mongoDbContext;

        public MovieController(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return _mongoDbContext.Movies.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie?> Get(Guid id)
        {
            return _mongoDbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            _mongoDbContext.Movies.Add(movie);
            _mongoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Movie movie)
        {
            var entity = _mongoDbContext.Movies.FirstOrDefault(x => x.Id == id);
            entity.Name = movie.Name;
            entity.PublishDate = movie.PublishDate;
            _mongoDbContext.Movies.Update(entity);
            _mongoDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var movie = _mongoDbContext.Movies.Where(x => x.Id == id).FirstOrDefault();

            _mongoDbContext.Movies.Remove(movie);
            _mongoDbContext.SaveChanges();
            return Ok();
        }

    }
}
