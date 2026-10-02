using System;
using System.Collections.Generic;

namespace Proggs1._1
{
    public class GoodDaoFileRepository : BaseFileRepository, IRepository<GoodDao>
    {
        public GoodDaoFileRepository(string fileName = "goods.txt") : base(fileName) { }
        public void Create(GoodDao entity)
        {
            List<GoodDao> goods = ReadAll();
            goods.Add(entity);
            SaveAll(goods);
        }
        public GoodDao Read(int id)
        {
            List<GoodDao> goods = ReadAll();
            foreach (GoodDao good in goods)
            {
                if (good.Id == id)
                {
                    return good;
                }
            }
            return null;
        }
        public List<GoodDao> ReadAll()
        {
            List<string> lines = ReadAllLinesFromFile();
            List<GoodDao> goods = new List<GoodDao>();
            foreach (string line in lines)
            {
                goods.Add(GoodDao.FromString(line));
            }
            return goods;
        }
        public void Update(GoodDao entity)
        {
            List<GoodDao> goods = ReadAll();
            for (int i = 0; i < goods.Count; i++)
            {
                if (goods[i].Id == entity.Id)
                {
                    goods[i] = entity;
                    break;
                }
            }
            SaveAll(goods);
        }
        public void Delete(int id)
        {
            List<GoodDao> goods = ReadAll();
            for (int i = 0; i < goods.Count; i++)
            {
                if (goods[i].Id == id)
                {
                    goods.RemoveAt(i);
                    break;
                }
            }
            SaveAll(goods);
        }
        private void SaveAll(List<GoodDao> goods)
        {
            List<string> lines = new List<string>();
            foreach (GoodDao good in goods)
            {
                lines.Add(good.ToString());
            }
            WriteAllLinesToFile(lines);
        }
    }
}