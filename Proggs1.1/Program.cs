using ObjectProggs;
using Proggs1._1;
using System;
using System.Collections.Generic;

namespace Proggs1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IRepository<GoodDao> goodRepo = new GoodDaoFileRepository("goods.txt");
            IRepository<ClientDao> clientRepo = new ClientDaoFileRepository("clients.txt");
            IRepository<ShopDao> shopRepo = new ShopDaoFileRepository("shops.txt");

            Console.WriteLine("Тест\n");
            Console.WriteLine("CREATE");
            GoodDao newGood = new GoodDao(21, "Шоколад", "G-21", 120);
            goodRepo.Create(newGood);
            Console.WriteLine("Добавлен товар: ID 21 (Шоколад)");
            ClientDao newClient = new ClientDao(6, "Кентов", "Кент", "Кентович", new DateTime(2002, 4, 12));
            clientRepo.Create(newClient);
            Console.WriteLine("Добавлен клиент: ID 6 (Кентов Кент)");
            ShopDao newShop = new ShopDao(4, "Лента", "SH-4");
            shopRepo.Create(newShop);
            Console.WriteLine("Добавлен магазин: ID 4 (Лента)\n");

            Console.WriteLine("READ ALL");
            Console.WriteLine("Список всех клиентов из файла:");
            Console.WriteLine($"{"ID",-6}{"ФИО",-30}{"Дата рождения",-15}{"Возраст",-10}");
            List<ClientDao> allClients = clientRepo.ReadAll();
            foreach (ClientDao c in allClients)
            {
                string fullName = $"{c.LastName} {c.FirstName} {c.MiddleName}";
                string ageString = $"{c.Age} лет";
                Console.WriteLine($"{c.Id,-6}{fullName,-30}{c.BirthDate,-15:dd.MM.yyyy}{ageString,-10}");
            }

            Console.WriteLine("\nREAD");
            ClientDao searchedClient = clientRepo.Read(6);
            if (searchedClient != null)
            {
                Console.WriteLine($"Найден клиент с ID 6: {searchedClient.LastName} {searchedClient.FirstName}, Возраст: {searchedClient.Age}");
            }
            else
            {
                Console.WriteLine("Клиент с ID 6 не найден.");
            }

            Console.WriteLine("\nUPDATE");
            if (searchedClient != null)
            {
                searchedClient.LastName = "Обновленный";
                searchedClient.FirstName = "Клиент";
                clientRepo.Update(searchedClient);
                Console.WriteLine("Данные клиента с ID 6 успешно обновлены в файле.");
            }
            // Проверяем результат обновления через Read
            ClientDao updatedClient = clientRepo.Read(6);
            Console.WriteLine($"Новые данные в файле: {updatedClient.LastName} {updatedClient.FirstName}");

            Console.WriteLine("\nDELETE");
            goodRepo.Delete(21);
            Console.WriteLine("Товар с ID 21 удален из файла.");
            clientRepo.Delete(6);
            Console.WriteLine("Клиент с ID 6 удален из файла.");
            shopRepo.Delete(4);
            Console.WriteLine("Магазин с ID 4 удален из файла.");

            Console.WriteLine("\nИТОГОВЫЙ СПИСОК КЛИЕНТОВ ПОСЛЕ ОЧИСТКИ");
            List<ClientDao> finalClients = clientRepo.ReadAll();
            foreach (ClientDao c in finalClients)
            {
                string fullName = $"{c.LastName} {c.FirstName} {c.MiddleName}";
                Console.WriteLine($"{c.Id,-6}{fullName,-30}{c.BirthDate,-15:dd.MM.yyyy}{c.Age + " лет",-10}");
            }
            Console.ReadKey();
        }
    }
}
