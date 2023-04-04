using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server
{
    internal class Database
    {
        public static async Task DatabaseAsync()
        {
            var connectionString = "mongodb://localhost:27017";             // The database location that we will connect to.
            var client = new MongoClient(connectionString);                 // Create the connection to the database.
            var db = client.GetDatabase("school");                          // Grab a database from MongoDB. (Will also create if it doesn't exist.)

            // Used when not using a class for entry.
            //var collection = db.GetCollection<BsonDocument>("students");    // Grab a document from that database. (Will also create if it doesn't exist.)

            // Create our document entry.
            /*
            var document = new BsonDocument
            {
                { "firstname", BsonValue.Create("Peter") },
                { "lastname", new BsonString("Mbanugo") },
                { "subjects", new BsonArray(new[] {"English", "Mathematics", "Physics" }) },
                { "class", "JSS 3" },
                { "age", 45 }
            };
            await collection.InsertOneAsync(document);                      // Insert our document entry into the database.
            */

            // Create multiple document entries.
            /*
            var newStudents = CreateNewStudents();
            await collection.InsertManyAsync(newStudents);
            */

            // Create multuple document entries using a class.
            var collection = db.GetCollection<Student>("students");
            var newStudents = CreateNewStudents();
            await collection.InsertManyAsync(newStudents);
        }

        // Create multiple document entries.
        /* private static IEnumerable<BsonDocument> CreateNewStudents()
        {
            // First Entry
            var student1 = new BsonDocument
            {
                {"firstname", "Ugo"},
                {"lastname", "Damian"},
                {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Biology"}},
                {"class", "JSS 3"},
                {"age", 23}
            };

            // Second Entry
            var student2 = new BsonDocument
            {
              {"firstname", "Julie"},
              {"lastname", "Lerman"},
              {"subjects", new BsonArray {"English", "Mathematics", "Spanish"}},
              {"class", "JSS 3"},
              {"age", 23}
            };

            // Third Entry
            var student3 = new BsonDocument
            {
                {"firstname", "Julie"},
                {"lastname", "Lerman"},
                {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Chemistry"}},
                {"class", "JSS 1"},
                {"age", 25}
            };

            // Our list of document entries then add the entries to it.
            var newStudents = new List<BsonDocument>();
            newStudents.Add(student1);
            newStudents.Add(student2);
            newStudents.Add(student3);

            // Return our document list.
            return newStudents;
        } */

        // Create multiple document entries using a class.
        private static IEnumerable<Student> CreateNewStudents()
        {
            // First Entry
            var student1 = new Student
            {
                FirstName = "Gregor",
                LastName = "Felix",
                Subjects = new List<string>() { "English", "Mathematics", "Physics", "Biology" },
                Class = "JSS 3",
                Age = 23
            };

            // Second Entry
            var student2 = new Student
            {
                FirstName = "Machiko",
                LastName = "Elkberg",
                Subjects = new List<string> { "English", "Mathematics", "Spanish" },
                Class = "JSS 3",
                Age = 23
            };

            // Third Entry
            var student3 = new Student
            {
                FirstName = "Julie",
                LastName = "Sandal",
                Subjects = new List<string> { "English", "Mathematics", "Physics", "Chemistry" },
                Class = "JSS 1",
                Age = 25
            };

            // Create our list of students.
            var newStudents = new List<Student> { student1, student2, student3 };

            // Return our list of students.
            return newStudents;
        }
    }

    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}