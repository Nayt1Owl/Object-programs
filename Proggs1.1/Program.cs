using System;
using Core;
using Shop.Bll;
using Shop.Dal;

namespace Shop.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Размещение в репозитории данных\n");

            // Инициализация репозиториев
            var shopXmlRepo = new ShopDaoXmlRepository("shops.xml");
            var clientXmlRepo = new ClientDaoXmlRepository("clients.xml");
            var goodXmlRepo = new GoodDaoXmlRepository("goods.xml");

            var shopJsonRepo = new ShopDaoJsonRepository("shops.json");
            var clientJsonRepo = new ClientDaoJsonRepository("clients.json");
            var goodJsonRepo = new GoodDaoJsonRepository("goods.json");

            // Магазины (3 шт)
            var shops = new List<ShopDao>
            {
                new ShopDao { Id = 1, Name = "DNS", Code = "DNS-01" },
                new ShopDao { Id = 2, Name = "М.Видео", Code = "MVID-02" },
                new ShopDao { Id = 3, Name = "Ситилинк", Code = "CLNK-03" }
            };

            // Клиенты (5 шт)
            var clients = new List<ClientDao>
            {
                new ClientDao { Id = 1, LastName = "Иванов", FirstName = "Алексей", MiddleName = "Сергеевич", BirthDate = new DateTime(1995, 4, 12) },
                new ClientDao { Id = 2, LastName = "Смирнова", FirstName = "Елена", MiddleName = "Игоревна", BirthDate = new DateTime(1998, 9, 23) },
                new ClientDao { Id = 3, LastName = "Кузнецов", FirstName = "Дмитрий", MiddleName = "Олегович", BirthDate = new DateTime(2001, 1, 15) },
                new ClientDao { Id = 4, LastName = "Васильева", FirstName = "Анна", MiddleName = "Максимовна", BirthDate = new DateTime(1990, 11, 5) },
                new ClientDao { Id = 5, LastName = "Петров", FirstName = "Михаил", MiddleName = "Андреевич", BirthDate = new DateTime(2003, 7, 30) }
            };

            // Товары (30 шт)
            var goods = new List<GoodDao>
            {
                new GoodDao { Id = 101, Name = "Ноутбук ASUS ROG Strix G16", Code = "LAP-001", Price = 145000 },
                new GoodDao { Id = 102, Name = "Ноутбук Apple MacBook Air M2", Code = "LAP-002", Price = 115000 },
                new GoodDao { Id = 103, Name = "Ноутбук Lenovo Legion 5", Code = "LAP-003", Price = 108000 },
                new GoodDao { Id = 104, Name = "Ультрабук HUAWEI MateBook X Pro", Code = "LAP-004", Price = 129000 },
                new GoodDao { Id = 105, Name = "ПК ARDOR GAMING NEO M134", Code = "PC-001", Price = 72000 },
                new GoodDao { Id = 106, Name = "Смартфон Apple iPhone 15 Pro", Code = "PHN-001", Price = 110000 },
                new GoodDao { Id = 107, Name = "Смартфон Samsung Galaxy S24 Ultra", Code = "PHN-002", Price = 125000 },
                new GoodDao { Id = 108, Name = "Смартфон Xiaomi 14 Ultra", Code = "PHN-003", Price = 99000 },
                new GoodDao { Id = 109, Name = "Смартфон Google Pixel 8 Pro", Code = "PHN-004", Price = 82000 },
                new GoodDao { Id = 110, Name = "Смартфон POCO X6 Pro", Code = "PHN-005", Price = 32000 },
                new GoodDao { Id = 111, Name = "Мыш беспроводная Logitech G Pro X Superlight", Code = "ACC-001", Price = 13500 },
                new GoodDao { Id = 112, Name = "Механическая клавиатура Dark Project KD87A", Code = "ACC-002", Price = 8900 },
                new GoodDao { Id = 113, Name = "Наушники HyperX Cloud II Wireless", Code = "ACC-003", Price = 14200 },
                new GoodDao { Id = 114, Name = "Коврик для мыши SteelSeries QCk XXL", Code = "ACC-004", Price = 3500 },
                new GoodDao { Id = 115, Name = "Веб-камера Logitech C920 HD Pro", Code = "ACC-005", Price = 7800 },
                new GoodDao { Id = 116, Name = "Монитор LG UltraGear 27GP850-B", Code = "MON-001", Price = 38000 },
                new GoodDao { Id = 117, Name = "Монитор Samsung Odyssey G7 32", Code = "MON-002", Price = 54000 },
                new GoodDao { Id = 118, Name = "Монитор ASUS TUF Gaming VG249Q", Code = "MON-003", Price = 19500 },
                new GoodDao { Id = 119, Name = "Монитор DELL UltraSharp U2723QE", Code = "MON-004", Price = 62000 },
                new GoodDao { Id = 120, Name = "Монитор AOC Gaming C24G2AE", Code = "MON-005", Price = 16000 },
                new GoodDao { Id = 121, Name = "Видеокарта NVIDIA GeForce RTX 4070 Super", Code = "GPU-001", Price = 75000 },
                new GoodDao { Id = 122, Name = "Процессор Intel Core i7-13700K", Code = "CPU-001", Price = 41000 },
                new GoodDao { Id = 123, Name = "Процессор AMD Ryzen 7 7800X3D", Code = "CPU-002", Price = 46000 },
                new GoodDao { Id = 124, Name = "Материнская плата ASUS ROG STRIX B650-A", Code = "MB-001", Price = 28000 },
                new GoodDao { Id = 125, Name = "Оперативная память Kingston FURY Beast DDR5 32GB", Code = "RAM-001", Price = 14500 },
                new GoodDao { Id = 126, Name = "SSD накопитель Samsung 980 PRO 1TB", Code = "SSD-001", Price = 12000 },
                new GoodDao { Id = 127, Name = "Блок питания Corsair RM850x 850W", Code = "PSU-001", Price = 16500 },
                new GoodDao { Id = 128, Name = "Система охлаждения DeepCool LT720", Code = "CLR-001", Price = 11800 },
                new GoodDao { Id = 129, Name = "Игровая консоль Sony PlayStation 5 Slim", Code = "CNS-001", Price = 59000 },
                new GoodDao { Id = 130, Name = "Портативная колонка JBL Charge 5", Code = "AUD-001", Price = 17500 }
            };

            // Сохранение в XML и JSON
            foreach (var shop in shops)
            {
                shopXmlRepo.Create(shop);
                shopJsonRepo.Create(shop);
            }
            foreach (var client in clients)
            {
                clientXmlRepo.Create(client);
                clientJsonRepo.Create(client);
            }
            foreach (var good in goods)
            {
                goodXmlRepo.Create(good);
                goodJsonRepo.Create(good);
            }

            Console.WriteLine("Запись успешно завершена!");
            Console.ReadKey();
        }
    }
}