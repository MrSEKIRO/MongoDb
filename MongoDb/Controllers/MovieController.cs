using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDb.DatabaseContext.MongoDbContext;
using MongoDb.Models;

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
        // GET: api/<MovieController>
        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            return await _mongoDbContext.Movies
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        // GET api/<MovieController>/Guid
        [HttpGet("{id}")]
        public async Task<Movie> Get(Guid id)
        {
            return await _mongoDbContext.Movies
                                        .AsNoTracking()
                                        .FirstAsync(x => x.Id == id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Movie movie)
        {
            _mongoDbContext.Movies.Add(movie);
            await _mongoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT api/<MovieController>/Guid
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Movie movie)
        {
            var entity = await _mongoDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            entity.Name = movie.Name;
            entity.PublishDate = movie.PublishDate;
            _mongoDbContext.Movies.Update(entity);
            await _mongoDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<MovieController>/Guid
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var movie = await _mongoDbContext.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();

            _mongoDbContext.Movies.Remove(movie);
            var success = await _mongoDbContext.SaveChangesAsync();
            return Ok(success);
        }

    }
}
