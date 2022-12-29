using Microsoft.AspNetCore.Mvc;
using Students.Model;
using Students.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _repository.StudentsList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            //return student.StudentsList().Where(x => x.Id == id).FirstOrDefault();
            return _repository.StudentsList().FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public List<Student> Post(Student student)
        {
            _repository.Create(student);
            return _repository.StudentsList();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody] Student student)
        {
            return _repository.Update(id, student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
