using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.IO.File;

namespace linq1
{
    class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
    }
    class Department
    {
        public string Name { get; set; }
        public string Reg { get; set; }
    
    }
    class Employ
    {
        public string Name { get; set; }
        public string Department { get; set; }

    }
    class Program
    {
        static void Main()
        {

            var people = new List<Person>();
                people = ReadAllLines("people.txt")
                .Select(line => line.Split(' '))
                .Select(parts => new Person
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    MiddleName = parts[2],
                    Age = int.Parse(parts[3]),
                    Weight = int.Parse(parts[4])
                })
                .ToList();
           var newlist = people.Where(person => person.Age < 40);
            foreach (var person in newlist)
            {
                WriteLine($"{person.LastName} {person.FirstName} {person.MiddleName}, Возраст: {person.Age}, Вес: {person.Weight}");
            }
           var department = new List<Department>()

            {
            new Department { Name = "Отдел закупок ", Reg = "Германия"},
            new Department { Name = "Отдел продаж", Reg ="Испания" },
            new Department { Name = "Отдел маркетинга", Reg ="Испания" }
            };
            var employes = new List<Employ>()

            {
            new Employ {Name="Иванов", Department =" Отдел закупок "},
            new Employ {Name="Петров", Department =" Отдел закупок "},
            new Employ {Name="Сидоров", Department =" Отдел продаж "},
            new Employ {Name="Лямин", Department =" Отдел продаж "},
            new Employ {Name="Сидоренко", Department =" Отдел маркетинга "},
            new Employ {Name="Кривоносов", Department =" Отдел продаж "},
            new Employ {Name="Семёнов", Department =" Отдел продаж "},
            new Employ {Name="Пиманов", Department =" Отдел маркетинга "}

            };
            var resultA = from d in department

                          join e in employes on d.Name equals e.Department

                          select new { Name = e.Name, Department = e.Department };
            var reza = resultA.GroupBy(g => g.Department);
            int i = 0;
            foreach (var group in reza)
            {
                Write($"{group}{i++}");
            }
            var resultB = from e in employes
                          join d in department on e.Department equals d.Name
                          where d.Reg.StartsWith("И")
                          select e.Name;
            WriteLine(String.Join(Environment.NewLine, resultB));
            foreach (var emp in resultB)
            {
                WriteLine(emp);
            }
            ReadKey();
        }
    }
    
}
