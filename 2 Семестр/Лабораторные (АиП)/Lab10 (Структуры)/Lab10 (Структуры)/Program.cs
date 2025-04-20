class App
{
    public struct Book
    {
        public string FIO { get; set; }
        public string Title { get; set; }
        public int RealeaseYear { get; set; }
        public string PublishTitle { get; set; }
        public string GiveoutDate {  get; set; } // выдана ли?
        public string HandingDate {  get; set; } // сдана ли? 
    }

    public static void FillLibrary(List<Book> books)
    {
        Console.WriteLine("Сколько книг будет в библиотеке?");
        var n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nИнформация о {i + 1} книге:\n");
            Book book = new Book();
            Console.WriteLine("Кто написал книгу?");
            book.FIO = Console.ReadLine();
            Console.WriteLine("Название книги?");
            book.Title = Console.ReadLine();
            Console.WriteLine("Дата выпуска?");
            book.RealeaseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Издательство?");
            book.PublishTitle = Console.ReadLine();
            Console.WriteLine("Дата выдачи? (если книга не выдана, то ставьте точку)");
            var str1 = Console.ReadLine();
            if (str1 == ".") { book.GiveoutDate = "Не выдана"; } else { book.GiveoutDate = str1; }
            Console.WriteLine("Дата сдачи? (если книга не сдана, то ставьте точку)");
            var str2 = Console.ReadLine();
            if (str2 == ".") { book.HandingDate = "Не сдана"; } else { book.HandingDate = str2; }
            books.Add(book);
        }
    }
    public static void FirstChooicing(List<Book> books)
    {
        foreach (Book book in books)
        {
            if (book.GiveoutDate == "Не выдана")
            {
                Console.WriteLine($"\nНайдена подходящая книга:\nФИО автора: {book.FIO}\nНазвание: {book.Title}\nДата выхода: {book.RealeaseYear}\nИздательство: {book.PublishTitle}\n"); 
            }
        }
    }
    public static void SecondChooicing(List<Book> books)
    {
        foreach (Book book in books)
        {
            if (book.GiveoutDate != "Не выдана" && book.HandingDate == "Не сдана")
            {
                Console.WriteLine($"\nНайдена подходящая книга:\nФИО автора: {book.FIO}\nНазвание: {book.Title}\nДата выхода: {book.RealeaseYear}\nИздательство: {book.PublishTitle}\n");
            }
        }
    }
    public static void ShowInfoAboutLibrary(List<Book> books)
    {
        Console.WriteLine("\nПолученная база данных:");
        foreach (Book book in books)
        {
            Console.WriteLine($"ФИО автора: {book.FIO}, Название: {book.Title}, Дата выхода: {book.RealeaseYear}, Издательство: {book.PublishTitle}, Дата выдачи: {book.GiveoutDate}, Дата сдачи: {book.HandingDate}\n");
        }
    }
    static void Main()
    {
        List<Book> books = new List<Book>();
        while (true)
        {
            Console.WriteLine("1. Заполнить библиотеку\n2. Показать книги, которые не выдавались\n3. Показать книги, которые на руках\n4. Выход\n");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    FillLibrary(books); ShowInfoAboutLibrary(books); break;
                case 2:
                    FirstChooicing(books); break;
                case 3:
                    SecondChooicing(books); break;
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }
        
    }
}