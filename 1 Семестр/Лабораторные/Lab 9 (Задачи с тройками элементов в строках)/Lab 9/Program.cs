using System;
using System.Runtime.CompilerServices;
class App
{
    public static void Main()
    {
        Console.WriteLine("Определение символа, который меньше всего встречается в тройке вида 'a*b', * - исходный символ");
        Console.WriteLine($"Введите исходную строку:");
        string str = Convert.ToString(Console.ReadLine());
        string resultStr = "";
        for (int i = 0; i < str.Length - 2; i++)
        {
            if (str[i] == 'a' && str[i+2] == 'b')
            {
                resultStr += Convert.ToString(str[i + 1]);
            }
        }
        //
        int minCount = 99999;
        //Console.WriteLine("Строка с символами:");
        //Console.WriteLine(resultStr);
        string numbersStr = "";
        if (resultStr == "")
        {
            Console.WriteLine("Троек a*b не обнаружено");
        }
        else
        {
            for (int i = 0; i < resultStr.Length; i++)
            {
                string currentLetter = Convert.ToString(resultStr[i]);
                int InStringCount = resultStr.Length - resultStr.Replace(currentLetter, "").Length; // определяем сколько раз встречается символ в тройке a*b
                minCount = Math.Min(minCount, InStringCount);
                numbersStr += Convert.ToString(InStringCount); 
            }
        }
        //Console.WriteLine("Строка с цифрами:");
        //Console.WriteLine(numbersStr);
        char previousChar = ' '; // заглушка для строк
        string finalStr = "";
        for (int i = 0; i < numbersStr.Length; i++)
        {
            //Console.WriteLine($"tetsting: {resultStr[i]} {previousChar} {numbersStr[i]} {minCount}");
            if (resultStr[i] != previousChar && numbersStr[i].ToString() == Convert.ToString(minCount)) 
            {
                finalStr += Convert.ToString(resultStr[i]) + " ";

            }
            previousChar = resultStr[i];
        }
        Console.WriteLine("Элемент(ы) меньше всего встречающиеся в тройках a*b:");
        Console.WriteLine(finalStr);
    }
}