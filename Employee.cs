using System;

namespace MojProgram
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Position Position { get; set; }
        
        private decimal _salary; 

        public decimal Salary 
        {
            get 
            { 
                return _salary; 
            }
            set 
            { 
                if (Position == Position.Intern && value > 10000)
                {
                    throw new ArgumentException("Stażysta nie może zarabiać więcej niż 10 000 zł!");
                }
                if (value >= 0) 
                {
                    _salary = value; 
                }
                else
                {  
                    throw new ArgumentException("Pensja nie może być ujemna!"); 
                }
            }
        }

        public Employee(int id, string firstName, string lastName, DateTime birthDate, Position position, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Position = position;
            Salary = salary; 
        }

        public int Age 
        {
            get 
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year; 
                
                if (today.Month < BirthDate.Month || (today.Month == BirthDate.Month && today.Day < BirthDate.Day))
                {
                    age--; 
                }
                
                return age;
            }
        }

        public override string ToString()
        {
            return $"Imie: {FirstName} \nNazwisko: {LastName} \nWiek: {Age} \nPensja: {Salary} zł \nStanowisko: {Position}";
        }
    }
}