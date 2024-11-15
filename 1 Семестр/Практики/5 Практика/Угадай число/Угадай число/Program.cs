using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
class App
{
    public static void Main()
    {
        Console.WriteLine("Введите количество действий:");
        var n = Convert.ToInt32(Console.ReadLine());
        //список действий + счётчик
        string[] moves = new string[n];
        var count = 0;
        //список цифр
        int[] numbers = new int[n];
        //список иксов и счётчик для иксов (+ список действий для иксов и сам коэфициент при Х)
        int[] exes = new int[n];
        string[] movesX = new string[n];
        double resultX = 1;
        //объявление результата
        double R = 0;
        for (int i = 0; i < n; i++)
        {
            //цикл ввода действий и переменных
            Console.WriteLine("Введите арифметическую операцию, а затем число (если вводите Х, то операцией может быть только + или -):");
            var move = Convert.ToString(Console.ReadLine());
            var x = Convert.ToString(Console.ReadLine());
            if (x == "x")
            {
                movesX[count] = move; // добавление дейсвтия с Х
                exes[count] = 1; //добавление коэфициентов при Х
                count++;
            }
            else
            {
                moves[count] = move;
                numbers[count] = Int32.Parse(x);
                count++;
            }

        }
        // ПРОВЕРКА НА ТО, ЧТО Х-ов ВООБЩЕ НЕТ
        var sum = 0;
        foreach (var i in exes)
        {
            sum += i;
        }
        //
        Console.WriteLine("Ведите результат:"); Console.WriteLine("(Убедитесь в том, что полученное уравнение будет иметь решение)");
        R = Convert.ToDouble(Console.ReadLine());
        if (sum == 0)
        {
            //
            for (int i = moves.Length - 1; i >= 0; i--)
            {
                double moveNum = numbers[i];
                var moveDos = moves[i];
                if (moveDos == "*")
                {
                    R = R / moveNum;
                }
                if (moveDos == "+")
                {
                    R = R - moveNum;
                }
                else if (moveDos == "-")
                {
                    R = R + moveNum;
                }
            }
            Console.WriteLine($"Загаданное число равно {R}");
        }
        else
        {
            var countDoes = 1; //счётчик действий
            for (int i = moves.Length - 1; i >= 0; i--)
            {
                double moveNum = numbers[i];
                var moveDos = moves[i];
                var moveX = movesX[i];
                if (moveDos == "*")
                {
                    if (countDoes == 1)
                    {
                        resultX = resultX * moveNum;
                    }
                    R = R / moveNum;
                }
                if (moveDos == "+")
                {
                    R = R - moveNum;
                }
                else if (moveDos == "-")
                {
                    R = R + moveNum;
                }
                if (moveX == "+")
                {
                    resultX += 1;
                }
                else if (moveX == "-")
                {
                    resultX -= 1;
                }
                countDoes++;    
            }
            Console.WriteLine($"Коэфициент при Х равен {resultX}");
            if (resultX == 0)
            {
                Console.WriteLine($"Загаданное число равно {R}");
            }
            else
            {
                R = R / resultX;
                Console.WriteLine($"Загаданное число равно {R}");
            }
        }
        //Тесты
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Всё с иксами:");
        Console.WriteLine(String.Join(" ", movesX));
        Console.WriteLine(String.Join(" ", exes));
        Console.WriteLine("Всё с числами:");
        Console.WriteLine(String.Join(" ", moves));
        Console.WriteLine(String.Join(" ", numbers));
    }
}

