using System;
class App
{
    public static void Main()
    {
        Console.WriteLine("Введите идентификационный номер (ХХХХ) и имя подчиненного (разделите их пробелом)");
        Console.WriteLine("Программа закончит своё действие после ввода слова END");
        for (int i = 0; i >= 0; i++)
        {
            var StrStart = Convert.ToString(Console.ReadLine());
            if (StrStart == "END")
            {
                break;
            }
            else if (StrStart[4] != ' ')
            {
                Console.WriteLine("Error");
            }
            else
            {

            }
        } 
    }
}