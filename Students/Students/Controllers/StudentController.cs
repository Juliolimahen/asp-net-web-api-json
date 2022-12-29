using Microsoft.AspNetCore.Mvc;
using Students.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public StudentController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            Student student = new Student(_env);
            return student.StudentsList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student student = new Student(_env);

            //return student.StudentsList().Where(x => x.Id == id).FirstOrDefault();

            return student.StudentsList().FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public List<Student> Post(Student student)
        {
            List<Student> students = new List<Student>();

            students.Add(student);

            return students;
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
