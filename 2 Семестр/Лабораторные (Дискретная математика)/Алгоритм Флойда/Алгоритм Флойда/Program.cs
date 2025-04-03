using System;

class App
{
    public static int[,] Floyd(int[,] weights, int INF)
    {
        int vertices = weights.GetLength(0);
        int[,] distances = new int[vertices, vertices];

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                distances[i, j] = weights[i, j];
            }
        }

        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    
                    if (distances[i, k] != INF && distances[k, j] != INF && distances[i, k] + distances[k, j] < distances[i, j]) // проверка на переполнение и существование
                    {
                        distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }
        }
        for (int i = 0; i < vertices; i++) // на случай, если есть отрицательные циклы
        {
            if (distances[i, i] < 0)
            {
                Console.WriteLine("Граф содержит отрицательный цикл!");
                return null;
            }
        }
        return distances;
    }

    public static void PrintMatrix(int[,] matrix, int INF)
    {
        int vertices = matrix.GetLength(0);

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (matrix[i, j] == INF)
                {
                    Console.Write("INF ");
                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
    public static void Main()
    {
        Console.WriteLine("Введите размер весовой матрицы:");
        var n = Convert.ToInt32(Console.ReadLine());
        int[,] TheWeightMatrix = new int[n, n];

        int countForElements = 1; // счётчик для строк
        int INF = 999;
        Console.WriteLine("В процессе набора элементов строки 999 будет означать отсутствие пути между вершинами (бесконечность)");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы (вес рёбер) {countForElements} строки:");
            for (int j = 0; j < n; j++)
            {

                TheWeightMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
            countForElements++;
        }

        Console.WriteLine("Исходная матрица:\n");

        PrintMatrix(TheWeightMatrix, INF);

        int[,] ResultMatrix = Floyd(TheWeightMatrix, INF);

        Console.WriteLine("Матрица кратчайших расстояний:");

        PrintMatrix(ResultMatrix, INF);
    }
}