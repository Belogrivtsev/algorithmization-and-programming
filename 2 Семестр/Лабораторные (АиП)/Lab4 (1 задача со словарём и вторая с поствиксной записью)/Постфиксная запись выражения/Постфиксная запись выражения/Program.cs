using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
class App
{

    // арифметические операции :

    public static int Sum(List<int> list, int previousResult, int coef)
    {
        //Console.WriteLine($"{previousResult}, {coef}");
        if (coef == 1 && list.Count == 1)
        {
            return 0 + list[0];
        }
        else if (coef == 1)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result += list[i];
            }
            return result;
        }
        else 
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result += list[i];
            }
            return previousResult + result;
        }
    }
    public static int Diff(List<int> list, int previousResult, int coef)
    {
        //Console.WriteLine($"{previousResult}, {coef}");
        if (coef == 1 && list.Count == 1)
        {
            return 0 - list[0];
        }
        else if (coef == 1)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result -= list[i];
            }
            return result;
        }
        else
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result += list[i];
            }
            return previousResult - result;
        }
    }
    public static int Multi(List<int> list, int previousResult, int coef)
    {
        //Console.WriteLine($"{previousResult}, {coef}");
        if (coef == 1 && list.Count == 1)
        {
            return 0;
        }
        else if (coef == 1)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result *= list[i];
            }
            return result;
        }
        else
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result *= list[i];
            }
            return previousResult * result;
        }
    }
    public static int Split(List<int> list, int previousResult, int coef)
    {
        //Console.WriteLine($"{previousResult}, {coef}");
        if (coef == 1 && list.Count == 1)
        {
            if (list[0] == 0)
            {
                Console.WriteLine("На ноль делить нельзя!");
                return 0;
            }
            return 0;
        }
        else if (coef == 1)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == 0)
                {
                    Console.WriteLine("На ноль делить нельзя!");
                    return -1;
                }
                else
                {
                    result /= list[i];
                }
            }
            return result;
        }
        else
        {
            int result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == 0)
                {
                    Console.WriteLine("На ноль делить нельзя!");
                    return -1;
                }
                else
                {
                    result /= list[i];
                }
            }
            return previousResult / result;
        }
    }

    // главный блок кода:

    public static int PostFixExpression(string str)
    {
        int firstEntering = 1; // первое или не первое вхождение в код
        int result = 0;
        string operand = "";
        int operationFlag = 0; // нужно для того, чтобы знать, что была использована операция
        List<int> ListOfOperands = new List<int>();

        for (int i = 0; i < str.Length; i++)
        {
            if (firstEntering == 1)
            {
                if (str[i] != ' ' && !IsOperation(str[i]))
                {
                    operand += str[i];
                }
                else if (IsOperation(str[i]))
                {
                    if (i == str.Length - 1)
                    {
                        result = DoOperation(str[i], ListOfOperands, result, firstEntering);
                        ListOfOperands.Clear();
                        operationFlag = 1;
                        firstEntering = 0;
                    }
                    else if (str[i] == '-' && str[i + 1] != ' ') // для отрицательных чисел
                    {
                        operand += str[i];
                        continue;
                    }
                    else
                    {
                        result = DoOperation(str[i], ListOfOperands, result, firstEntering);
                        ListOfOperands.Clear();
                        operationFlag = 1;
                        firstEntering = 0;
                    }
                }
                else if (operationFlag == 1)
                {
                    operand = "";
                    operationFlag = 0;
                }
                else
                {
                    ListOfOperands.Add(Convert.ToInt32(operand));
                    operand = "";
                }
            }
            else // больше одной операции
            {
                if (str[i] != ' ' && !IsOperation(str[i]))
                {
                    operand += str[i];
                }
                else if (IsOperation(str[i]))
                {
                    if (i == str.Length - 1)
                    {
                        result = DoOperation(str[i], ListOfOperands, result, 0);
                        ListOfOperands.Clear();
                        operationFlag = 1;
                    }
                    else if (str[i] == '-' && str[i + 1] != ' ')
                    {
                        operand += str[i];
                        continue;
                    }
                    else
                    {
                        result = DoOperation(str[i], ListOfOperands, result, 0);
                        ListOfOperands.Clear();
                        operationFlag = 1;
                    }
                }
                else if (operationFlag == 1)
                {
                    operand = "";
                    operationFlag = 0;
                }
                else
                {
                    ListOfOperands.Add(Convert.ToInt32(operand));
                    operand = "";
                }
            }
        }
        Console.WriteLine(result);
        return 0;
    }
    public static int DoOperation(char operation, List<int> list, int previousResult, int coef)
    {
        List<char> OperationsList = new List<char>() {'+', '-', '*', '/'};
        foreach (char i in OperationsList)
        {
            switch(operation)
            {
                case '+':
                    return Sum(list, previousResult, coef);
                case '-':
                    return Diff(list, previousResult, coef);
                case '*':
                    return Multi(list, previousResult, coef);
                case '/':
                    return Split(list, previousResult, coef);
            }
        }
        return 0;
    }
    public static bool IsOperation(char operation)
    {
        List<char> OperationsList = new List<char>() { '+', '-', '*', '/' };
        foreach (char i in OperationsList)
        {
            if (operation == i)
            {
                return true;
            }
        }
        return false;
    }
    static void Main()
    {
        Console.WriteLine("Введите постфиксное выражение (пример: 2 2 + (=> 2 + 2)");
        Console.WriteLine("Вводите выражение правильно, если программа обнаружит присутствие n операций подряд, то будет ошибка (например: 2 2 - +)");
        string exp = Console.ReadLine();
        Console.WriteLine("\nРезультат:\n");
        PostFixExpression(exp);
    }
}