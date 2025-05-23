﻿using System;
using System.Collections.Generic;

public class App
{
    public static void FordBellman(int[,] weightMatrix, int startVertex, int INF)
    {
        int verticesCount = weightMatrix.GetLength(0);
        int[] distances = new int[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = INF;
        }
        distances[startVertex] = 0;

        for (int k = 0; k < verticesCount - 1; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (weightMatrix[i, j] != INF && distances[i] != INF && distances[i] + weightMatrix[i, j] < distances[j]) // между i и j есть ребро и это не бесконечность
                    {
                        distances[j] = distances[i] + weightMatrix[i, j];
                    }
                }
            }
        }

        for (int i = 0; i < verticesCount; i++) // вдруг есть отрицательный цикл
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (weightMatrix[i, j] != INF)
                {
                    if (distances[i] != INF && distances[i] + weightMatrix[i, j] < distances[j])
                    {
                        Console.WriteLine("Граф содержит отрицательный цикл!");
                        return;
                    }
                }
            }
        }

        Console.WriteLine("\nКратчайшие расстояния от вершины {0}:\n", startVertex + 1);
        for (int i = 0; i < verticesCount; i++)
        {
            Console.WriteLine("До вершины {0}: {1}", i + 1, distances[i] == INF ? "недостижима" : distances[i].ToString());
        }
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

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите размер весовой матрицы:");
        var n = Convert.ToInt32(Console.ReadLine());
        int[,] TheWeightMatrix = new int[n, n];

        int countForElements = 1; // счётчик для строк
        int INF = 999; // сделал также, как и во Флойде: INF = знак бесконечности в матрице
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

        Console.WriteLine("Введите стартовую веришну:");
        var startVertex = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Исходная матрица:\n");

        PrintMatrix(TheWeightMatrix, INF);

        FordBellman(TheWeightMatrix, startVertex - 1, INF);
    }
}