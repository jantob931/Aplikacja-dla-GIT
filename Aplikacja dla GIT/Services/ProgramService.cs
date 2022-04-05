using Aplikacja_dla_GIT.Models;

namespace Aplikacja_dla_GIT.Services
{
    public class ProgramService : IProgramService
    {
        public void AddStudents(Student student, StudentService studentService, List<Student> students)
        {
            int counter = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Po skoczeniu dodawnia studentow wpisz exit, wprowadz imie i nazwisko ucznia rodzielajac je przycieksiem enetr: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "exit")
                {
                    Console.WriteLine("Zakonczono dodawanie studentow, za 5 sec nastapi powrot do menu ");
                    Thread.Sleep(5000);
                    break;
                }
                else
                {
                    string surname = Console.ReadLine();
                    if (IsDigiOrEmpty(counter, name) || IsDigiOrEmpty(counter, surname) == true)
                    {
                        break;
                    }
                    else
                    {
                        bool studentVaildate = studentService.ValidateStudent(students, name, surname);
                        if (studentVaildate)
                        {
                            student = studentService.CreateStudent(name, surname);
                            students.Add(student);
                        }
                    }
                }
            }
        }
        public void AddGrades(List<Student> students, StudentService studentService)
        {
            if (CheckIsNull(students) == true)
            {
                Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                Console.ReadKey();
            }
            if (students.Count != 0)
            {
                var NewStudent = FindStudent(students);
                if (NewStudent != null)
                {
                    Console.Clear();
                    Console.WriteLine("Po skoczeniu dodawnia ocen wcisnij q, podaj oceny: ");
                    while (true)
                    {
                        var mark = Console.ReadLine();
                        if (mark == "q")
                        {
                            Console.Clear();
                            Console.WriteLine("zakonczono dodwanie ocen, wcisnij dowolny przycisk aby wrocic do menu");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            studentService.AddGrades(NewStudent, mark);
                        }
                    }
                }
            }
        }
        public void EditName(List<Student> students, StudentService studentService)
        {
            if (CheckIsNull(students) == true)
            {
                Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                Console.ReadKey();
            }
            if (students.Count != 0)
            {
                var NewStudent = FindStudent(students);
                if (NewStudent != null)
                {
                    Console.Clear();
                    Console.WriteLine("Podaj nowe imie: ");
                    string name2 = Console.ReadLine();
                    int counter = 0;
                    if (IsDigiOrEmpty(counter, name2) == false)
                    {
                        NewStudent.Name = name2;
                        Console.Clear();
                        Console.WriteLine($"Imie zosatlo zmienione na: {name2}");
                        Console.ReadKey();                     
                    }
                }           
            }
        }
        public void EditSurname(List<Student> students, StudentService studentService)
        {
            if (CheckIsNull(students) == true)
            {
                Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                Console.ReadKey();
            }
            if (students.Count != 0)
            {
                var NewStudent = FindStudent(students);
                if (NewStudent != null)
                {
                    Console.WriteLine("Podaj nowe nazwisko: ");
                    string surname2 = Console.ReadLine();
                    int counter = 0;
                    if (IsDigiOrEmpty(counter, surname2) == false)
                    {
                        Console.Clear();
                        NewStudent.Surname = surname2;
                        Console.WriteLine($"Nazwisko zosatlo zmienione na: {surname2}");
                        Console.ReadKey();
                    }
                }
            }
        }
        public void ShowAllStudents(List<Student> students)
        {
            while (true)
            {
                if (CheckIsNull(students) == true)
                {
                    Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                Console.WriteLine("uczniowe: ");
                foreach (var item in students)
                {
                    Console.WriteLine(item.Name + " " + item.Surname);
                }
                Console.WriteLine("Wcisnij dowolny klawisz aby wrocic do menu: ");
                Console.ReadKey();
                break;
            }
        }
        public void ShowStudnetsStatistic(List<Student> students, StudentService studentService)
        {
            while (true)
            {
                if (CheckIsNull(students) == true)
                {
                    Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    var NewStudent = FindStudent(students);
                    if (NewStudent != null)
                    {
                        if (NewStudent.Grades.Count != 0 )
                        {
                            Console.Clear();
                            studentService.ShowStatistic(NewStudent);
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Uczen nie posiada ocen!");
                            Console.ReadKey();
                            break;
                        }
                    }        
                    break;
                }
            }
        }
        public void RemoveStudent(List<Student> students)
        {
            if (CheckIsNull(students) == true)
            {
                Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                if (students.Remove(FindStudent(students)))
                {
                    Console.WriteLine("Uczen zostal usuniety, wcisnij dowolny klaiwsz aby wrocic do menu. ");
                    Console.ReadKey();
                }
            }
        }
        public void Studnts_menu()
        {
            Console.WriteLine("MENU: ");
            Console.WriteLine("1.Dodaj ucznia   ");
            Console.WriteLine("2.Dodaj oceny    ");
            Console.WriteLine("3.Edytuj imie    ");
            Console.WriteLine("4.Edytuj nazwisko");
            Console.WriteLine("5.Wyswietl studentow: ");
            Console.WriteLine("6.Pokaz statystki ucznia");
            Console.WriteLine("7.Usun ucznia   ");
            Console.WriteLine("8.wyjscie");
            Console.WriteLine("wybor: ");
        }
        public bool CheckIsNull(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Error, brak studentow na lsicie");
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsDigiOrEmpty(int counter, string argument)
        {
            Console.Clear();
            if (string.IsNullOrEmpty(argument))
            {
                Console.WriteLine("wprowadzono pusta wartosc!!!");
                Console.ReadKey();
                return true;
            }
            foreach (var ite in argument)
            {
                if (char.IsDigit(ite))
                {
                    counter++;
                    if (counter == 1)
                    {
                        Console.WriteLine($"Blad, wprowadzono cyfry.");
                        Console.ReadKey();
                        return true;
                    }
                }
            }
            return false;
        }     
        public Student FindStudent(List<Student> students)
        {
            Console.WriteLine("Podaj imie i nazwisko studenta:");
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            foreach (var item in students)
            {
                if (item.Name == name && item.Surname == surname)
                {
                    return item;
                }
                if (item == students.Last())
                {
                    if (item.Name != name || item.Surname != surname)
                    {
                        Console.WriteLine("nie ma takiego studenta!!!, wcisnij dowolny klaiwsz aby wrocic do menu.");
                        Console.ReadKey();
                    }
                }               
            }
            return null;         
        }
    }
}
