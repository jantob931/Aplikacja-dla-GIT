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

            Student student = new Student();

            Console.Clear();
            Dosomethink();



            void Studnts_menu()
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


            void Dosomethink()
            {
                while (true)
                {
                    Console.Clear();
                    Studnts_menu();
                    var deciosion = Console.ReadLine();
                    try
                    {


                        int d1 = int.Parse(deciosion);

                        if (d1 > 0 && d1 <= 8)
                        {

                            switch (d1)
                            {
                                case 1:
                                    {
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

                                                bool studentVaildate = studentServixce.ValidateStudent(students, name, surname);

                                                if (studentVaildate)
                                                {
                                                    student = studentServixce.CreateStudent(name, surname);
                                                    students.Add(student);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 2:
                                    {
                                        if (CheckIsNull() == true)
                                        {
                                            Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                                            Console.ReadKey();
                                            break;
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
                                                            studentServixce.AddGrades(students[item], mark);
                                                        }
                                                    }
                                                }
                                                else if (item == students.Count - 1)
                                                {
                                                    Console.WriteLine("Nie znaleziono takiego studenta!");
                                                }
                                            }
                                        }

                                        break;

                                    }
                                case 3:
                                    {
                                        if (CheckIsNull() == true)
                                        {
                                            Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                                            Console.ReadKey();
                                            break;
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
                                                    foreach (var ite in name2)
                                                    {
                                                        if (char.IsDigit(ite))
                                                        {
                                                            licznik++;
                                                            if (licznik == 1)
                                                            {
                                                                Console.WriteLine("Imie nie zostało zmienione, wprowadzono cyfry.");
                                                                Console.ReadKey();
                                                                break;

                                                            }

                                                        }
                                                    }
                                                    if (licznik == 0)
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
                                        break;
                                    }
                                case 4:
                                    {
                                        if (CheckIsNull() == true)
                                        {
                                            Console.WriteLine("Wcisnij dowolny przycisk aby wrocic do menu ");
                                            Console.ReadKey();
                                            break;
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
                                                    foreach (var ite in surname2)
                                                    {
                                                        if (char.IsDigit(ite))
                                                        {
                                                            licznik++;
                                                            if (licznik == 1)
                                                            {
                                                                System.Console.WriteLine("Nazwisko nie zostało zmienione, wprowadzono cyfry. Wcisnij dowolny przycisk aby wrocic do menu");
                                                                Console.ReadKey();
                                                                break;

                                                            }

                                                        }
                                                    }
                                                    if (licznik == 0)
                                                    {
                                                        item.Surname = surname2;
                                                        System.Console.WriteLine($"Nazwisko zosatlo zmienione na: {surname2}");
                                                        Console.ReadKey();
                                                        break;
                                                    }

                                                    break;
                                                }

                                            }

                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        if (CheckIsNull() == true)
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
                                case 6:
                                    {
                                        if (CheckIsNull() == true)
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

                                                Console.Clear();
                                                studentServixce.ShowStatistic();
                                                Console.ReadKey();
                                                break;

                                            }
                                        }
                                        break;



                                    }
                                case 7:
                                    {
                                        if (CheckIsNull() == true)
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

                                                Console.Clear();
                                                students.Remove(item);
                                                Console.WriteLine("Uczen zostal usuniety, wcisnij dowolny klaiwsz aby wrocic do menu. ");
                                                Console.ReadKey();
                                                break;

                                            }
                                        }
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


            bool CheckIsNull()
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

        }

    }

}
