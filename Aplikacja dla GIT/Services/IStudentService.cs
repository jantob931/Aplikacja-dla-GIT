using Aplikacja_dla_GIT.Models;

namespace Aplikacja_dla_GIT.Services
{
    public interface IStudentService
    {
        void AddGrades(Student student, string grades);
        StatisticBase ShowStatistic();
    }
}