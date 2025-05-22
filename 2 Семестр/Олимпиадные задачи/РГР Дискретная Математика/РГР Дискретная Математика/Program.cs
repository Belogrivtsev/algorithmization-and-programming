using System;
using System.Collections.Generic;

class App
{
    static void AddDistance(int[,] graph, string[] cities, string city1, string city2, int distance)
    {
        int i = Array.IndexOf(cities, city1);
        int j = Array.IndexOf(cities, city2);
        graph[i, j] = distance;
        graph[j, i] = distance;
    }
    static int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
    static void Main()
    {
        string[] cities = { "Ст", "К", "П", "Р", "Д", "Л", "Н", "В", "М", "А", "Ж", "Б" };
        int cityCount = 12;

        // матрица расстояний между городами
        int[,] graph = new int[cityCount, cityCount];
        for (int i = 0; i < cityCount; i++)
            for (int j = 0; j < cityCount; j++)
                graph[i, j] = -1; // -1 означает отсутствие пути

        AddDistance(graph, cities, "Ст", "К", 26);
        AddDistance(graph, cities, "Ст", "П", 19);
        AddDistance(graph, cities, "Ст", "Р", 86);
        AddDistance(graph, cities, "К", "Д", 16);
        AddDistance(graph, cities, "К", "Л", 66);
        AddDistance(graph, cities, "П", "Н", 4);
        AddDistance(graph, cities, "П", "В", 51);
        AddDistance(graph, cities, "Д", "В", 21);
        AddDistance(graph, cities, "Н", "М", 21);
        AddDistance(graph, cities, "М", "Л", 24);
        AddDistance(graph, cities, "М", "В", 34);
        AddDistance(graph, cities, "Л", "А", 13);
        AddDistance(graph, cities, "Л", "Ж", 43);
        AddDistance(graph, cities, "А", "Б", 25);
        AddDistance(graph, cities, "Ж", "Р", 31);
        AddDistance(graph, cities, "Ж", "Б", 44);
        AddDistance(graph, cities, "Р", "Б", 22);
        AddDistance(graph, cities, "В", "Ж", 9);

        int start = Array.IndexOf(cities, "Ст"); 
        int end = Array.IndexOf(cities, "Б");   

        int[] distances = new int[cityCount];
        int[] previous = new int[cityCount];
        bool[] visited = new bool[cityCount];

        for (int i = 0; i < cityCount; i++) // заполняем матрицу расстояний
        {
            distances[i] = int.MaxValue;
            previous[i] = -1;
        }
        distances[start] = 0;

        for (int count = 0; count < cityCount - 1; count++) // по сути тот же алгоритм Дейкстры
        {
            int u = MinDistance(distances, visited);
            if (u == -1) break;

            visited[u] = true;

            for (int v = 0; v < cityCount; v++)
            {
                if (!visited[v] && graph[u, v] != -1 && distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                    previous[v] = u;
                }
            }
        }

        List<string> path = new List<string>(); // восстанавливаем путь
        int current = end;
        while (current != -1)
        {
            path.Add(cities[current]);
            current = previous[current];
        }
        path.Reverse();

        Console.WriteLine("Самый короткий путь:");
        Console.WriteLine(string.Join(" - ", path));
        Console.WriteLine($"Общее расстояние равно {distances[end]} км");
    }
}