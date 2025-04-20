using System;
using System.Collections.Generic;
using System.Linq;

class App
{
    public static List<(float, float)> AndrewAlgorith(List<float> xCoords, List<float> yCoords) // алгоритм Эндрю (нахождение выпуклой оболочки)
    {
        if (xCoords == null || yCoords == null)
            throw new ArgumentNullException("Списки координат не могут быть null");

        if (xCoords.Count != yCoords.Count)
            throw new ArgumentException("Количество X и Y координат должно совпадать.");

        var points = new List<(float x, float y)>();
        for (int i = 0; i < xCoords.Count; i++)
        {
            points.Add((xCoords[i], yCoords[i]));
        }

        points = points.Distinct().ToList(); // удаляем одинаковые точки

        if (points.Count <= 3)
            return points;

        points = points.OrderBy(p => p.x).ThenBy(p => p.y).ToList(); // сортировка точек по Х и У 

        var hull = new List<(float x, float y)>();

        for (int i = 0; i < points.Count; i++) // верхняя часть в.о
        {
            while (hull.Count >= 2 && VectorMulti(hull[hull.Count - 2], hull[hull.Count - 1], points[i]) <= 0) // проверяем есть ли невыпуклый угол
            {
                hull.RemoveAt(hull.Count - 1);
            }
            hull.Add(points[i]);
        }

        int lowerHullStart = hull.Count;
        for (int i = points.Count - 2; i >= 0; i--) // нижняя часть в.о
        {
            while (hull.Count >= lowerHullStart && VectorMulti(hull[hull.Count - 2], hull[hull.Count - 1], points[i]) <= 0)
            {
                hull.RemoveAt(hull.Count - 1);
            }
            hull.Add(points[i]);
        }

        if (hull.Count > 1 && hull[0] == hull[hull.Count - 1]) // чистка последней точки 
            hull.RemoveAt(hull.Count - 1);

        return hull;
    }
    private static float VectorMulti((float x, float y) O, (float x, float y) A, (float x, float y) B)
    {
        return (A.x - O.x) * (B.y - O.y) - (A.y - O.y) * (B.x - O.x);
    }

    public static double FindSquare(List<float> list1, List<float> list2, int n)
    {
        if (list1 == null || list2 == null)
            throw new ArgumentNullException("Списки координат не могут быть null");

        if (n <= 0)
            throw new ArgumentException("Количество вершин должно быть положительным");

        var convexHull = AndrewAlgorith(list1, list2);
        int hullCount = convexHull.Count;

        if (hullCount < n)
        {
            Console.WriteLine($"Удалено {n - hullCount} вершин, находящихся внутри выпуклой оболочки");
        }

        if (hullCount < 3)
        {
            Console.WriteLine("Для вычисления площади нужно минимум 3 точки.");
            return 0;
        }

        float sum1 = 0;
        float sum2 = 0;

        for (int i = 0; i < hullCount; i++)
        {
            int next = (i + 1) % hullCount;
            sum1 += convexHull[i].Item1 * convexHull[next].Item2;
            sum2 += convexHull[i].Item2 * convexHull[next].Item1;
        }

        double result = 0.5 * Math.Abs(sum1 - sum2);
        Console.WriteLine($"\nПолучившаяся площадь: {result}");
        return result;
    }

    public static void Main()
    {
        Console.WriteLine("Задача 'Многоугольник'\nВведите количество вершин в многоугольнике");
        var n = Convert.ToInt32(Console.ReadLine());

        if (n < 3)
        {
            Console.WriteLine("Многоугольник должен иметь минимум 3 вершины");
            return;
        }

        List<float> Xs = new List<float>();
        List<float> Ys = new List<float>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите х координату {i + 1} вершины");
            var x = float.Parse(Console.ReadLine());
            Console.WriteLine($"Введите y координату {i + 1} вершины");
            var y = float.Parse(Console.ReadLine());
            Xs.Add(x);
            Ys.Add(y);
        }

        FindSquare(Xs, Ys, n);
    }
}
