using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MojProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(1, "Jan", "Kowalski", new DateTime(1990, 5, 20), Position.Developer, 8500m),
                new Employee(2, "Anna", "Nowak", new DateTime(1995, 11, 3), Position.Developer, 4000m),
                new Employee(3, "Piotr", "Wiśniewski", new DateTime(1985, 2, 15), Position.Developer, 12000m),
                new Employee(4, "Katarzyna", "Wójcik", new DateTime(1992, 8, 25), Position.Tester, 6500m),
                new Employee(5, "Michał", "Kowalczyk", new DateTime(1998, 1, 10), Position.Tester, 4200m),
                new Employee(6, "Agnieszka", "Kamińska", new DateTime(1988, 7, 30), Position.Manager, 6200m), 
                new Employee(7, "Tomasz", "Lewandowski", new DateTime(1993, 12, 5), Position.Tester, 6200m), 
                new Employee(8, "Magdalena", "Zielińska", new DateTime(1986, 5, 28), Position.Intern, 1500m),
                new Employee(9, "Anna", "Zalisz", new DateTime(1982, 4, 18), Position.Manager, 13200m),
                new Employee(10, "Karol", "Dubosz", new DateTime(1991, 2, 8), Position.Developer, 18500m),
                new Employee(11, "Katarzyna", "Ziel", new DateTime(1989, 2, 16), Position.Manager, 1300m),
                new Employee(12, "Marek", "Kowalczyk", new DateTime(1985, 6, 28), Position.Manager, 16900m),
                
                
                
            };
            
            Console.WriteLine("\n--- ZADANIE 2.1: ZAROBKI > 10000 ---------");

            
            var bogaciPracownicy = employees.Where(emp => emp.Salary > 10000m );

            foreach (var emp in bogaciPracownicy)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Salary} zł");
            }
            Console.WriteLine("\n--- ZADANIE 2.2: Pracownicy na stanowisku Developer ---------");

            var posDev = employees.Where(emp=> emp.Position == Position.Developer);
            
            foreach (var emp in posDev)
            {
                System.Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            Console.WriteLine("\n--- ZADANIE 2.3:  ---------");
            Console.Write("Podaj minimalną pensję: ");
            Console.WriteLine("\n-----------------");
            var odpString = Console.ReadLine();
            decimal odp = decimal.Parse(odpString);

            var pensjaOdp = employees.Where(emp=> emp.Salary > odp);

            foreach (var emp in pensjaOdp)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Salary} zł");
            }
            Console.WriteLine("\n--- ZADANIE 2.4:  ---------");

            Console.Write("Podaj numerek stanowiska: \n");
            for (int i = 1; i < 5; i++)
            {
                System.Console.WriteLine($"{i}. {(Position)i}");
            }
            string numerString = Console.ReadLine();

            int numer = int.Parse(numerString);

            Position wybraneStanowisko = (Position)numer;

            Console.WriteLine($"\n---Pracownicy na stanowisku {wybraneStanowisko} :---------");

            var posWyb = employees.Where(emp=> emp.Position == wybraneStanowisko);
            
            foreach (var emp in posWyb)
            {
                System.Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }
            Console.WriteLine("\n--- ZADANIE 2.5: Czy lista się zmieniła? ---------");
            Console.WriteLine($"Liczba osób na oryginalnej liście: {employees.Count}");
            Linia();
            Linia();
            Linia();
            System.Console.WriteLine("Zadanie 3.1-------------");

            var posortowani = employees.OrderBy(emp => emp.LastName);
            foreach (var emp in posortowani)
            {
                System.Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }
            Linia();

            System.Console.WriteLine("Zadanie 3.2-------------");
            var pospensja = employees.OrderByDescending(emp => emp.Salary);
            System.Console.WriteLine("Pososrotwana lista pracowników według pensji");
            foreach (var emp in pospensja)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Salary} zł");
            }

            LiniaZad("Zad 3.3");

            var devPensjaSort = posDev.OrderByDescending(emp => emp.Salary);
            foreach (var emp in devPensjaSort)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Position} - {emp.Salary} zł");
            }

            LiniaZad("Zad 3.4");
            var z34 = employees.OrderByDescending(emp => emp.Salary).ThenBy(emp => emp.LastName);
            foreach (var emp in z34)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Salary} zł");
            }

            LiniaZad("Zad 4");
            



            
            
        




        }

        static void Linia()
        {
            Console.WriteLine("-------------------------------------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
        }
        static void LiniaZad(string zad)
        {
            int szerokosc = 55;
            string linia = new string('-', szerokosc);
            string tekst = $"----- {zad} -----";

            int iloscSpacji = (szerokosc - tekst.Length) / 2;
            
            string margines = new string(' ', Math.Max(0, iloscSpacji));

            Console.WriteLine(linia);
            Console.WriteLine();
            Console.WriteLine(margines + tekst); 
            Console.WriteLine();
            Console.WriteLine(linia);
        }
        static void PrintReport(IEnumerable<Employee> employees, IReportFormatter formatter)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine(formatter.Format(emp));
            }
        }
        
        static Employee? FindById(IEnumerable<Employee> employees, int id)
        {
            foreach (Employee emp in employees)
            {
                if(id == emp.Id)
                {
                    return emp;
                }
            }
            return null;
        }

        static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp);
                Console.WriteLine("----------------------");
            }
        }


        static decimal CalculateAverageSalary(IEnumerable<Employee> employees)
        {
            decimal sum = 0m; 
            int count = 0;    

            foreach(Employee emp in employees)
            {
                sum += emp.Salary;
                count++;
            }

            if (count == 0)
            {
                return 0m;
            }
            else
            {
                return sum/count;
            }
        }
    }
}