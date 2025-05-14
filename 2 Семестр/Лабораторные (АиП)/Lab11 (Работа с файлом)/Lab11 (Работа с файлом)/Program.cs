using System;
using System.ComponentModel;
class App
{
    public static List<string> ChooseCorrectStrs(List<string> list)
    {
        List<char> ListOfNumbers = new List<char>(){'0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        List<string> ResultList = new List<string>();
        for (int i = 0; i < list.Count; i++) // простейший алгоритм нахождения всех чисел в строке
        {
            List<int> StrListNumbers = new List<int>();
            string str = list[i];
            string possibleNumber = "";

            for (int j = 0; j < str.Length; j++)
            {
                if (ListOfNumbers.Contains(str[j]))
                {
                    possibleNumber += str[j];
                }
                else if (possibleNumber.Length >= 1)
                {
                    StrListNumbers.Add(int.Parse(possibleNumber));
                    possibleNumber = "";
                }

                if (j == str.Length - 1 && possibleNumber.Length >= 1) // для числа на конце, если таковое есть
                {
                    StrListNumbers.Add(int.Parse(possibleNumber));
                    possibleNumber = "";
                } 
            }
            for (int k = 0; k < StrListNumbers.Count; k++)
            {
                if (StrListNumbers[k] % 2 == 0)
                {
                    ResultList.Add(str);
                    StrListNumbers.Clear();
                    break;
                } // нашли чётное число - сразу закрываем цикл
            }
            StrListNumbers.Clear();
        }
        return ResultList;
    }
    public static void Main()
    {
        Console.WriteLine("Сколько будет строк в файле?");
        var n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Вводите строки:");
        List<string> AllStrs = new List<string>();
        for (int i = 0; i < n; i++)
        {
            AllStrs.Add(Console.ReadLine());
        }
        Console.WriteLine($"\nИсходный массив строк: {string.Join("  | ", AllStrs)}");

        string filePath = "text.txt";

        File.WriteAllLines(filePath, AllStrs);

        AllStrs = ChooseCorrectStrs(AllStrs);

        File.WriteAllLines(filePath, AllStrs); // автоматически закрывает файл

        Console.WriteLine("Итоговое содержимое файла:");
        Console.WriteLine(File.ReadAllText(filePath));
    }
}