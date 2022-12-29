using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Students.Model
{
    public class Student
    {
        public Student() { }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Telephone { get; set; }
        public string? RA { get; set; }
    }
}
