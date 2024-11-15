using System;
Console.WriteLine("Введите количество строк массива");
var n = Convert.ToInt32(Console.ReadLine());
int[][] list = new int[n][];
App.Main(list, n);
App.WorkWithList(list, n);
class App
{
    public static void Main(int[][] list, int n)
    {
        var countString = 1;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите размерность строки {countString}");
            var z = Convert.ToInt32(Console.ReadLine());
            list[i] = new int[z];
            Console.WriteLine($"Вводите элементы для строки {countString}");
            for (int j = 0; j < z; j++)
            {
                var x = Convert.ToInt32(Console.ReadLine());
                list[i][j] = x; 
            }
        countString++;
        }
    }
    public static void WorkWithList(int[][] list, int n)
    {
        var countForStrings = 0;
        var count = 1;
        for (int i = 0; i < n; ++i)
        {
            var max = list[i][0];
            var min = list[i][0];
            for (int j = 0; j < list[i].Length; ++j)
            {
                if (max < list[i][j])
                {
                    max = list[i][j];
                }
                if (min > list[i][j])
                {
                    min = list[i][j];
                }
            }
            if (max % 2 == 0)
            {
                if (min % 2 == 0)
                {
                    Console.WriteLine($"В строке {count} максимальный и минимальный элементы чётные");
                    countForStrings++;
                }
            }
            count++;
        
        }
        if (countForStrings == 0)
        {
            Console.WriteLine("Таких строк нет");
        }
    }
}
 