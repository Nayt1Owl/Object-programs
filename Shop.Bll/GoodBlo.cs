using System;
using Core;

namespace Shop.Bll
{
    public class GoodBlo : IPrimary
    {
        public string code = string.Empty;
        public string name = string.Empty;
        public int Id { get; protected set; }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название товара не может быть пустым.");
                }
                name = value;
            }
        }
        public string Code
        {
            get => code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Код товара не может быть пустым.");
                }
                code = value;
            }
        }
        public double Price { get; set; }
        public GoodBlo(int id, string name, string code, double price)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
        }
    }
}