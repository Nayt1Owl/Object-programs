using System;
using System.Collections.Generic;

namespace Proggs1._1
{
    public class ShopDaoFileRepository : BaseFileRepository, IRepository<ShopDao>
    {
        public ShopDaoFileRepository(string fileName = "shops.txt") : base(fileName) { }
        public void Create(ShopDao entity)
        {
            List<ShopDao> shops = ReadAll();
            shops.Add(entity);
            SaveAll(shops);
        }
        public ShopDao Read(int id)
        {
            List<ShopDao> shops = ReadAll();
            foreach (ShopDao shop in shops)
            {
                if (shop.Id == id)
                {
                    return shop;
                }
            }
            return null;
        }
        public List<ShopDao> ReadAll()
        {
            List<string> lines = ReadAllLinesFromFile();
            List<ShopDao> shops = new List<ShopDao>();

            foreach (string line in lines)
            {
                shops.Add(ShopDao.FromString(line));
            }
            return shops;
        }
        public void Update(ShopDao entity)
        {
            List<ShopDao> shops = ReadAll();
            for (int i = 0; i < shops.Count; i++)
            {
                if (shops[i].Id == entity.Id)
                {
                    shops[i] = entity;
                    break;
                }
            }
            SaveAll(shops);
        }
        public void Delete(int id)
        {
            List<ShopDao> shops = ReadAll();
            for (int i = 0; i < shops.Count; i++)
            {
                if (shops[i].Id == id)
                {
                    shops.RemoveAt(i);
                    break;
                }
            }
            SaveAll(shops);
        }
        private void SaveAll(List<ShopDao> shops)
        {
            List<string> lines = new List<string>();
            foreach (ShopDao shop in shops)
            {
                lines.Add(shop.ToString());
            }
            WriteAllLinesToFile(lines);
        }
    }
}