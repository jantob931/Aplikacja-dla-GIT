using Aplikacja_dla_GIT.Models;
namespace Aplikacja_dla_GIT.Services
{
    public interface IProgramService
    {
        void AddStudents(Student student, StudentService studentService, List<Student> students);
        void AddGrades(List<Student> students, StudentService studentService);
        void EditName(List<Student> students, StudentService studentService);
        void EditSurname(List<Student> students, StudentService studentService);
        void ShowAllStudents(List<Student> students);
        void ShowStudnetsStatistic(List<Student> students, StudentService studentService);
        void RemoveStudent(List<Student> students);
        void Studnts_menu();
        bool CheckIsNull(List<Student> students);
        bool IsDigiOrEmpty(int licznik, string argument);
        Student FindStudent(List<Student> students);    
    }
}
