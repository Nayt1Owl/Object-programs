using System;

namespace Proggs1._1
{
    public class GoodDao
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double Price { get; set; }
        public GoodDao() { }
        public GoodDao(int id, string name, string code, double price)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
        }
        public override string ToString() => $"{Id};{Name};{Code};{Price}";
        public static GoodDao FromString(string line)
        {
            string[] parts = line.Split(';');
            return new GoodDao(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]));
        }
    }
}
