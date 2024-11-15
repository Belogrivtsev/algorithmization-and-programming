using System;
class App
{
    public static void Main()
    {
        Console.WriteLine("Введите размерность массива:(nXm)");
        var n = Convert.ToInt32(Console.ReadLine());
        var m = Convert.ToInt32(Console.ReadLine());
        int[,] list = new int[n, m];
        int[] listWorked = new int[m];
        var counterString = 1;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Вводите элементы строки {counterString}:");
            for (int j = 0; j < m; j++)
            {
                var x = Convert.ToInt32(Console.ReadLine());
                list[i, j] = x;
            }
        }
        int[] sumes = new int[m];
        var sum = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sum = sum + list[j,i];
            }
        listWorked[i] = sum;
        sum = 0;
        }
        var flag = 1;
        for (int i = 0; i < listWorked.Length; i++)
        {
            if (listWorked[i] % 2 != 0)
            {
                flag = 0;
                break;
            }
        }
        if (flag == 0)
        {
            Console.WriteLine("Суммы элементов стобцов не всегда чётные");
        }
        else
        {
            Console.WriteLine("Да, сумма столбцов везде чётная");
        }
        Console.WriteLine(string.Join(" ", listWorked));

    }
}