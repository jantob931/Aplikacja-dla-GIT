namespace Aplikacja_dla_GIT.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<double> Grades = new List<double>();
    }
}