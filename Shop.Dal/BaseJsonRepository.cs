using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Core;

namespace Shop.Dal
{
    public class BaseJsonRepository<T> : IRepository<T> where T : class, IPrimary, new()
    {
        protected string fileName;

        public BaseJsonRepository(string fileName)
        {
            this.fileName = fileName;
        }
        public virtual List<T> ReadAll()
        {
            if (!File.Exists(fileName)) return new List<T>();

            string json = File.ReadAllText(fileName);
            if (string.IsNullOrWhiteSpace(json)) return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        protected virtual void SaveAll(List<T> items)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(fileName, json);
        }
        public virtual void Create(T item)
        {
            List<T> items = ReadAll();
            items.Add(item);
            SaveAll(items);
        }
        public virtual T Read(int id)
        {
            List<T> items = ReadAll();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id) return items[i];
            }
            return null;
        }
        public virtual void Update(T item)
        {
            List<T> items = ReadAll();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    break;
                }
            }
            SaveAll(items);
        }
        public virtual void Delete(int id)
        {
            List<T> items = ReadAll();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
            SaveAll(items);
        }
    }
}