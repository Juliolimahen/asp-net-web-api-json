using Newtonsoft.Json;
using Students.Model;

namespace Students.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository() { }

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public StudentRepository(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }
        public Student Create(Student student)
        {
            var listStudents = this.StudentsList();
            var maxId = listStudents.Max(x => x.Id);
            student.Id = maxId + 1;
            listStudents.Add(student);

            RewriteFile(listStudents);

            return student;
        }

        public bool RewriteFile(List<Student> listStudents)
        {
            // application's base path
            var contentRootPath = _env.ContentRootPath;

            // application's publishing path
            var webRootPath = _env.WebRootPath;

            var docPath = Path.Combine(_env.ContentRootPath, @"App_Data\Base.json");

            var json = JsonConvert.SerializeObject(listStudents, Formatting.Indented);

            File.WriteAllText(docPath, json);

            return true;
        }

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
            var webRootPath = _env.WebRootPath;

            var docPath = Path.Combine(_env.ContentRootPath, @"App_Data\Base.json");

            var json = File.ReadAllText(docPath);

            var listStudents = JsonConvert.DeserializeObject<List<Student>>(json);

            return listStudents;
        }

        public Student Update(int id, Student student)
        {
            var listStudents = this.StudentsList();

            var itemIndex = listStudents.FindIndex(x => x.Id == id);

            if (itemIndex > 0)
            {
                student.Id = id;
                listStudents[itemIndex] = student;
            }
            else
            {
                return null;
            }

            RewriteFile(listStudents);

            return student;
        }

        public bool Delete(int id)
        {
            var listStudents = this.StudentsList();

            var itemIndex = listStudents.FindIndex(x => x.Id == id);

            if (itemIndex >= 0)
            {
                listStudents.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RewriteFile(listStudents);

            return true;
        }
    }
}
