using Aplikacja_dla_GIT.Models;

namespace Aplikacja_dla_GIT.Services
{
    public class StudentService : IStudentService
    {
        public Student CreateStudent(string name, string surname)
        {
            var student = new Student();
            student.Name = name;
            student.Surname = surname;

            return student;
        }
        public void AddGrades(Student student, string grades)
        {
            switch (grades)
            {
                case "1":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "2":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "+2":
                    {
                        var grade1 = 2.5;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "-2":
                    {
                        var grade1 = 1.75;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "3":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "+3":
                    {
                        var grade1 = 3.5;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "-3":
                    {
                        var grade1 = 2.75;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "4":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "+4":
                    {
                        var grade1 = 4.5;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "-4":
                    {
                        var grade1 = 3.75;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "5":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "+5":
                    {
                        var grade1 = 5.5;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "-5":
                    {
                        var grade1 = 4.75;
                        student.Grades.Add(grade1);
                        break;
                    }
                case "6":
                    {
                        var grade1 = double.Parse(grades);
                        student.Grades.Add(grade1);
                        break;
                    }
                case "q":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Nieprawidłowa wartość");
                        break;
                    }
            }
        }
        public bool ValidateStudent(List<Student> students, string name, string surname)
        {
            bool studentValidate = true;
            if (students.Count > 0)
            {
                foreach (var item in students)
                {
                    if (item.Name == name && item.Surname == surname)
                    {
                        Console.WriteLine("Taki student juz istnieje!, wcisnij dowolny przycisk i sprobuj ponownie. ");
                        Console.ReadKey();

                        studentValidate = false;
                    }
                }
            }
            return studentValidate;
        }
        public StatisticSerice ShowStatistic(Student student)
        {
            var result = new StatisticSerice();
            result.HighestGrade = 0;
            result.LowestGrade = student.Grades[0];
            result.AverageGrade = 0;
            Console.WriteLine("Oceny: ");
            foreach (var item in student.Grades)
            {
                Console.WriteLine(item);
                result.AverageGrade += item;
                if (item > result.HighestGrade)
                {
                    result.HighestGrade = item;
                }
                if (item < result.LowestGrade)
                {
                    result.LowestGrade = item;
                }
            }
            result.AverageGrade= result.AverageGrade/ student.Grades.Count();
            Console.WriteLine($"Najwyzsza ocena to {result.HighestGrade}");
            Console.WriteLine($"Najnizsz ocena to {result.LowestGrade}");
            Console.WriteLine($"Srednia ocen to {result.AverageGrade}");
            if (result.AverageGrade < 3)
            {
                if (Average3Message != null)
                {
                    Average3Message(this, new EventArgs());
                }
            }
            return result;
        }  
        public delegate void WriteMessageDelegate(object sender, EventArgs args);
        public event WriteMessageDelegate Average3Message;
        public void AverageUnder3(object sednder, EventArgs args)
        {
            Console.WriteLine("O nie! średnia wynosi mniej niż 3.0, powinniśmy poinformować o tym fakcie rodzicow");
        }
    }
}
