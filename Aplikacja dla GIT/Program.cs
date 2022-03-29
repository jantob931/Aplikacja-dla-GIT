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
                                        programSerive.AddStudents(student, studentServixce, students);
                                        break;
                                    }
                                case 2:
                                    {
                                        programSerive.AddGrades(students, studentServixce);
                                        break;
                                    }
                                case 3:
                                    {
                                        programSerive.EditName(students, studentServixce);                     
                                        break;
                                    }
                                case 4:
                                    {
                                        programSerive.EditSurname(students, studentServixce);                                      
                                        break;
                                    }
                                case 5:
                                    {
                                        programSerive.ShowAllStudents(students);                                      
                                        break;
                                    }
                                case 6:
                                    {
                                        programSerive.ShowStudnetsStatistic(students, studentServixce);
                                        break;
                                    }
                                case 7:
                                    {
                                        programSerive.RemoveStudent(students);
                                        break;
                                    }
                                case 8:
                                    {
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
