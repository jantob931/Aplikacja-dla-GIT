using Aplikacja_dla_GIT.Models;
using Aplikacja_dla_GIT.Services;

namespace Aplikacja_dla_GIT
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var studentServixce = new StudentService();
            var programSerive = new ProgramSerice();
            Student student = new Student();
            studentServixce.Average3Message += studentServixce.AverageUnder3;
            Console.Clear();                 
            while (true)
            {
                    Console.Clear();
                    programSerive.Studnts_menu();
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
                                    programSerive.AddStudents(student, studentServixce, students);
                                        break;
                                    }
                                case 2:
                                    {
                                    Console.Clear();
                                    programSerive.AddGrades(students, studentServixce);
                                        break;
                                    }
                                case 3:
                                    {
                                    Console.Clear();
                                    programSerive.EditName(students, studentServixce);                     
                                        break;
                                    }
                                case 4:
                                    {
                                    Console.Clear();
                                    programSerive.EditSurname(students, studentServixce);                                      
                                        break;
                                    }
                                case 5:
                                    {
                                    Console.Clear();
                                    programSerive.ShowAllStudents(students);                                      
                                        break;
                                    }
                                case 6:
                                    {
                                    Console.Clear();
                                    programSerive.ShowStudnetsStatistic(students, studentServixce);
                                        break;
                                    }
                                case 7:
                                    {
                                    Console.Clear();
                                    programSerive.RemoveStudent(students);
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
