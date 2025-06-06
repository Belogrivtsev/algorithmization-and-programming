﻿using System;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential)] // неуправляемая структура 
unsafe struct PhoneRecord
{
    public char* PhoneNumber;
    public char* OperatorName;
    public PhoneRecord* Left;
    public PhoneRecord* Right;
}

unsafe class App
{
    public static char* StringToCharPtr(string str) // метод для конвертации стринга в чар
    {
        fixed (char* ptr = str)
        {
            char* newPtr = (char*)Marshal.AllocHGlobal((str.Length + 1) * sizeof(char));
            for (int i = 0; i < str.Length; i++)
                newPtr[i] = ptr[i];
            newPtr[str.Length] = '\0'; 
            return newPtr;
        }
    }
    public static void InsertRecord(PhoneRecord* root, PhoneRecord* newRecord) // добавляем запись в дерево
    {
        int compare = 0;
        char* p1 = root->PhoneNumber;
        char* p2 = newRecord->PhoneNumber;

        while (*p1 != '\0' && *p2 != '\0' && *p1 == *p2) // сравнение строк
        {
            p1++;
            p2++;
        }
        compare = *p1 - *p2;

        if (compare > 0)
        {
            if (root->Left == null)
                root->Left = newRecord;
            else
                InsertRecord(root->Left, newRecord);
        }
        else
        {
            if (root->Right == null)
                root->Right = newRecord;
            else
                InsertRecord(root->Right, newRecord);
        }
    }
    static void TraverseTree(PhoneRecord* root) // проходимся по всему дереву
    {
        if (root != null)
        {
            TraverseTree(root->Left);
            if (root->OperatorName == StringToCharPtr("МТС")) { Console.WriteLine($"Номер: {new string(root->PhoneNumber)}, Оператор: {new string(root->OperatorName)}"); }
            else { Console.WriteLine($"Номер: {new string(root->PhoneNumber)}, Оператор: {new string(root->OperatorName)}"); }
            TraverseTree(root->Right);
        }
    }
    public static unsafe void Main()
    {
        PhoneRecord* root = (PhoneRecord*)Marshal.AllocHGlobal(sizeof(PhoneRecord)); // корень
        root->PhoneNumber = StringToCharPtr("999");
        root->OperatorName = StringToCharPtr("МТС");
        root->Left = null;
        root->Right = null;

        // Добавляем записи
        PhoneRecord* record2 = (PhoneRecord*)Marshal.AllocHGlobal(sizeof(PhoneRecord)); // объект 1
        record2->PhoneNumber = StringToCharPtr("79098765432");
        record2->OperatorName = StringToCharPtr("Мегафон");
        record2->Left = null;
        record2->Right = null;
        InsertRecord(root, record2);

        PhoneRecord* record3 = (PhoneRecord*)Marshal.AllocHGlobal(sizeof(PhoneRecord)); // объект 2
        record3->PhoneNumber = StringToCharPtr("79234567890");
        record3->OperatorName = StringToCharPtr("Билайн");
        record3->Left = null;
        record3->Right = null;
        InsertRecord(root, record3);

        Console.WriteLine("Вывод объектов дерева (слева направо):");
        TraverseTree(root);
    }
}