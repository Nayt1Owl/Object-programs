using System;

namespace ObjectProggs
{
    public class Good : IPrimary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double Price { get; set; }

        public Good() { }

        public Good(int id, string name, string code, double price)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Id};{Name};{Code};{Price}";
        }
        public static Good FromString(string line)
        {
            string[] parts = line.Split(';');
            return new Good(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]));
        }
    }
}