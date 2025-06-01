using System;

public class FordFulkerson
{
    private int[,] residualGraph;
    private bool[] visited;
    private int[] parent;
    private int verticesCount;

    public int FindMaxFlow(int[,] capacityGraph, int source, int sink)
    {
        
        verticesCount = capacityGraph.GetLength(0);
        residualGraph = new int[verticesCount, verticesCount];
        parent = new int[verticesCount]; // вершины-родители
        visited = new bool[verticesCount]; // уже посетили

        Array.Copy(capacityGraph, residualGraph, capacityGraph.Length); // остаточная сеть

        int maxFlow = 0;

        while (DFS(source, sink)) // пока существует путь из истока в сток в остаточной сети
        {
            int pathFlow = int.MaxValue;
            for (int v = sink; v != source; v = parent[v]) // минимальная пропускная способность на пути
            {
                int u = parent[v];
                pathFlow = Math.Min(pathFlow, residualGraph[u, v]);
            }

            for (int v = sink; v != source; v = parent[v]) // обновление остаточных пропускных способностей
            {
                int u = parent[v];
                residualGraph[u, v] -= pathFlow;
                residualGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;

            // подготовка к следующей итерации (обнуление родителей)
            Array.Fill(visited, false);
            Array.Fill(parent, -1);
        }

        return maxFlow;
    }
    private bool DFS(int u, int sink) // рекурсия
    {
        if (u == sink)
            return true;

        visited[u] = true;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!visited[v] && residualGraph[u, v] > 0)
            {
                parent[v] = u;
                if (DFS(v, sink))
                    return true;
            }
        }

        return false;
    }
}
public class App
{
    public static void Main()
    {
        Console.Write("Введите размер весовой матрицы: ");
        var n = Convert.ToInt32(Console.ReadLine());
        int[,] TheWeightMatrix = new int[n, n];

        Console.WriteLine("В процессе набора элементы строки 0 будет означать отсутствие пути между вершинами");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы (вес рёбер) {i + 1} строки:");
            for (int j = 0; j < n; j++)
            {
                var x = Convert.ToInt32(Console.ReadLine());
                TheWeightMatrix[i, j] = x;
            }
        }
        // нулевой вершиной принимаем исток, т.е нумерация начинается с нуля
        FordFulkerson exercise = new FordFulkerson();
        Console.Write($"Введите исток (от 0 до {n-1}): ");
        int source = Convert.ToInt32(Console.ReadLine());
        Console.Write($"Введите сток (от 0 до {n - 1}): ");
        int sink = Convert.ToInt32(Console.ReadLine());
        int maxFlow = exercise.FindMaxFlow(TheWeightMatrix, source, sink);

        Console.WriteLine("\nМаксимальный поток: " + maxFlow);
    }
}