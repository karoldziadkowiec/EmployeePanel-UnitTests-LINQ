using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePanel
{
    class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeCondition Condition { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }

        public Employee (string name, string surname, EmployeeCondition condition, DateTime birthday, double salary)
        {
            Name = name;
            Surname = surname;
            Condition = condition;
            Birthday = birthday;
            Salary = salary;
        }

        public void Print()
        {
            Console.WriteLine("Employee: " + Name + " " + Surname);
            Console.WriteLine("Condition: " + Condition + ", Birthday: " + Birthday + ", Salary: " + Salary + " PLN");
        }
        public int CompareTo(Employee? other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Employee employee1, Employee employee2)
        {
            return employee1.Surname.CompareTo(employee2.Surname);
        }
    }
}
