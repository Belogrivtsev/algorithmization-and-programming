using System;
using System.Collections.Generic;

class PrimAlgorithm
{
    public static void FindMinTree(int[,] graph, int vertexesCount)
    {

        int[] notIncludeV = new int[vertexesCount]; // массив вершин, которые ещё не вошли в дерево

        int[] minWeights = new int[vertexesCount]; // массив минимальных весов вершин

        bool[] IncludeV = new bool[vertexesCount]; // массив вершин, которые уже в дереве

        for (int i = 0; i < vertexesCount; i++) // инициализируем веса
        {
            minWeights[i] = int.MaxValue;
            IncludeV[i] = false;
        }
        minWeights[0] = 0; // вес стартовой вершины (нулевой)
        notIncludeV[0] = -1; // стартовая вершина не включена

        var priorityQueue = new PriorityQueue<int, int>(); // что-то по типу массива с приоритетом рёбер (вершин)
        priorityQueue.Enqueue(0, minWeights[0]); // добавляет элемент в массив в последнюю очередь

        while (priorityQueue.Count > 0) // основной функционал
        {
            int u = priorityQueue.Dequeue(); // извлекаем вершину с минимальным весом

            IncludeV[u] = true; // добавляем её

            for (int v = 0; v < vertexesCount; v++) // обновляем веса
            {
                // если есть ребро между вершинами и его вес меньше имеющегося веса
                if (graph[u, v] != 0 && !IncludeV[v] && graph[u, v] < minWeights[v])
                {

                    minWeights[v] = graph[u, v];
                    notIncludeV[v] = u; // обновляем
                    priorityQueue.Enqueue(v, minWeights[v]); // добавляем в приоритетную очередь
                }
            }
        }
        PrintMinTree(notIncludeV, graph, vertexesCount); // выводим ответ
    }


    private static void PrintMinTree(int[] parent, int[,] graph, int vertexesCount) // функция вывода ответа
    {
        int resultSum = 0;
        Console.WriteLine("Рёбра остовного дерева:");
        for (int i = 1; i < vertexesCount; i++)
        {
            Console.WriteLine(parent[i] + " - " + i);
            resultSum += graph[i, parent[i]];
        }
        Console.WriteLine($"\nИтоговый вес минимального оставного дерева: {resultSum}");
    }
    public static void Main()
    {
        Console.WriteLine("Введите размер матрицы (Матрица будет обработана до симметричной, начиная с 1 строки):");
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

        // обработка матрицы для того, чтобы она была симметричной

        int count = 0;

        for (int i = 0; i < n; i++)
        {
            TheWeightMatrix[i, i] = 0; // на главной диагонале все нули
        }
        for (int i = 0; i < n; i++) // придание матрице симметричности начиная с 1ой строки
        {
            count = i;
            while (count < n)
            {
                if (TheWeightMatrix[i, count] == 0)
                {
                    TheWeightMatrix[count, i] = 0;
                }
                else if (TheWeightMatrix[i, count] != 0)
                {
                    TheWeightMatrix[count, i] = TheWeightMatrix[i, count];
                }
                count++;
            }

        }
        FindMinTree(TheWeightMatrix, n);
    }
}