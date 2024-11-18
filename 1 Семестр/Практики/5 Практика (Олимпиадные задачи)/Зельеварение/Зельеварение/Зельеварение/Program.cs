using System;
class App
{
    public static void Main()
    {
        Console.WriteLine("Введите количество действий");
        var n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ввод производится в формате: (MIX или WATER или DUST или FIRE)пробел(ИНГРИДИЕНТ)");
        var result = "";
        for (int i = 0; i < n; i++)
        {
            var x = Convert.ToString(Console.ReadLine());
            if (x.Substring(0,3) == "MIX")
            {
                //обработка ингридиента
                var ingridient = x.Substring(4);
                ingridient = ingridient.Replace(" ", "");
                ingridient = ingridient.Replace("1", "");
                ingridient = ingridient.Replace("2", "");
                ingridient = ingridient.Replace("3", "");
                ingridient = ingridient.Replace("4", "");
                ingridient = ingridient.Replace("5", "");
                ingridient = ingridient.Replace("6", "");
                ingridient = ingridient.Replace("7", "");
                ingridient = ingridient.Replace("8", "");
                ingridient = ingridient.Replace("9", "");
                ingridient = ingridient.Replace("0", "");
                ingridient = ingridient.Replace("-", "");
                //запись строки в результат
                result = result + ingridient;
                result = "MX" + result + "XM";
            }
            else if (x.Substring(0, 5) == "WATER")
            {
                var ingridient = x.Substring(6);
                ingridient = ingridient.Replace(" ", "");
                ingridient = ingridient.Replace("1", "");
                ingridient = ingridient.Replace("2", "");
                ingridient = ingridient.Replace("3", "");
                ingridient = ingridient.Replace("4", "");
                ingridient = ingridient.Replace("5", "");
                ingridient = ingridient.Replace("6", "");
                ingridient = ingridient.Replace("7", "");
                ingridient = ingridient.Replace("8", "");
                ingridient = ingridient.Replace("9", "");
                ingridient = ingridient.Replace("0", "");
                ingridient = ingridient.Replace("-", "");
                //запись строки в результат
                result = result + ingridient;
                result = "WT" + result + "TW";
            }
            else if (x.Substring(0, 4) == "DUST")
            {
                var ingridient = x.Substring(5);
                ingridient = ingridient.Replace(" ", "");
                ingridient = ingridient.Replace("1", "");
                ingridient = ingridient.Replace("2", "");
                ingridient = ingridient.Replace("3", "");
                ingridient = ingridient.Replace("4", "");
                ingridient = ingridient.Replace("5", "");
                ingridient = ingridient.Replace("6", "");
                ingridient = ingridient.Replace("7", "");
                ingridient = ingridient.Replace("8", "");
                ingridient = ingridient.Replace("9", "");
                ingridient = ingridient.Replace("0", "");
                ingridient = ingridient.Replace("-", "");
                //запись строки в результат
                result = result + ingridient;
                result = "DT" + result + "TD";
            }
            else if (x.Substring(0, 4) == "FIRE")
            {
                var ingridient = x.Substring(5);
                ingridient = ingridient.Replace(" ", "");
                ingridient = ingridient.Replace("1", "");
                ingridient = ingridient.Replace("2", "");
                ingridient = ingridient.Replace("3", "");
                ingridient = ingridient.Replace("4", "");
                ingridient = ingridient.Replace("5", "");
                ingridient = ingridient.Replace("6", "");
                ingridient = ingridient.Replace("7", "");
                ingridient = ingridient.Replace("8", "");
                ingridient = ingridient.Replace("9", "");
                ingridient = ingridient.Replace("0", "");
                ingridient = ingridient.Replace("-", "");
                //запись строки в результат
                result = result + ingridient;
                result = "FR" + result + "RF";
            }
            else
            {
                Console.WriteLine("Ввод сделан не по формату, строка не засчитывается");
            }
        }
        Console.WriteLine($"Получили заклинание {result}");
    }
}