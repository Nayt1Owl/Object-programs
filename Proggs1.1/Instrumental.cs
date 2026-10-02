using ObjectProggs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Proggs1
{
    internal class Instrumental
    {
        public static List<Good> InitGoods()
        {
            List<Good> goods = new List<Good>();
            for (int i = 1; i <= 20; i++)
            {
                goods.Add(new Good(i, $"Товар_{i}", $"G-{i}", 100 + i * 50));
            }
            return goods;
        }
        public static void WriteGoods(string fileName, List<Good> goods)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Good g in goods)
                {
                    sw.WriteLine(g.ToString());
                }
            }
        }
        public static List<Good> ReadGoods(string fileName)
        {
            List<Good> goods = new List<Good>();
            if (!File.Exists(fileName)) return goods;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        goods.Add(Good.FromString(line));
                    }
                }
            }
            return goods;
        }
        public static void PrintGoods(List<Good> goods)
        {
            Console.WriteLine("\nРеестр товаров");
            Console.WriteLine("ID\tКод\tЦена\tНазвание");
            Console.WriteLine("--------------------------------------------------");
            foreach (Good g in goods)
            {
                Console.WriteLine($"{g.Id}\t{g.Code}\t{g.Price}\t{g.Name}");
            }
        }
        public static List<Client> InitClients()
        {
            return new List<Client>
            {
                new Client(1, "Бочкарев", "Данил", "Андреевич", new DateTime(1907, 1, 1)),
                new Client(2, "Сабиров", "Амир", "Алмазович", new DateTime(2007, 6, 15)),
                new Client(3, "Балабанов", "Кирилл", "Андреевич", new DateTime(2007, 4, 2)),
                new Client(4, "Шафиков", "Радмир", "Рамилевич", new DateTime(2007, 4, 25)),
                new Client(5, "Гайфуллин", "Эдуард", "Ринатович", new DateTime(2007, 11, 17))
            };
        }
        public static void WriteClients(string fileName, List<Client> clients)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Client c in clients)
                {
                    sw.WriteLine(c.ToString());
                }
            }
        }
        public static List<Client> ReadClients(string fileName)
        {
            List<Client> clients = new List<Client>();
            if (!File.Exists(fileName)) return clients;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        clients.Add(Client.FromString(line));
                    }
                }
            }
            return clients;
        }
        public static void PrintClients(List<Client> clients)
        {
            Console.WriteLine("\nРеестр клиентов");
            Console.WriteLine($"{"ID",-6}{"ФИО",-30}{"Дата рождения",-15}{"Возраст",-10}");
            Console.WriteLine(new string('-', 60));
            foreach (Client c in clients)
            {
                string fullName = $"{c.LastName} {c.FirstName} {c.MiddleName}";
                string ageString = $"{c.Age} лет";
                Console.WriteLine($"{c.Id,-6}{fullName,-30}{c.BirthDate,-15:dd.MM.yyyy}{ageString,-10}");
            }
            Console.WriteLine();
        }
        public static List<Shop> InitShops()
        {
            return new List<Shop>
            {
                new Shop(1, "Магнит", "SH-1"),
                new Shop(2, "Пятерочка", "SH-2"),
                new Shop(3, "Чижик", "SH-3")
            };
        }
        public static void WriteShops(string fileName, List<Shop> shops)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Shop s in shops)
                {
                    sw.WriteLine(s.ToString());
                }
            }
        }
        public static List<Shop> ReadShops(string fileName)
        {
            List<Shop> shops = new List<Shop>();
            if (!File.Exists(fileName)) return shops;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        shops.Add(Shop.FromString(line));
                    }
                }
            }
            return shops;
        }
        public static void PrintShops(List<Shop> shops)
        {
            Console.WriteLine("\nРеестр магазинов");
            Console.WriteLine("ID\tКод\tНазвание");
            Console.WriteLine("-----------------------------------------");
            foreach (var s in shops)
            {
                Console.WriteLine($"{s.Id}\t{s.Code}\t{s.Name}");
            }
        }
    }
}
