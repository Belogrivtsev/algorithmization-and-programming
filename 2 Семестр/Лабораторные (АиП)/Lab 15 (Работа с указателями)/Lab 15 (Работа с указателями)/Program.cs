using System;
class App
{
    public static void IsPalindrome(int n)
    {
        var number = Convert.ToString(n);
        bool result = true;
        for (int i = 0; i < (number.Length / 2); i++)
        {
            char start = number[i];
            char last = number[number.Length - i - 1];
            if (start != last)
            {
                result = false;
                break;
            }
        }
        if (result)
        {
            Console.WriteLine($"Число {n} является палиндромом");
        }
        else
        {
            Console.WriteLine($"Число {n} НЕ является палиндромом");
        }
    }
    public static void Main()
    {
        unsafe
        {
            int* array = stackalloc int[7];
            Console.WriteLine("Введите 7 элементов:");
            for (int i = 0; i < 7; i++)
            {
                var x = Convert.ToInt32(Console.ReadLine());
                array[i] = x;
            }
            for (int i = 0; i < 7; i++)
            {
                IsPalindrome(array[i]);
            }
        }
    }
}