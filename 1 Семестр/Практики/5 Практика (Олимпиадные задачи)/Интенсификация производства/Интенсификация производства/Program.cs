using System;
class App
{
    public static void Main()
    {
        ///
        Console.WriteLine("Введите дату начала производства:");
        string date1 = Console.ReadLine();
        Console.WriteLine("Введите дату конца производства:");
        string date2 = Console.ReadLine();
        Console.WriteLine("Введите начальную производственную единицу:");
        int workNumber = Convert.ToInt32(Console.ReadLine());
        ///инициализация переменных
        int date1Day = Convert.ToInt32(date1.Substring(0, 2));
        int date1Month = Convert.ToInt32(date1.Substring(3, 2));
        int date1Year = Convert.ToInt32(date1.Substring(6, 4));
        //
        int date2Day = Convert.ToInt32(date2.Substring(0, 2));
        int date2Month = Convert.ToInt32(date2.Substring(3, 2));
        int date2Year = Convert.ToInt32(date2.Substring(6, 4));
        ///создаём первую "дату"
        DateTime trueDate1 = new DateTime(date1Year, date1Month, date1Day);
        ///создаём вторую "дату"
        DateTime trueDate2 = new DateTime(date2Year, date2Month, date2Day);
        //количество дней, в которых происходит наращивание производства:
        TimeSpan DaysIn = trueDate2 - trueDate1;
        //превращение дней в целочисленной значение (тип данных int)
        int DaysInWork = DaysIn.Days;
        //подсчёт результата
        int result = 0;
        for (int i = 0; i <= DaysInWork; i++)
        {
            result += workNumber;
            workNumber++;
        }
        Console.WriteLine($"Результат: {result}");
    }
}