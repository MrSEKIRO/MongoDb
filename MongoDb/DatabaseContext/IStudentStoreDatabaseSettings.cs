﻿namespace MongoDb.DatabaseContext;

public interface IStudentStoreDatabaseSettings
{
	string StudentCoursesCollectionName { get; set; }
	string ConnectionString { get; set; }
	string DatabaseName { get; set; }
}
