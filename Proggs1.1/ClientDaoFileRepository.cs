using System;
using System.Collections.Generic;

namespace Proggs1._1
{
    public class ClientDaoFileRepository : BaseFileRepository, IRepository<ClientDao>
    {
        public ClientDaoFileRepository(string fileName = "clients.txt") : base(fileName) { }

        public void Create(ClientDao entity)
        {
            List<ClientDao> clients = ReadAll();
            clients.Add(entity);
            SaveAll(clients);
        }
        public ClientDao Read(int id)
        {
            List<ClientDao> clients = ReadAll();
            foreach (ClientDao client in clients)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            return null;
        }
        public List<ClientDao> ReadAll()
        {
            List<string> lines = ReadAllLinesFromFile();
            List<ClientDao> clients = new List<ClientDao>();
            foreach (string line in lines)
            {
                clients.Add(ClientDao.FromString(line));
            }
            return clients;
        }
        public void Update(ClientDao entity)
        {
            List<ClientDao> clients = ReadAll();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == entity.Id)
                {
                    clients[i] = entity;
                    break;
                }
            }
            SaveAll(clients);
        }
        public void Delete(int id)
        {
            List<ClientDao> clients = ReadAll();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == id)
                {
                    clients.RemoveAt(i);
                    break;
                }
            }
            SaveAll(clients);
        }
        private void SaveAll(List<ClientDao> clients)
        {
            List<string> lines = new List<string>();
            foreach (ClientDao client in clients)
            {
                lines.Add(client.ToString());
            }
            WriteAllLinesToFile(lines);
        }
    }
}
