using System;

namespace Proggs1._1
{
    public class ShopDao
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ShopDao() { }
        public ShopDao(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
        public override string ToString() => $"{Id};{Name};{Code}";
        public static ShopDao FromString(string line)
        {
            string[] parts = line.Split(';');
            return new ShopDao(int.Parse(parts[0]), parts[1], parts[2]);
        }
    }
}