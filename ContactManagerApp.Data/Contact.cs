using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApp.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        public Contact() { }
        public Contact(string name, DateTime date, bool married, string phone, decimal salary)
        {
            Name = name;
            DateOfBirth = date;
            Married = married;
            Phone = phone;
            Salary = salary;
        }
    }
}
