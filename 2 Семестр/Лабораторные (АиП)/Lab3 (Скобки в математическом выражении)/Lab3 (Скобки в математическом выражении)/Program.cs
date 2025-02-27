using System;
namespace Lab3;
class App
{
    public static bool FirstChecking(string str)
    {
        bool result = true;
        char[] list = ['{', '}', '[', ']', '(', ')'];
        foreach (var i in list)
        {
            int count = 0;  
            foreach (var j in str)
            {
                if (i == j)
                {
                    count++;
                }
            }
            if (count != 1)
            {
                result = false;
                break;
            }
            count = 0;
        }
        return result;
    }
    public static bool IsBrace(char symbol)
    {
        bool result = false;
        var list = new List<char> { '}', '{', ']', '[', ')', '(' };
        if (list.Contains(symbol) == true)
        {
            result = true;
        }
        return result;
    }
    public static void ShowInfo()
    {
        var list = new List<char> { '}', ']', ')', '(', '[', '{' };
        Stack<char> stackEnter = new Stack<char>(list);
        Console.WriteLine($"{string.Join(" ", stackEnter.ToArray())} - правильный порядок скобок в математическом выражении");
    }
    public static bool IsEmpty(Stack<char> list) // проверка стэка на пустоту
    {
        bool result;
        if (list.Count == 0)
        {
            return result = true;
        }
        else
        {
            return result = false; 
        }
        
    }
    public static bool FinalChecking(string str)
    {
        bool result = false;
        Stack<char> stack = new Stack<char>(); // создание стэка
        foreach (var i in str)
        {
            if (IsBrace(i) == true) // элемент строки - скобка
            {
                if (i == '{') // приход открывающийся скобки - помещаем её на верхушку стэка
                {
                    stack.Push(i);
                }
                if (i == '[')
                {
                    stack.Push(i);
                }
                if (i == '(')
                {
                    stack.Push(i);
                }
                if (i == '}') // приход закрывающийся - смотрим на то, есть ли там соченитание <открыть-закрыть>
                    // если нет, то сразу закрываем весь алгоритм ретурном
                {
                    if (stack.Peek() !=  '{' || IsEmpty(stack))
                    {
                        return false;
                    }
                    stack.Pop();
                }
                if (i == ']')
                {
                    if (stack.Peek() != '[' || IsEmpty(stack))
                    {
                        return false;
                    }
                    stack.Pop();
                }
                if (i == ')')
                {
                    if (stack.Peek() != '(' || IsEmpty(stack))
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
        }
        result = IsEmpty(stack);
        if (result)
        {
            Console.WriteLine("Скобки расставлены верно");
            return result;
        }
        else
        {
            Console.WriteLine("Скобки расставлены неверно");
            return result;
        }
    }

    public static void Main()
    {
        ShowInfo();
        Console.WriteLine("Введите математическое выражение:");
        string expression = Console.ReadLine();
        if (FirstChecking(expression) == true) // ура, в выражении есть все 6 скобок и они встречаются только 1 раз
        {
            FinalChecking(expression); // {[()]}
        }
        else
        {
            Console.WriteLine("Скобки расставлены неверно");
        }
    }
}