using System;

namespace ObjectProggs
{
    public class Shop : IPrimary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public Shop() { }

        public Shop(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
        public override string ToString()
        {
            return $"{Id};{Name};{Code}";
        }
        public static Shop FromString(string line)
        {
            string[] parts = line.Split(';');
            return new Shop(
                int.Parse(parts[0]),
                parts[1],
                parts[2]
            );
        }
    }
}