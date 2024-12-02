using System;
using System.Diagnostics.Metrics;
Console.WriteLine("Крестьянини и чёрт");
Console.WriteLine("Введите число, равное максимальному стартовому количеству денег у крестьянина:");
int nGlobal = Convert.ToInt32(Console.ReadLine());
// количество денег, которое будет забирать чёрт (не может быть равно n) должно быть больше n на 1, как минимум, иначе будет бесконечный цикл, либо крестьянин:
int kGlobal = 0;
// количество переходов: 
int z = 0;
// начало вычислений:
if (nGlobal == 0)
{
    Console.WriteLine("Нисколько монет со страта... на что вы рассчитываете? :))");
}
else
{
    Console.WriteLine("Начинаем перебор...");
    Console.WriteLine("                  N K Z");
    int countThrees = 0;
    for (int n = 1; n <= nGlobal; n++)
    {
        var nFor = n; //n с которым производистя действие (нечто вроде заглушки, чтобы не трогать оригинальный n и не ломать программу)
        for (int k = 2; (k != ((n * 2) + 1)); k++)
        {
            while (nFor != 0)
            {
                nFor = nFor * 2;
                nFor = nFor - k;
                if (nFor == 0)
                {
                    z++;
                    Console.WriteLine($"Подходящая тройка {n} {k} {z}");
                    countThrees++;
                    break;
                }
                if (nFor < 0)
                {
                    break; //облегчить работу проги
                }
                if (z > 10) //понять, что что-то не так и приступить к следующему k
                {
                    break;
                }
                z++;
            }
            nFor = n;
            z = 0;
        }
    }
    Console.WriteLine($"Количество подходящих троек равно {countThrees}");
}
//
