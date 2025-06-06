﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
    public int weight { get; set; } // поле, отображающее "шаг вершины" т.е для начальной оно равно нулю, для той, что справа 1 и так далее

    public Vertex(int X, int Y, int Weight)
    {
        this.x = X;
        this.y = Y;
        this.weight = Weight;
    }

    public static void ShowMatrix(List<Vertex> matrix, int argument)
    {
        string StrForUpload = "";
        int CountForUpload = 1;
        for (int i = 0; i < argument; i++)
        {
            StrForUpload += $" {CountForUpload} ";
            CountForUpload++;
        }
        Console.WriteLine($"{StrForUpload}\n");
        CountForUpload = 1;
        for (int i = 0; i < argument; i++)
        {
            for (int j = 0; j < argument; j++)
            {
                Vertex v = matrix.FirstOrDefault(v => v.x == i && v.y == j);
                if (v.weight == 1000) { Console.Write(" x "); } else { Console.Write($" {v.weight} "); }
            }
            Console.WriteLine();
        }
    }

    public static void AddWals(List<Vertex> matrix, int argument)
    {
        // примем вес равный 1000 за стену
        Console.WriteLine("\nСколько стен будет в матрице?");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите координаты {i + 1} стены (строка,столбец)");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(',').Select(i => i.Trim()).ToArray();
            int x = Convert.ToInt32(coordinates[0]) - 1;
            int y = Convert.ToInt32(coordinates[1]) - 1;

            Vertex wall = matrix.FirstOrDefault(v => v.x == x && v.y == y);
            if (wall != null)
            {
                wall.weight = 1000;
            }
        }
    }
    public static void WaveAlgorithm(List<Vertex> matrix, int argument)
    {
        Console.WriteLine("\nВведите координаты начальной вершины (строка,столбец)");
        string startVertex = Console.ReadLine();
        string[] startCoordinates = startVertex.Split(',').Select(i => i.Trim()).ToArray();

        Console.WriteLine("\nВведите координаты конечной вершины (строка,столбец)");
        string endVertex = Console.ReadLine();
        string[] endCoordinates = endVertex.Split(',').Select(i => i.Trim()).ToArray();

        Vertex start = matrix.FirstOrDefault(v => v.x == Convert.ToInt32(startCoordinates[0]) - 1 && v.y == Convert.ToInt32(startCoordinates[1]) - 1);
        Vertex end = matrix.FirstOrDefault(v => v.x == Convert.ToInt32(endCoordinates[0]) - 1 && v.y == Convert.ToInt32(endCoordinates[1]) - 1);

        if (start == null || end == null || start.weight == 1000 || end.weight == 1000)
        {
            Console.WriteLine("Начальная или конечная точка неверны или являются стенами!");
            return;
        }

        start.weight = 0;
        Queue<Vertex> queue = new Queue<Vertex>();
        queue.Enqueue(start);

        bool found = false;

        while (queue.Count > 0 && !found)
        {
            Vertex current = queue.Dequeue();

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (Math.Abs(dx) + Math.Abs(dy) != 1) continue; // исключаем диагонали

                    int nx = current.x + dx;
                    int ny = current.y + dy;

                    if (nx < 0 || nx >= argument || ny < 0 || ny >= argument) continue; // проверяем границы матрицы

                    Vertex neighbor = matrix.FirstOrDefault(v => v.x == nx && v.y == ny);

                    if (neighbor == null || neighbor.weight == 1000 || (neighbor.weight != 0 && neighbor.weight <= current.weight + 1))
                        continue; // если это стена или уже посещенная вершина, пропускаем

                    neighbor.weight = current.weight + 1;
                    queue.Enqueue(neighbor);

                    // проверяем, не достигли ли мы конечной точки
                    if (neighbor.x == end.x && neighbor.y == end.y)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
        }

        if (found)
        {
            Console.WriteLine($"\nКратчайший путь занимает {end.weight} шагов");
        }
        else
        {
            Console.WriteLine("\nПуть не найден");
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите размер матрицы n*n (Алгоритм работает для матриц размером n на n (n от 1 до 9)");
        var n = Convert.ToInt32(Console.ReadLine());
        if (n < 1 || n > 9)
        {
            Console.WriteLine("\nНекорректный размер матрицы: допустимые значения от 1 до 9");
            return;
        }

        List<Vertex> vertices = new List<Vertex>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Vertex vertex = new Vertex(i, j, 0);
                vertices.Add(vertex);
            }
        }
        Console.WriteLine("\nИсходная матрица:\n");
        ShowMatrix(vertices, n);
        AddWals(vertices, n);
        WaveAlgorithm(vertices, n);
    }
}