using System;
using System.Diagnostics;
using System.Text;
namespace AwfulExercise;
public class Rib
{
    public int Start { get; set; }
    public int End { get; set; }
    public int Weight { get; set; }
    public Rib(int start, int end, int weight)
    {
        Start = start;
        End = end;
        Weight = weight;
    }
    
}

class App
{
    public static bool SearchSimmetryRib(Rib[] list, Rib argument) // функция поиска симметричного ребра
    {
        //Console.WriteLine("\nНачало работы метода...\n");
        bool result = false;
        Rib SymArgument = new Rib(argument.End, argument.Start, argument.Weight); // тут создаётся симметричное ребро для того, чтобы не допустить появление пар по типу (1,2) (2,1)
        foreach (var i in list)
        {
            //Console.WriteLine($"Симметричное ребро имеет параметры: начало = {SymArgument.Start} конец = {SymArgument.End} вес = {SymArgument.Weight}");
            if (i != null)
            {
                //Console.WriteLine($"Сравниваемое ребро имеет параметры: начало = {i.Start} конец = {i.End} вес = {i.Weight}");
            }
            else
            {
                //Console.WriteLine("Пока что список пуст");
            }
            if (i != null)
            {
                if (i.Start == SymArgument.Start && i.End == SymArgument.End && i.Weight == SymArgument.Weight) // если в списке находится такое симметричное ребро, то сразу вырубаем список
                {
                    result = true;
                    break;
                }
            }
            //Thread.Sleep(100);
        }
        //Console.WriteLine($"result = {result}");
        return result;
    }

    public static bool SearchElement(string str, int argument)
    {
        bool result = false;
        foreach (var i in str)
        {
            if (Convert.ToString(i) == Convert.ToString(argument))
            {
                result = true;
                break;
            }
        }
        return result;
    }

    public static void ShowInfoAboutRibs(Rib[] list)
    {
        Console.WriteLine("\nИнформация о рёбрах:\n");
        int showCount = 1;
        foreach (var i in list)
        {
            Console.WriteLine($"{showCount} ребро:\nначало = {i.Start}\nконец = {i.End}\nвес = {i.Weight}");
            showCount++;
        }
    }

