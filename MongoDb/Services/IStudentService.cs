using MongoDb.DatabaseContext;
using MongoDb.Models;
using MongoDB.Driver;

namespace MongoDb.Services;

public interface IStudentService
{
	List<Student> Get();
	Student GetById(string id);
	Student Create(Student student);
	void Update(Student student);
	void Remove(string studentId);
}

public class StudentService : IStudentService
{
	private readonly IMongoCollection<Student> _students;

	public StudentService(IStudentStoreDatabaseSettings databaseSettings, IMongoClient mongoClient)
	{
		var context = mongoClient.GetDatabase(databaseSettings.DatabaseName);
		_students = context.GetCollection<Student>(databaseSettings.StudentCoursesCollectionName);
	}
	public Student Create(Student student)
	{
		_students.InsertOne(student);
		return student;
	}

	public List<Student> Get()
	{
		return _students.Find(x => true)
			.ToList();
	}

	public Student GetById(string id)
	{
		return _students.Find(x => x.Id == id)
			.FirstOrDefault();
	}

	public void Remove(string studentId)
	{
		_students.DeleteOne(x => x.Id == studentId);
	}

	public void Update(Student student)
	{
		_students.ReplaceOne(x => x.Id == student.Id, student);
	}
}
