using System;

class App
{
    public static void FindDistance(double sh1, double dl1, double sh2, double dl2, double radius)
    {
        double sh1Rad = sh1 * Math.PI / 180;
        double dl1Rad = dl1 * Math.PI / 180;
        double sh2Rad = sh2 * Math.PI / 180;
        double dl2Rad = dl2 * Math.PI / 180;

        double deltaDl = Math.Abs(dl1Rad - dl2Rad);
        deltaDl = Math.Min(deltaDl, 2 * Math.PI - deltaDl);
        double result = Math.Sin(sh1Rad) * Math.Sin(sh2Rad) + Math.Cos(sh1Rad) * Math.Cos(sh2Rad) * Math.Cos(deltaDl);

        result = Math.Max(-1, Math.Min(1, result));
        result = Math.Acos(result);
        result = radius * result;

        Console.WriteLine($"Расстояние между городами равно {result:F3}");
    }

    public static void Main()
    {
        Console.WriteLine("Введите широту первого города (-90 до 90):");
        double sh1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите долготу первого города (0 до 359):");
        double dl1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите широту второго города (-90 до 90):");
        double sh2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите долготу второго города (0 до 359):");
        double dl2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите радиус планеты (1 до 30000):");
        double radius = double.Parse(Console.ReadLine());

        FindDistance(sh1, dl1, sh2, dl2, radius);
    }
}