﻿using System;

class App
{
    static void Main()
    {
        Console.WriteLine("Введите размеры области (N M)");
        string[] dimensions = Console.ReadLine().Split();
        int N = int.Parse(dimensions[0]); // ширина
        int M = int.Parse(dimensions[1]); // высота

        Console.WriteLine("Введите количество закрашенных клеток (K)\n");
        var n = Convert.ToInt32(Console.ReadLine());

        bool[,] isPainted = new bool[N + 1, M + 1]; // матрица для закрашенных клеток

        Console.WriteLine("Введите координаты закрашенных клеток (X Y)\n");
        for (int i = 0; i < n; i++)
        {
            string[] coords = Console.ReadLine().Split();
            int X = int.Parse(coords[0]);
            int Y = int.Parse(coords[1]);
            isPainted[X, Y] = true;
        }

        int maxArea = 0;

        // перебираем все возможные прямоугольники
        for (int x1 = 1; x1 <= N; x1++) // левых верх
        {
            for (int y1 = 1; y1 <= M; y1++)
            {
                if (isPainted[x1, y1]) continue; // нашли закрашенную клетку, сразу же переходим к следующему шагу

                int maxX = N;
                int maxY = M;

                for (int x2 = x1; x2 <= maxX; x2++) // правый низ
                {
                    for (int y2 = y1; y2 <= maxY; y2++)
                    {
                        bool isValid = true;
                        for (int x = x1; x <= x2; x++)
                        {
                            for (int y = y1; y <= y2; y++)
                            {
                                if (isPainted[x, y]) // встретили закрашенную клетку - уменьшили границу
                                {
                                    isValid = false;
                                    maxY = y - 1;
                                    break;
                                }
                            }
                            if (!isValid) break;
                        }

                        if (isValid)
                        {
                            int area = (x2 - x1 + 1) * (y2 - y1 + 1);
                            if (area > maxArea)
                                maxArea = area;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        Console.WriteLine($"Максимальная площадь свободного прямоугольника равна {maxArea}");
    }
}