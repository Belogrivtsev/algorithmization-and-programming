using System;
class App
{
    public static void ShowMatrix(string[,] matrix, int argument)
    {
        string StrForUpload = "";
        int CountForUpload = 1;
        for (int i = 0; i < argument; i++)
        {
            StrForUpload += $"  {CountForUpload}";
            CountForUpload++;
        }
        Console.WriteLine($"{StrForUpload}\n");
        for (int i = 0; i < argument; i++)
        {
            for (int j = 0; j < argument; j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    public static void AddWals(string[,] matrix, int argument)
    {
        Console.WriteLine("Сколько стен будет в матрице?");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите координаты {i + 1} стены");
            string input = Console.ReadLine();
            string[] coordinates = input.Split(',').Select(i => i.Trim()).ToArray();
            matrix[Convert.ToInt32(coordinates[0]) - 1, Convert.ToInt32(coordinates[2]) - 1] = "x";
        }
    }
    static void Main()
    {
        Console.WriteLine("Введите размер матрицы n*n");
        var n = Convert.ToInt32(Console.ReadLine());
        string[,] matrix = new string[n,n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i,j] = "0";
            }
        }
        ShowMatrix(matrix, n);
        AddWals(matrix, n);
        ShowMatrix(matrix, n);  
    }
}