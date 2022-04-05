using Aplikacja_dla_GIT.Models;
using Aplikacja_dla_GIT.Services;

namespace Aplikacja_dla_GIT
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var studentService = new StudentService();
            var programService = new ProgramService();
            Student student = new Student();
            studentService.Average3Message += studentService.AverageUnder3;
            Console.Clear();                 
            while (true)
            {
                    Console.Clear();
                    programService.Studnts_menu();
                    var deciosion = Console.ReadLine();
                    try
                    {
                        int choice = int.Parse(deciosion);
                        if (choice > 0 && choice <= 8)
                        {
                            switch (choice)
                            {
                                case 1:
                                    {
                                    Console.Clear();
                                    programService.AddStudents(student, studentService, students);
                                        break;
                                    }
                                case 2:
                                    {
                                    Console.Clear();
                                    programService.AddGrades(students, studentService);
                                        break;
                                    }
                                case 3:
                                    {
                                    Console.Clear();
                                    programService.EditName(students, studentService);                     
                                        break;
                                    }
                                case 4:
                                    {
                                    Console.Clear();
                                    programService.EditSurname(students, studentService);                                      
                                        break;
                                    }
                                case 5:
                                    {
                                    Console.Clear();
                                    programService.ShowAllStudents(students);                                      
                                        break;
                                    }
                                case 6:
                                    {
                                    Console.Clear();
                                    programService.ShowStudnetsStatistic(students, studentService);
                                        break;
                                    }
                                case 7:
                                    {
                                    Console.Clear();
                                    programService.RemoveStudent(students);
                                        break;
                                    }
                                case 8:
                                    {
                                    Console.Clear();
                                    Environment.Exit(0);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("invalid value! Try again ");
                            Thread.Sleep(5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                    }
            }         
        }
    }
}
