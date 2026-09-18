using System;

namespace ObjectProggs
{
    public class Client : IPrimary
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public Client() { }

        public Client(int id, string lastName, string firstName, string middleName, DateTime birthDate)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
        }
        public override string ToString()
        {
            return $"{Id};{LastName};{FirstName};{MiddleName};{BirthDate:yyyy-MM-dd}";
        }
        public static Client FromString(string line)
        {
            string[] parts = line.Split(';');
            return new Client(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3],
                DateTime.Parse(parts[4])
            );
        }
    }
}