    public static void ShowGraph(int[,] graph, int argument)
    {
        Console.WriteLine();
        Console.WriteLine("Номера вершин:");
        string StrForUpload = "";
        int CountForUpload = 1;
        for (int i = 0; i < argument; i++)
        {
            StrForUpload += $"  {CountForUpload}";
            CountForUpload++;
        }
        Console.WriteLine(StrForUpload);
        Console.WriteLine();
        for (int i = 0; i < argument; i++)
        {
            for (int j = 0; j < argument; j++)
            {
                Console.Write("{0,3}", graph[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static void ShowInfoAboutGraph(int[,] graph, int argument)
    {
        Console.WriteLine();
        Console.WriteLine("Информация:");
        for (int i = 0; i < argument; i++)
        {
            for (int j = 0; j < argument; j++)
            {
                if (graph[i, j] == 1)
                {
                    Console.WriteLine($"{i + 1} связана с {j + 1}");
                }
            }
        }
    }
    public static void SwapElements(ref Rib first, ref Rib second) // метод замены элементов в массиве
    {
        var temp = first;
        first = second;
        second = temp;
    }
    public static void ShowResult(string str)
    {
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (i == str.Length - 1) // 
            {
                result += str[i];
            }
            else
            {
                result += $"{str[i]}, ";
            }
        }
        Console.WriteLine($"Получившийся путь: [{result}]");
    }
    static void Main()
    {

        // Код для создания весовой матрицы + сразу делаем копию матрицы смежности

        Console.WriteLine("Введите размер матрицы (Матрица будет обработана до симметричной, начиная с 1 строки):");
        var n = Convert.ToInt32(Console.ReadLine());
        int[,] TheMainMatrix = new int[n, n];
        int[,] TheWeightMatrix = new int[n, n];

        int countForElements = 1; // счётчик для строк
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы {countForElements} строки:");
            for (int j = 0; j < n; j++)
            {
                TheWeightMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                if (TheWeightMatrix[i, j] != 0)
                {
                    TheMainMatrix[i, j] = 1;
                }
                else
                {
                    TheMainMatrix[i,j] = 0;
                }
            }
            countForElements++;
        }
        Console.WriteLine();
        // Обработка матрицы для того, чтобы она была симметричной 
        int count = 0; // базовый счётчик
        for (int i = 0; i < n; i++)
        {
            TheMainMatrix[i, i] = 0; // на главной диагонале все нули
        }
        for (int i = 0; i < n; i++) // придание матрице симметричности начиная с 1ой строки
        {
            count = i;
            while (count < n)
            {
                if (TheMainMatrix[i, count] == 0)
                {
                    TheMainMatrix[count, i] = 0;
                }
                else if (TheMainMatrix[i, count] == 1)
                {
                    TheMainMatrix[count, i] = 1;
                }
                count++;
            }

        }
        // Обработка матрицы для того, чтобы она была симметричной

        // Обработка весовой матрицы для того, чтобы она была симметричной 
        count = 0; // 
        for (int i = 0; i < n; i++)
        {
            TheWeightMatrix[i, i] = 0; // на главной диагонале все нули
        }
        for (int i = 0; i < n; i++) // придание матрице симметричности начиная с 1ой строки
        {
            count = i;
            while (count < n)
            {
                if (TheWeightMatrix[i, count] == 0)
                {
                    TheWeightMatrix[count, i] = 0;
                }
                else if (TheWeightMatrix[i, count] != 0) 
                {
                    TheWeightMatrix[count, i] = TheWeightMatrix[i, count];
                }
                count++;
            }

        }
        // Определения кол-ва рёбер

        int countOfRibs = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (TheMainMatrix[i, j] == 1 && TheMainMatrix[j, i] == 1)
                {
                    countOfRibs++;
                }
            }
        }
        countOfRibs /= 2;
        Console.WriteLine($"Кол-во рёбер = {countOfRibs}");

        //Код для определения чё вообще происходит с графом

        Console.WriteLine("Матрица смежности");
        ShowGraph(TheMainMatrix, n);
        Console.WriteLine("Весовая матрица");
        ShowGraph(TheWeightMatrix, n);
        ShowInfoAboutGraph(TheMainMatrix, n);

        //Главный функционал программы
        Rib[] ListOfRibs = new Rib[countOfRibs];
        countOfRibs = 0;

        // Заполнение списка рёбер

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Rib PotentialRib = new Rib(i + 1, j + 1, TheWeightMatrix[i, j]); // создаём ребро с началом, концом и весом
                if (TheMainMatrix[i, j] == 1 && SearchSimmetryRib(ListOfRibs, PotentialRib) == false) // проверяем, что симметричного ребра нет
                {
                    ListOfRibs[countOfRibs] = PotentialRib;
                    //Console.WriteLine($"{countOfRibs} Добавленное ребро:\nначало = {PotentialRib.Start}\nконец = {PotentialRib.End}\nвес = {PotentialRib.Weight}");
                    countOfRibs++;

                }
            }
        }

        //Сортировка рёбер (классический пузырёк)

        for (int i = 1; i < ListOfRibs.Length; i++)
        {
            for (int j = 0; j < ListOfRibs.Length - i; j++)
            {
                if (ListOfRibs[j].Weight > ListOfRibs[j + 1].Weight)
                {
                    SwapElements(ref ListOfRibs[j], ref ListOfRibs[j + 1]);
                }
            }
        }

        ShowInfoAboutRibs(ListOfRibs); // просто, чтобы видеть всю информацию о получившемся списке

        // Составление пути

        string TheWay = "";
        int TheWayLength = 0;
        count = 0;
        for (int i = 0; i < ListOfRibs.Length; i++)
        {
            int previousLength = TheWay.Length;
            //Console.WriteLine($"previousLength = {previousLength}");
            if (SearchElement(TheWay, ListOfRibs[i].Start) == false)
            {
                TheWay += Convert.ToString(ListOfRibs[i].Start);
            }
            if (SearchElement(TheWay, ListOfRibs[i].End) == false)
            {
                TheWay += Convert.ToString(ListOfRibs[i].End);
                count++;    
            }
            if (Math.Abs(TheWay.Length - previousLength) > 0) // понимаем, что в путь добавилась вершина
            {
                TheWayLength += ListOfRibs[i].Weight;
            }
            //Console.WriteLine($"TheWay.Length = {TheWay.Length}");
        }
        Console.WriteLine("\nОкончательный ответ:\n");
        ShowResult(TheWay);
        Console.WriteLine($"Получившаяся длина: {TheWayLength}");


    }
}