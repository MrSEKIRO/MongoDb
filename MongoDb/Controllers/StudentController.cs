using Microsoft.AspNetCore.Mvc;
using MongoDb.Models;
using MongoDb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		// GET: api/<StudentController>
		[HttpGet]
		public ActionResult<List<Student>> Get()
		{
			return _studentService.Get();
		}

		// GET api/<StudentController>/5
		[HttpGet("{id}")]
		public ActionResult<Student> Get(string id)
		{
			return _studentService.GetById(id);
		}

		// POST api/<StudentController>
		[HttpPost]
		public ActionResult Post([FromBody] Student student)
		{
			_studentService.Create(student);

			return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
		}

		// PUT api/<StudentController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Student student)
		{
			_studentService.Update(student);

			return NoContent();
		}

		// DELETE api/<StudentController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(string id)
		{
			_studentService.Remove(id);

			return Ok();
		}
	}
}
