using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

class Laptop
{
    public string SystemName { get; set; }
    public int SystemID { get; set; }
    public int LaptopID { get; set; }
    public string LaptopBrand { get; set; }
}
class Student
{
    public int ID { get; set; }
    public int Grade { get; set; }
    public string Fio {  get; set; }
    public int SystemID { get; set; }
    public string LaptopBrand { get; set; }
}
class App
{
    static List<Student> students = new List<Student>();
    static List<Laptop> laptops = new List<Laptop>();
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Главное меню:\n");
            Console.WriteLine("1. Добавить ноутбуки");
            Console.WriteLine("2. Добавить студентов");
            Console.WriteLine("3. Перейти в меню выполнения запросов");
            Console.WriteLine("4. Выход\n");
            Console.Write("Выберите пункт меню: ");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddLaptops();
                    break;
                case 2:
                    AddStudents();
                    break;
                case 3:
                    QueryExecution();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("\nТакого пункта нет в меню\n");
                    break;
            }

        }
    }
    public static void QueryExecution()
    {
        Console.WriteLine("\nМеню выполнения запросов:\n");
        Console.WriteLine("1. Выдать список учеников, которые имеют ноутбук");
        Console.WriteLine("2. Группировка учеников по классу, сортировка по марке ноутбука");
        Console.WriteLine("3. Выборка учеников, у которых марка ноутбука соответствует заданной");
        Console.WriteLine("4. Группировка учеников по типу ОС");
        Console.WriteLine("5. Назад");
        Console.Write("Выберите пункт меню: ");
        var choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                HaveLaptop();
                break;
            case 2:
                GradeGroup();
                break;
            case 3:
                TrueBrand();
                break;
            case 4:
                BrandGroup();
                break;
            case 5:
                return;
            default:
                Console.WriteLine("\nТакого пункта нет в меню\n");
                break;
        }
    }
    public static void AddLaptops()
    {
        Console.Write("Сколько ноутбуков? ");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nИнформация о {i + 1} ноутбуке:\n");
            Console.Write("Название операционной системы: ");
            var systemName = Console.ReadLine();
            Console.Write("ID операционной системы (ID должен быть больше нуля): ");
            var systemId = Convert.ToInt32(Console.ReadLine());
            Console.Write("ID ноутбука: ");
            var laptopId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Марка ноутбука: ");
            var laptopBrand = Console.ReadLine();
            laptops.Add(new Laptop { LaptopBrand = laptopBrand, LaptopID = laptopId, SystemID = systemId, SystemName = systemName });
            Console.WriteLine("\nНоутбук добавлен\n");
        }
    }
    public static void AddStudents()
    {
        Console.Write("Сколько студентов? ");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nИнформация о {i + 1} студенте:\n");
            Console.Write("Номер студента: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Класс студента: ");
            var studentGrade = Convert.ToInt32(Console.ReadLine());
            Console.Write("ФИО студента: ");
            var studentFio = Console.ReadLine();
            Console.Write("Марка ноутбука (если предполагается, что компьюетера нет, то пишите 'null'): ");
            var laptopBrand = Console.ReadLine();
            if (laptopBrand == "null")
            {
                students.Add(new Student { Fio = studentFio, Grade = studentGrade, ID = studentId, LaptopBrand = null, SystemID = 0 });
                Console.WriteLine("\nСтудент добавлен\n");
            }
            else
            {
                Console.Write("ID операционной системы (ID должен быть больше нуля): ");
                var systemId = Convert.ToInt32(Console.ReadLine());
                students.Add(new Student { Fio = studentFio, Grade = studentGrade, ID = studentId, LaptopBrand = laptopBrand, SystemID = systemId });
                Console.WriteLine("\nСтудент добавлен\n");
            }

        }
    }
    public static void HaveLaptop()
    {
        var LaptopStudents = students.Where(s => s.LaptopBrand != null).OrderBy(s => s.LaptopBrand).Select(s => new
        {
            s.ID, s.Fio, s.Grade, s.SystemID, s.LaptopBrand
        });
        Console.WriteLine("\nПолученный список:\n");
        foreach (var student in LaptopStudents)
        {
        Console.WriteLine($"Нашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}; Класс: {student.Grade}; ID системы: {student.SystemID}; Марка ноутбука: {student.LaptopBrand}");  
        }
        QueryExecution();
    }
    public static void GradeGroup()
    {
        var GroupedStudents = from s in students orderby s.LaptopBrand group s by s.Grade into g orderby g.Key select new
        {
            Grade = g.Key,
            Students = g.ToList()
        };
        Console.WriteLine("\nПолученный список:\n");
        foreach (var g in GroupedStudents)
        {
            Console.WriteLine($"Класс студентов: {g.Grade}");
            foreach (var student in g.Students)
            {
                if (student.LaptopBrand != null)
                {
                    Console.WriteLine($"\nНашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}; ID системы: {student.SystemID}; Марка ноутбука: {student.LaptopBrand}\n");
                }
                else
                {
                    Console.WriteLine($"Нашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}; Нет ноутбука!");
                }
                
            }
        }
        QueryExecution();
    }
    public static void TrueBrand()
    {
        var CorrectStudents = from l in laptops join s in students on l.LaptopBrand equals s.LaptopBrand into g select new
        {
            Students = g.ToList()
        };
        Console.WriteLine("\nПолученный список:\n");
        foreach (var g in CorrectStudents)
        {
            foreach (var student in g.Students)
            {
                Console.WriteLine($"Нашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}; Марка ноутбука: {student.LaptopBrand}\n");
            }
        }
        QueryExecution();

    }
    public static void BrandGroup()
    {
        var GroupedStudents = from s in students
                              group s by s.SystemID into g
                              orderby g.Key
                              select new
                              {
                                  SystemID = g.Key,
                                  Students = g.ToList()
                              };
        Console.WriteLine("\nПолученный список:\n");
        foreach (var g in GroupedStudents)
        {
            if (g.SystemID == 0)
            {
                Console.WriteLine("Студенты у которых нет ноутбука:");
                foreach (var student in g.Students)
                {
                    Console.WriteLine($"Нашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}\n");
                }
            }
            else
            {
                Console.WriteLine($"Тип операционной системы (ID): {g.SystemID}");
                foreach (var student in g.Students)
                {
                    Console.WriteLine($"Нашёлся подходящий студент:\nНомер: {student.ID}; Имя: {student.Fio}; Марка ноутбука: {student.LaptopBrand}\n");
                }
            }
        }
        QueryExecution();
    }
}