﻿using System;
using System.Collections.Generic;

class Graph
{
    public int Vertexes { get; set; }
    public int[,] weightMatrix { get; set; } 

    public int time = 0; // кол-во проходов через вершину

    public Graph(int vertexes, int[,] weights)
    {
        Vertexes = vertexes;
        weightMatrix = weights;
    }
    public void BridgeFinder(int u, bool[] visited, int[] parent, int[] times, int[] Mintimes, List<Tuple<int, int>> bridges) // рекурсия для поиска мостов
    {
        // parent[] - массив вершин ИЗ КОТОРЫЙ мы идём
        // times[] - массив, показывающий, СКОЛЬКО раз мы пришли в данную вершину
        // Mintimes - МИНИМАЛЬНОЕ кол-во раз посещения
        visited[u] = true;
        times[u] = Mintimes[u] = ++time;
        for (int vertexes = 0; vertexes < Vertexes; vertexes++)
        {

            if (weightMatrix[u, vertexes] != 0) // ребро обнаружено
            {
                if (!visited[vertexes]) // непосещено
                {
                    parent[vertexes] = u;
                    BridgeFinder(vertexes, visited, parent, times, Mintimes, bridges);

                    Mintimes[u] = Math.Min(Mintimes[u], Mintimes[vertexes]);
                    if (Mintimes[vertexes] > times[u])
                    {
                        bridges.Add(new Tuple<int, int>(u, vertexes));
                    }
                }
                else if (vertexes != parent[u])
                {
                    Mintimes[u] = Math.Min(Mintimes[u], times[vertexes]);
                }
            }
        }
    }
    public List<Tuple<int, int>> FindBridges() // основной механизм
    {
        bool[] visited = new bool[Vertexes];
        int[] parent = new int[Vertexes];
        int[] times = new int[Vertexes];
        int[] Mintimes = new int[Vertexes];
        List<Tuple<int, int>> bridges = new List<Tuple<int, int>>();

        for (int i = 0; i < Vertexes; i++)
        {
            parent[i] = -1;
            visited[i] = false;
        }

        for (int i = 0; i < Vertexes; i++)
        {
            if (!visited[i])
            {
                BridgeFinder(i, visited, parent, times, Mintimes, bridges);
            }
        }

        return bridges;
    }
}

class App
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер матрицы (Алгоритм работает как в ориентированном графе, так и в неориентированном):");
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
        Console.WriteLine();
        Graph g = new Graph(n, TheWeightMatrix);
        List<Tuple<int, int>> bridges = g.FindBridges();
        if (bridges.Count != 0)
        {
            Console.WriteLine("Мосты в графе:");
            foreach (var bridge in bridges)
            {
                Console.WriteLine($"{bridge.Item1} - {bridge.Item2}");
            }
        }
        else
        {
            Console.WriteLine("В графе нет мостов");
        }
    }
}
