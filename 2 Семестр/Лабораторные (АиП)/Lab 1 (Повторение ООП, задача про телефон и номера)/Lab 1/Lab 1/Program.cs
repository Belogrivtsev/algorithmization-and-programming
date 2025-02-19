using System;
using System.Security.Cryptography.X509Certificates;
namespace Phone;
public class Phone
{
    public string NumberOfPhone { get; set; }
    public string OperatorOfPhone { get; set; }
    public int YearOfPhone { get; set; }
    public Phone(string number, string provider, int year)
    {
        NumberOfPhone = number;
        OperatorOfPhone = provider;
        YearOfPhone = year;
    }
    public void ShowInfoAboutPhone()
    {
        Console.WriteLine($"Номер: {NumberOfPhone}\nОператор: {OperatorOfPhone}\nГод регистрации: {YearOfPhone}");
    }
}
public class Person
{
    public string Name { get; set; }
    public string City { get; set; }
    public string[] PhonesOfPersons { get; set; }
    public Person(string name, string city, string[] PersonPhones)
    {
        Name = name;
        City = city;
        PhonesOfPersons = PersonPhones;
    }
    public void ShowInfoAboutPerson()
    {
        Console.WriteLine($"Имя: {Name}\nГород: {City}\nНомера телефонов: {string.Join(", ", PhonesOfPersons)}");
    }
}
class App
{
    public static Phone[] phones = new Phone[999];
    public static Person[] persons = new Person[999];
    public static void Main(string[] args)
    {
        do
        {
            Console.WriteLine();
            Console.WriteLine("Меню: \n1. Заполнение базы данных (пользователи) \n2. Заполнение базы данных (телефоны) \n" +
                "3. Первая выборка (по номеру телефона) \n4. Вторая выборка (по оператору) \n" +
                "5. Третья выборка (по году регистрации и списку телефонов) \n6. Выход из программы");
            Console.WriteLine();
            var doChoice = Convert.ToInt32(Console.ReadLine());
            if (doChoice == 1)
            {
                FillPersonsList();
            }
            if (doChoice == 2)
            {
                FillPhonesList();
            }
            if (doChoice == 3)
            {
                DoEqualPhones();
            }
            if (doChoice == 4)
            {
                DoEqualProvider();
            }
            if (doChoice == 5)
            {
                DoEqualListOfPhonesAndYear();
            }
            if (doChoice == 6)
            {
                break;
            }
            if (doChoice != 1 && doChoice != 2 && doChoice != 3 && doChoice != 4 && doChoice != 5 && doChoice != 6)
            {
                Console.WriteLine("Ошибка: в списке нет такого действия");
            }

        } while (true);
        
    }
    public static void FillPersonsList()
    {

    }
    public static void FillPhonesList()
    {
        Console.WriteLine("Введите количество телефонов:");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите сам номер:");
            string Number = Console.ReadLine();
            Console.WriteLine("Введите оператор телефона:");
            string Provider = Console.ReadLine();
            Console.WriteLine("Введите год регистрации:");
            int Year = Convert.ToInt32(Console.ReadLine());
            phones[i] = new Phone(Number, Provider, Year);
        }
    }
    public static void DoEqualPhones()
    {

    }
    public static void DoEqualProvider()
    {

    }
    public static void DoEqualListOfPhonesAndYear()
    {

    }
}



    