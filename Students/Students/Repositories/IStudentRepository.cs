using Students.Model;

namespace Students.Repository
{
    public interface IStudentRepository
    {
        List<Student> StudentsList();
        bool RewriteFile(List<Student> listStudents);
        Student Create(Student student);
        Student Update(int id, Student student);
        bool Delete(int id);
    }
}
