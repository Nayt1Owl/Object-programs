using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;

namespace Shop.Dal
{
    public class BaseXmlRepository<T> : IRepository<T> where T : class, IPrimary, new()
    {
        protected string fileName;
        public BaseXmlRepository(string fileName)
        {
            this.fileName = fileName;
        }
        public virtual List<T> ReadAll()
        {
            if (!File.Exists(fileName)) return new List<T>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StreamReader reader = new StreamReader(fileName))
            {
                return (List<T>)serializer.Deserialize(reader);
            }
        }
        protected virtual void SaveAll(List<T> items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                serializer.Serialize(writer, items);
            }
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