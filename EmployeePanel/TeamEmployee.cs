using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeePanel
{
    public class TeamEmployee
    {
        public string TeamName { get; set; }
        public int TeamLimit { get; set; }
        public List<Employee> teams = new List<Employee>();

        public TeamEmployee(string teamName, int teamLimit)
        {
            TeamName = teamName;
            TeamLimit = teamLimit;
        }

        public TeamEmployee(List<Employee> team, string teamName, int teamLimit)
        {
            teams = team;
            TeamName = teamName;
            TeamLimit = teamLimit;
        }

        public void AddEmployee(Employee employee)
        {
            if(teams.Contains(employee))
                Console.WriteLine("Employee already exists!");
            else { 
                if(teams.Count < TeamLimit)
                   teams.Add(employee); 
                else
                    Console.WriteLine("Error. Team is full!");
            }
        }

        public void AddSalary(Employee employee, double enteredSalary)
        {
            if (teams.Contains(employee))
                employee.Salary += enteredSalary;
            else
            {
                Console.WriteLine("Error adding salary.");
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            if (teams.Contains(employee))
                teams.Remove(employee);
            else
            {
                Console.WriteLine("Error removing employee.");
            }
        }

        public void ChangeCondition(Employee employee, EmployeeCondition enteredCondition)
        {
            if (teams.Contains(employee))
                employee.Condition = enteredCondition;
            else
            {
                Console.WriteLine("Error changing condition.");
            }
        }

        public void Search(string enteredString)
        {
            foreach (Employee employee in teams)
            {
                if (employee.Surname.CompareTo(enteredString) == 0)
                    employee.Print();
            }
        }

        public IEnumerable<Employee> SearchPartial(string enteredPartialString)
        {
            IEnumerable<Employee> newEmployees = teams.Where(e => e.Name.Contains(enteredPartialString) || e.Surname.Contains(enteredPartialString));
            return newEmployees;
        }

        public int CountByCondition(EmployeeCondition condition)
        {
            int counter = teams.Count(e => e.Condition == condition);
            return counter;
        }

        public void Summary()
        {
            foreach(Employee employee in teams)
            {
                Console.WriteLine("Employee: " + employee.Name + " " + employee.Surname + ", Condition: " + employee.Condition + ", Birthday: " + employee.Birthday + ", Salary: " + employee.Salary + " PLN");
            }
        }

        public IEnumerable<Employee> SortByName()
        {
            IEnumerable <Employee> newEmployees = teams.OrderBy(e => e.Name);
            return newEmployees;
        }

        public IEnumerable<Employee> SortBySalary()
        {
            IEnumerable<Employee> newEmployees = teams.OrderByDescending(e => e.Salary);
            return newEmployees;
        }

        public double MaxSalaryInTeam()
        {
            double maxSalary = teams.Max(e => e.Salary);
            return maxSalary;
        }
    }
}
