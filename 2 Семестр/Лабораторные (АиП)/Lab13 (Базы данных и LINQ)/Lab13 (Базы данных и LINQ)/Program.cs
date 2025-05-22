using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSupplierDatabase
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }

    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Movement
    {
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static List<Product> products = new List<Product>();
        static List<Supplier> suppliers = new List<Supplier>();
        static List<Movement> movements = new List<Movement>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Управление товарами");
                Console.WriteLine("2. Управление поставщиками");
                Console.WriteLine("3. Управление поставками");
                Console.WriteLine("4. Выполнить запросы");
                Console.WriteLine("5. Выход\n");
                Console.Write("Выберите пункт меню: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ManageProducts();
                        break;
                    case 2:
                        ManageSuppliers();
                        break;
                    case 3:
                        ManageMovements();
                        break;
                    case 4:
                        ExecuteQueries();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Введено некорректное значение");
                        break;
                }
            }
        }

        static void ManageProducts()
        {
            while (true)
            {
                Console.WriteLine("\nУправление товарами:");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Просмотреть все товары");
                Console.WriteLine("3. Назад\n");
                Console.Write("Выберите нужное действие: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        ViewAllProducts();
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("\nВведите ID товара: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Введите наименование товара: ");
            string name = Console.ReadLine();

            products.Add(new Product { ProductId = id, Name = name });
            Console.WriteLine("Товар успешно добавлен");
        }

        static void ViewAllProducts()
        {
            Console.WriteLine("\nСписок товаров:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, наименование: {product.Name}");
            }
        }

        static void ManageSuppliers()
        {
            while (true)
            {
                Console.WriteLine("\nУправление поставщиками:");
                Console.WriteLine("1. Добавить поставщика");
                Console.WriteLine("2. Просмотреть всех поставщиков");
                Console.WriteLine("3. Назад\n");
                Console.Write("Выберите нужное действие: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddSupplier();
                        break;
                    case 2:
                        ViewAllSuppliers();
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void AddSupplier()
        {
            Console.Write("\nВведите ID поставщика: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Введите наименование поставщика: ");
            string name = Console.ReadLine();

            Console.Write("Введите контактный телефон: ");
            string phone = Console.ReadLine();

            suppliers.Add(new Supplier { SupplierId = id, Name = name, Phone = phone });
            Console.WriteLine("Поставщик успешно добавлен");
        }

        static void ViewAllSuppliers()
        {
            Console.WriteLine("\nСписок поставщиков:");
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierId}, наименование: {supplier.Name}, телефон: {supplier.Phone}");
            }
        }

        static void ManageMovements()
        {
            while (true)
            {
                Console.WriteLine("\nУправление поставками:");
                Console.WriteLine("1. Добавить поставку");
                Console.WriteLine("2. Просмотреть все поставки");
                Console.WriteLine("3. Назад\n");
                Console.Write("Выберите нужное действие: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddMovement();
                        break;
                    case 2:
                        ViewAllMovements();
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void AddMovement()
        {
            Console.Write("\nВведите ID поставщика: ");
            int supplierId = int.Parse(Console.ReadLine());

            Console.Write("Введите ID товара: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Введите дату поставки (дата.месяц.год): ");
            DateTime deliveryDate = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Введите количество: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Введите цену за единицу: ");
            decimal price = decimal.Parse(Console.ReadLine());

            movements.Add(new Movement
            { SupplierId = supplierId, ProductId = productId, DeliveryDate = deliveryDate,
                Quantity = quantity,
                Price = price
            });

            Console.WriteLine("Поставка успешно добавлена\n");
        }

        static void ViewAllMovements()
        {
            Console.WriteLine("\nСписок поставок:");
            foreach (var movement in movements)
            {
                var supplier = suppliers.FirstOrDefault(s => s.SupplierId == movement.SupplierId);
                var product = products.FirstOrDefault(p => p.ProductId == movement.ProductId);

                Console.WriteLine($"Поставщик: {supplier?.Name}, " + $"Товар: {product?.Name}, " + $"Дата: {movement.DeliveryDate:d}, " +
                                $"Количество: {movement.Quantity}, " +
                                $"Цена: {movement.Price}, " +
                                $"Сумма: {movement.Quantity * movement.Price}");
            }
        }

        static void ExecuteQueries()
        {
            while (true)
            {
                Console.WriteLine("\nМеню запросов:");
                Console.WriteLine("1. Поставщик, который поставил товар на наибольшую сумму");
                Console.WriteLine("2. Поставки товаров, сгруппированные по датам");
                Console.WriteLine("3. Товары сгруппированные по поставщику и отсортированные по количеству");
                Console.WriteLine("4. Товар, который поставлялся чаще всего");
                Console.WriteLine("5. Сумма поставок, сгруппированных по поставщику");
                Console.WriteLine("6. Назад");
                Console.Write("Выберите нужное действие: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        QueryTopSuppliersByTotalAmount();
                        break;
                    case 2:
                        QueryDeliveriesGroupedByDate();
                        break;
                    case 3:
                        QueryProductsGroupedBySupplier();
                        break;
                    case 4:
                        QueryMostFrequentlyDeliveredProduct();
                        break;
                    case 5:
                        QueryTotalAmountBySupplier();
                        break;
                    case 6:
                        return;
                }
            }
        }

        static void QueryTopSuppliersByTotalAmount()
        {
            var supplierTotals = from m in movements group m by m.SupplierId into g select new
                                 {
                                     SupplierId = g.Key, TotalAmount = g.Sum(x => x.Quantity * x.Price)
                                 };

            var maxTotal = supplierTotals.Max(x => x.TotalAmount);
            var topSuppliers = from st in supplierTotals join s in suppliers on st.SupplierId equals s.SupplierId where st.TotalAmount == maxTotal
                               select new
                               {
                                   s.SupplierId,
                                   s.Name,
                                   s.Phone,
                                   st.TotalAmount
                               };

            Console.WriteLine("\nПоставщики с наибольшей суммой поставок:");
            foreach (var supplier in topSuppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierId}, Наименование: {supplier.Name}, " +
                                $"Телефон: {supplier.Phone}, Сумма: {supplier.TotalAmount}");
            }
        }

        static void QueryDeliveriesGroupedByDate()
        {
            var deliveriesByDate = from m in movements join p in products on m.ProductId equals p.ProductId group p.Name by m.DeliveryDate into g
                                   orderby g.Key
                                   select g;

            Console.WriteLine("\nПоставки товаров, сгруппированные по датам:");
            foreach (var group in deliveriesByDate)
            {
                Console.WriteLine($"Дата: {group.Key:d}");
                foreach (var productName in group)
                {
                    Console.WriteLine($"{productName}");
                }
            }
        }

        static void QueryProductsGroupedBySupplier()
        {
            var productsBySupplier = from m in movements join p in products on m.ProductId equals p.ProductId join s in suppliers on m.SupplierId equals s.SupplierId
                                     group new { p.Name, m.Quantity } by s.Name into g
                                     orderby g.Key
                                     select new
                                     {
                                         SupplierName = g.Key,
                                         Products = g.OrderByDescending(x => x.Quantity)
                                     };

            Console.WriteLine("\nТовары, сгруппированные по поставщику и отсортированные по количеству:");
            foreach (var group in productsBySupplier)
            {
                Console.WriteLine($"Поставщик: {group.SupplierName}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($"{product.Name} (количество: {product.Quantity})");
                }
            }
        }

        static void QueryMostFrequentlyDeliveredProduct()
        {
            var productFrequency = from m in movements group m by m.ProductId into g select new
                                   {
                                       ProductId = g.Key,
                                       Frequency = g.Count()
                                   };

            var maxFrequency = productFrequency.Max(x => x.Frequency);
            var mostFrequentProducts = from pf in productFrequency join p in products on pf.ProductId equals p.ProductId where pf.Frequency == maxFrequency
                                       select p.Name;

            Console.WriteLine("\nТовар, который поставлялся чаще всего:");
            foreach (var product in mostFrequentProducts)
            {
                Console.WriteLine(product);
            }
        }

        static void QueryTotalAmountBySupplier()
        {
            var supplierTotals = from m in movements join s in suppliers on m.SupplierId equals s.SupplierId group m by s.Name into g select new
                                 {
                                     SupplierName = g.Key,
                                     TotalAmount = g.Sum(x => x.Quantity * x.Price)
                                 };

            Console.WriteLine("\nСумма поставок по поставщикам:");
            foreach (var supplier in supplierTotals.OrderByDescending(x => x.TotalAmount))
            {
                Console.WriteLine($"{supplier.SupplierName}: {supplier.TotalAmount}");
            }
        }
    }
}