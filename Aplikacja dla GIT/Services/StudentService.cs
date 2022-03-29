using Aplikacja_dla_GIT.Models;

namespace Aplikacja_dla_GIT.Services
{

    public class StudentService : IStudentService
    {


        private List<double> allArades = new List<double>();


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
                        student.grades.Add(grade1);
                        break;
                    }
                case "2":
                    {
                        var grade1 = double.Parse(grades);
                        allArades.Add(grade1);
                        break;
                    }
                case "+2":
                    {
                        var grade1 = 2.5;
                        allArades.Add(grade1);
                        break;
                    }
                case "-2":
                    {
                        var grade1 = 1.75;
                        allArades.Add(grade1);
                        break;
                    }
                case "3":
                    {
                        var grade1 = double.Parse(grades);
                        allArades.Add(grade1);
                        break;
                    }
                case "+3":
                    {
                        var grade1 = 3.5;
                        allArades.Add(grade1);
                        break;
                    }
                case "-3":
                    {
                        var grade1 = 2.75;
                        allArades.Add(grade1);
                        break;
                    }
                case "4":
                    {
                        var grade1 = double.Parse(grades);
                        allArades.Add(grade1);
                        break;
                    }
                case "+4":
                    {
                        var grade1 = 4.5;
                        allArades.Add(grade1);
                        break;
                    }
                case "-4":
                    {
                        var grade1 = 3.75;
                        allArades.Add(grade1);
                        break;
                    }
                case "5":
                    {
                        var grade1 = double.Parse(grades);
                        allArades.Add(grade1);
                        break;
                    }
                case "+5":
                    {
                        var grade1 = 5.5;
                        allArades.Add(grade1);
                        break;
                    }
                case "-5":
                    {
                        var grade1 = 4.75;
                        allArades.Add(grade1);
                        break;
                    }
                case "6":
                    {
                        var grade1 = double.Parse(grades);
                        allArades.Add(grade1);
                        break;
                    }
                case "q":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid value");
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


        public StatisticSerice ShowStatistic()
        {
            var result = new StatisticSerice();
            result.highest_grade = 0;
            result.lowest_grade = allArades[0];
            result.average_grade = 0;
            foreach (var item in allArades)
            {
                Console.WriteLine(item);
                result.average_grade += item;
                if (item > result.highest_grade)
                    result.highest_grade = item;
                if (item < result.lowest_grade)
                    result.lowest_grade = item;
            }
            Console.WriteLine($"Najwyzsza ocena to {result.highest_grade}");
            Console.WriteLine($"Najnizsz ocena to {result.lowest_grade}");
            Console.WriteLine($"Srednia ocen to {result.average_grade}");

            return result;
        }
    }
}
