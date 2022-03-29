using Aplikacja_dla_GIT.Models;


namespace Aplikacja_dla_GIT.Services
{
    public class ProgramSerice 
    {
        public void AddStudents(Student student, StudentService studentService, List<Student> students)
        {
            int licznik =0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Po skoczeniu dodawnia studentow wpisz exit, wprowadz imie i nazwisko ucznia rodzielajac je przycieksiem enetr: ");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                {
                    Console.WriteLine("Zakonczono dodawanie studentow, za 5 sec nastapi powrot do menu ");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    string surname = Console.ReadLine();
                    if (IsDigiOrEmpty(licznik, name) || IsDigiOrEmpty(licznik, surname) == true)
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
                Console.WriteLine("Podaj imie i nazwisko ucznia: ");
                var name = Console.ReadLine();
                var surname = Console.ReadLine();
                for (var item = 0; item < students.Count; item++)
                {
                    if (students[item].Name == name && students[item].Surname == surname)
                    {
                        Console.WriteLine("Po skoczeniu dodawnia ocen wcisnij q, podaj oceny: ");
                        while (true)
                        {
                            var mark = Console.ReadLine();
                            if (mark == "q")
                            {
                                Console.WriteLine("zakonczono dodwanie ocen");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                studentService.AddGrades(students[item], mark);
                            }
                        }
                    }
                    else if (item == students.Count - 1)
                    {
                        Console.WriteLine("Nie znaleziono takiego studenta!");
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
                Console.WriteLine("Podaj imie i nazwisko studenta:");
                string name = Console.ReadLine();
                string surname = Console.ReadLine();
                foreach (var item in students)
                {
                    if (item.Name == name && item.Surname == surname)
                    {
                        Console.WriteLine("Podaj nowe imie: ");
                        string name2 = Console.ReadLine();
                        int licznik = 0;
                        if (IsDigiOrEmpty(licznik, name2)==false)
                        {
                            item.Name = name2;
                            Console.WriteLine($"Imie zosatlo zmienione na: {name2}");
                            Console.ReadKey();
                            break;
                        }
                        break;
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
                Console.WriteLine("Podaj imie i nazwisko studenta:");
                string name = Console.ReadLine();
                string surname = Console.ReadLine();
                foreach (var item in students)
                {
                    if (item.Name == name && item.Surname == surname)
                    {
                        Console.WriteLine("Podaj nowe nazwisko: ");
                        string surname2 = Console.ReadLine();
                        int licznik = 0;
                        if (IsDigiOrEmpty(licznik,surname2) == false)
                        {
                           item.Surname = surname2;
                           Console.WriteLine($"Nazwisko zosatlo zmienione na: {surname2}");
                           Console.ReadKey();
                            break;
                        }
                       
                        break;
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
                Console.WriteLine("Podaj imie i nazwisko studenta:");
                string name = Console.ReadLine();
                string surname = Console.ReadLine();
                foreach (var item in students)
                {
                    if (item.Name == name && item.Surname == surname)
                    {
                        if (item.grades.Count != 0 )
                        {
                            Console.Clear();
                            studentService.ShowStatistic();
                            Console.ReadKey();
                            break;
                        }
                        if(item.grades.Count == 0)
                        {
                            Console.WriteLine("Uczen nie posiada ocen!");
                            Console.ReadKey();
                        }
                        break;
                    }
                }
                break;
            }
        }
        public void RemoveStudent(List<Student> students)
        {
            if (CheckIsNull(students) == true)
            {
                Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                Console.ReadKey();
            }
            Console.WriteLine("Podaj imie i nazwisko studenta:");
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            foreach (var item in students)
            {
                if (item.Name == name && item.Surname == surname)
                {
                    Console.Clear();
                    students.Remove(item);
                    Console.WriteLine("Uczen zostal usuniety, wcisnij dowolny klaiwsz aby wrocic do menu. ");
                    Console.ReadKey();
                    break;
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
        bool CheckIsNull(List<Student> students)
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

        public bool IsDigiOrEmpty(int licznik, string argument)
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
                    licznik++;
                    if (licznik == 1)
                    {
                        Console.WriteLine($"Blad, wprowadzono cyfry.");
                        Console.ReadKey();
                        return true;
                    }
                }
               
            }
            return false;
        }
    }
}
