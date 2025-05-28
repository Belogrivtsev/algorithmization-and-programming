using System;

class App
{
    public unsafe struct Tree
    {
        public int number;
        public string oper;
        public Tree *left;
        public Tree *right;
    }
    public unsafe static void BuildTree(List<Tree> list, List<Tree> left, List<Tree> right)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (right.Count == 0 && left.Count == 0) { right.Add(list[i]); left.Add(list[i]); } // добавление первого корня
            else if (list[i].number > right[i].number)
            {
                right.Add(list[i]);
                right[i - 1].right = 
            }
        }
    }
    public static void Main()
    {
        
        Console.Write("Количество объектов: ");
        var n = Convert.ToInt32(Console.ReadLine());

        List<Tree> list = new List<Tree>();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Номер {i + 1} объекта: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Оператор {i + 1} объекта: ");
            string y = Console.ReadLine();
            list.Add(new Tree { number = x, oper = y, left = null, right = null});
        }
    }
}