﻿using System;
using System.Linq;

class App
{
    private static int MinDistance(int[] dist, bool[] visitedVertices, int verticesCount)
    {
        int min = int.MaxValue, minIndex = -1; // MaxValue, как аналог знака бесконечности в итерациях

        for (int v = 0; v < verticesCount; v++)
        {
            if (!visitedVertices[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        // вытаскиваем вершину с минимальным расстоянием от начальной, которую ещё не трогали

        return minIndex;
    }
    public static void Deikstra(int[,] graph, int startVertex, int endVertex)
    {
        int verticesCount = graph.GetLength(0);
        int[] dist = new int[verticesCount]; // расстояния
        bool[] visitedVertices = new bool[verticesCount]; // посещённые вершины

        // нулевая итерация

        for (int i = 0; i < verticesCount; i++)
        {
            dist[i] = int.MaxValue;
            visitedVertices[i] = false;
        }

        dist[startVertex] = 0;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinDistance(dist, visitedVertices, verticesCount);
            visitedVertices[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!visitedVertices[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        Console.WriteLine($"Минимальное расстояние от вершины {startVertex} до вершины {endVertex} : {dist[endVertex]}");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер весовой матрицы:");
        var n = Convert.ToInt32(Console.ReadLine());
        int[,] TheWeightMatrix = new int[n, n];

        int countForElements = 1; // счётчик для строк
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы (вес рёбер) {countForElements} строки:");
            for (int j = 0; j < n; j++)
            {

                TheWeightMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
            countForElements++;
        }
        Console.WriteLine($"\nВыберите начальную вершину (от 0 до {n - 1})");
        var startVertex = Convert.ToInt32(Console.ReadLine());
        int endVertex = 0;
        for (int i = 0; i < TheWeightMatrix.GetLength(0); i++)
        {
            if (startVertex != endVertex)
            {
                Deikstra(TheWeightMatrix, startVertex, endVertex);
            }
            endVertex++;
        }
    }
}