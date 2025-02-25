using System;
namespace Lab2;
public interface ISeries // основной интерфейс с методами
{
    double GetPerimeter(double value);
    double GetSquare(double value);
}
public class Name
{
    public static string Title { get; set; }
    public Name(string title)
    {
        Title = title;
    }
}
public class TheCircle : Name, ISeries
{
    public double Radius { get; set; }
    public TheCircle(double radius, string title) : base(title)
    {
        Radius = radius;
    }
    public double GetPerimeter(double radius)
    {
        return 2 * 3.14*radius; // C = 2piR
    }
    public double GetSquare(double radius)
    {
        return 3.14 * Math.Pow(radius, 2); // S = piR^2
    }
}
public class TheSquare : Name, ISeries
{
    public double Side { get; set; }
    public TheSquare(double side, string title) : base(title)
    {
        Side = side;
    }
    public double GetPerimeter(double side)
    {
        return side * 4; // P = a * 4
    }
    public double GetSquare(double side)
    {
        return Math.Pow(side, 2); // S = a^2
    }
}
public class TheEqualSizeTriangle : Name, ISeries
{
    public double Side { get; set; }
    public TheEqualSizeTriangle(double side, string title) : base(title)
    {
        Side = side;
    }
    public double GetPerimeter(double side) // P = a*3
    {
        return side * 3;
    }
    public double GetSquare(double side) // S = a^2*3^0.5/4
    {
        return Math.Pow(side, 2) * Math.Pow(3, 0.5) / 4;
    }
}
class App
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ведите радиус окружности:");
        var a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите сторону квадрата:");
        var b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите сторону равностороннего треуголника");
        var c = Convert.ToInt32(Console.ReadLine());

        ///

        TheCircle circle = new TheCircle(a, "Окружность");
        TheSquare square = new TheSquare(b, "Квадрат");
        TheEqualSizeTriangle triangle = new TheEqualSizeTriangle(c, "Равносторонний треугольник");

        ///

        Console.WriteLine($"Для окружности (круга):\nПериметр = {circle.GetPerimeter(a)}\nПлощадь = {circle.GetSquare(a)}\n");
        Console.WriteLine($"Для квадрата:\nПериметр = {square.GetPerimeter(b)}\nПлощадь = {square.GetSquare(b)}\n");
        Console.WriteLine($"Для Равностороннего треугольника:\nПериметр = {triangle.GetPerimeter(c)}\nПлощадь = {triangle.GetSquare(c)}");
    }
}