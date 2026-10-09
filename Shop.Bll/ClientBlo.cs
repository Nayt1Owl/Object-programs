using System;
using Core;

namespace Shop.Bll
{
    public class ClientBlo : IPrimary
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        public int Id { get; protected set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя клиента не может быть пустым.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Фамилия клиента не может быть пустой.");
                }
                lastName = value;
            }
        }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public ClientBlo(int id, string lastName, string firstName, string middleName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Birthday = new DateTime(1900, 1, 1);
        }
        public ClientBlo(int id, string lastName, string firstName, string middleName, DateTime birthday) : this(id, lastName, firstName, middleName)
        {
            Birthday = birthday;
        }
    }
}