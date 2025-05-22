using System;

class Car
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Mark { get; set; }
}
class User
{
    public int PersonalId { get; set; }
    public int CarId { get; set; }
    public string Fio { get; set; }
    public string Service { get; set; }
    public DateOnly ServiceDate { get; set; }
    public int Expenses { get; set; }

}
class App
{
    static List<User> users = new List<User>();
    static List<Car> cars = new List<Car>();    
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Главное меню:\n");
            Console.WriteLine("1. Добавить машины");
            Console.WriteLine("2. Добавить клиентов");
            Console.WriteLine("3. Перейти в меню выполнения запросов");
            Console.WriteLine("4. Выход\n");
            Console.Write("Выберите пункт меню: ");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddCars();
                    break;
                case 2:
                    AddUsers();
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
        Console.WriteLine("1. Группировка пользователей по марке машины");
        Console.WriteLine("2. Группировка пользователей по дате обращения в сервис, сортировка по услуге");
        Console.WriteLine("3. Показать оказание услуг пользователям в заданный интервал времени, а также итоговую стоимость");
        Console.WriteLine("4. Назад");
        Console.Write("Выберите пункт меню: ");
        var choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                MarkGroup();
                break;
            case 2:
                DateGroup();
                break;
            case 3:
                ShowServices();
                break;
            case 4:
                return;
            default:
                Console.WriteLine("\nТакого пункта нет в меню\n");
                break;
        }
    }
    public static void AddUsers()
    {
        Console.Write("Сколько пользователей? ");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nИнформация о {i + 1} пользователе:\n");
            Console.Write("ID пользователя: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("ID машины пользователя: ");
            var idCar = Convert.ToInt32(Console.ReadLine());
            Console.Write("ФИО пользователя: ");
            var fio = Console.ReadLine();
            Console.Write("Услуга, которой воспользовался пользователь: ");
            var service = Console.ReadLine();
            Console.Write("Дата обращения пользователя (день.месяц.год): ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());
            Console.Write("Сколько стоила данная услуга: ");
            var expenses = Convert.ToInt32(Console.ReadLine());
            users.Add(new User { PersonalId = id, CarId = idCar, Service = service, Fio = fio, ServiceDate = date, Expenses = expenses });
            Console.WriteLine("\nПользователь добавлен\n");
        }
    }
    public static void AddCars()
    {
        Console.Write("Сколько машин? ");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nИнформация о {i + 1} машине:\n");
            Console.Write("ID машины: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Марка машины: ");
            var mark = Console.ReadLine();
            Console.Write("Модель машины: ");
            var model = Console.ReadLine();
            cars.Add(new Car {Id = id, Mark = mark, Model = model });
            Console.WriteLine("\nМашина добавлена\n");
        }
    }
    public static void MarkGroup()
    {
        var UsersByMark = from c in cars
                          join u in users on c.Id equals u.CarId
                          group u by c.Mark into g
                          select new
                          {
                              Mark = g.Key,
                              Users = g.Select(u => u.Fio).ToList()
                          };
        Console.WriteLine("\nПользователи, сгрупированные по марке машины:\n");
        foreach (var g in UsersByMark)
        {
            Console.WriteLine($"Марка машины: {g.Mark}\n Пользователи:");
            foreach (var user in g.Users)
            {
                Console.WriteLine(user);
            }

        }
        QueryExecution();
    }
    public static void DateGroup()
    {
        var UsersByDate = from u in users orderby u.Service group u by u.ServiceDate into g
                          orderby g.Key select new {ServiceDate = g.Key, Users = g.ToList()};
        Console.WriteLine("\nПользователи, сгрупированные по дате обращения в сервис и отсортированные по услуге:\n");
        foreach (var g in UsersByDate)
        {
            Console.WriteLine($"Дата обращения: {g.ServiceDate}\n Пользователи:");
            foreach (var user in g.Users)
            {
                Console.WriteLine($"Услуга - {user.Service}, ФИО - {user.Fio}");
            }

        }
        QueryExecution();
    }
    public static void ShowServices()
    {
        int result = 0;
        Console.Write("\nПервая дата (день.месяц.год): ");
        DateOnly date1 = DateOnly.Parse(Console.ReadLine());
        Console.Write("Вторая дата (день.месяц.год): ");
        DateOnly date2 = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine();

        var UsersByDate = users.Where(u => u.ServiceDate >= date1 && u.ServiceDate <= date2).OrderBy(u => u.ServiceDate).Select(u => new
        {
            u.Fio,
            u.Service,
            u.Expenses,
            u.ServiceDate
        });

        foreach(var user in UsersByDate)
        {
            Console.WriteLine($"Пользователь {user.Fio} обращался за услугой '{user.Service}' " + $"{user.ServiceDate} стоимостью {user.Expenses}");
            result += user.Expenses;
        }
        Console.WriteLine($"\nИтоговая стоимость: {result}\n");
        QueryExecution();
    }
}