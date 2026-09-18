using ObjectProggs;
using System;
using System.Collections.Generic;

namespace Proggs1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Good> initialGoods = Instrumental.InitGoods();
            Instrumental.WriteGoods("goods.txt", initialGoods);
            Console.WriteLine("Создано 20 товаров");
            List<Client> initialClients = Instrumental.InitClients();
            Instrumental.WriteClients("clients.txt", initialClients);
            Console.WriteLine("Создано 5 клиентов");
            List<Shop> initialShops = Instrumental.InitShops();
            Instrumental.WriteShops("shops.txt", initialShops);
            Console.WriteLine("Создано 3 магазина");

            Instrumental.PrintGoods(initialGoods);
            Instrumental.PrintShops(initialShops);
            Instrumental.PrintClients(initialClients);


            List<Good> goods = Instrumental.ReadGoods("goods.txt");
            for (int i = 21; i <= 30; i++)
            {
                goods.Add(new Good(i, $"Новый_Товар_{i}", $"G-{i}", 300 + i * 10));
            }
            Instrumental.WriteGoods("goods.txt", goods);
            Console.WriteLine("Добавлено 10 новых товаров");

            List<Client> clients = Instrumental.ReadClients("clients.txt");
            clients.Add(new Client(6, "Кентов", "Кент", "Кентович", new DateTime(2002, 4, 12)));
            clients.Add(new Client(7, "Дружный", "Друг", "Другович", new DateTime(1998, 7, 25)));
            clients.Add(new Client(8, "Братский", "Брат", "Братович", new DateTime(2010, 9, 5)));
            Instrumental.WriteClients("clients.txt", clients);
            Console.WriteLine("Добавлено 3 новых клиента");

            List<Shop> shops = Instrumental.ReadShops("shops.txt");
            shops.Add(new Shop(4, "Лента", "SH-4"));
            shops.Add(new Shop(5, "Ашан", "SH-5"));
            Instrumental.WriteShops("shops.txt", shops);
            Console.WriteLine("Добавлено 2 новых магазина");

            Instrumental.PrintGoods(goods);
            Instrumental.PrintShops(shops);
            Instrumental.PrintClients(clients);
        }
    }
}
