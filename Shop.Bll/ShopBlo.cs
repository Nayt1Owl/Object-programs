using System;
using Core;

namespace Shop.Bll
{
    public class ShopBlo : IPrimary
    {
        private string _code = string.Empty;
        private string _name = string.Empty;
        public int Id { get; protected set; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название магазина не может быть пустым.");
                }
                _name = value;
            }
        }
        public string Code
        {
            get => _code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Код магазина не может быть пустым.");
                }
                _code = value;
            }
        }
        public ShopBlo(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}