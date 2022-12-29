using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Students.Model
{
    public class Student
    {
        public Student(){}

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public Student(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Telephone { get; set; }
        public string? RA { get; set; }

        public List<Student> StudentsList()
        {
            #region
            //Student student1 = new Student()
            //{
            //    Id = 1,
            //    Name = "Fausto",
            //    LastName = "Vera",
            //    Telephone = "11-997737770",
            //    RA = "0001-22",
            //};

            //Student student2 = new Student()
            //{
            //    Id = 2,
            //    Name = "Roger",
            //    LastName = "Guedes",
            //    Telephone = "11-997737770",
            //    RA = "0002-22",
            //};

            //List<Student> studentsList = new List<Student>();

            //studentsList.Add(student1);
            //studentsList.Add(student2);
            //return studentsList;
            #endregion

            // application's base path
            var contentRootPath = _env.ContentRootPath;

            // application's publishing path
            var  webRootPath = _env.WebRootPath;

            var docPath = Path.Combine(_env.ContentRootPath, @"App_Data\Base.json");

            var json = File.ReadAllText(docPath);
            
            var listStudents = JsonConvert.DeserializeObject<List<Student>>(json);

            return listStudents;
        }
    }
}
