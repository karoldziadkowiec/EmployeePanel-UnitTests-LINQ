namespace EmployeePanel
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("E M P L O Y E E   P A N E L");

            Employee employee1 = new Employee("Karol", "Dziadkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 4500);
            Employee employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 2, 26), 4200);
            Employee employee3 = new Employee("Leo", "Messi", EmployeeCondition.DELEGATION, new DateTime(1987, 3, 16), 3900);
            Employee employee4 = new Employee("Robert", "Lewandowski", EmployeeCondition.PRESENT, new DateTime(1988, 6, 2), 4150);

            List<Employee> employees = new List<Employee>();
            TeamEmployee teamEmployee = new TeamEmployee(employees, ".NET Developers", 7);

            Console.WriteLine("\n\t/adding new employees/");
            teamEmployee.AddEmployee(employee1);
            teamEmployee.AddEmployee(employee2);
            teamEmployee.AddEmployee(employee3);
            teamEmployee.AddEmployee(employee4);
            teamEmployee.Summary();

            Console.WriteLine("\n\t/adding to salary for employee Karol Dziadkowiec/");
            employee1.Print();
            teamEmployee.AddSalary(employee1, 500);
            employee1.Print();

            Console.WriteLine("\n\t/removing employee/");
            teamEmployee.RemoveEmployee(employee4);
            teamEmployee.Summary();

            Console.WriteLine("\n\t/changing employee condition/");
            employee2.Print();
            teamEmployee.ChangeCondition(employee2, EmployeeCondition.DELEGATION);
            employee2.Print();

            Console.WriteLine("\n\t/searching for a employee/");
            string teacherSurname = "Dziadkowiec";
            teamEmployee.Search(teacherSurname);

            Console.WriteLine("\n\t/searching for a employee by partial string \"a\"/");
            string partialString = "a";
            IEnumerable<Employee> matchingEmployees = teamEmployee.SearchPartial(partialString);
            foreach (Employee employee in matchingEmployees)
            {
                employee.Print();
            }

            Console.WriteLine("\n\t/counting by condition/");
            int conditionCounter = teamEmployee.CountByCondition(EmployeeCondition.DELEGATION);
            Console.WriteLine("Counted DELEGATION condition = " + conditionCounter);

            Console.WriteLine("\n\t/testing summary method/");
            teamEmployee.Summary();

            Console.WriteLine("\n\t/sorting alphabetically by name/");
            IEnumerable<Employee> newTeamEmployee = teamEmployee.SortByName();
            foreach (Employee employee in newTeamEmployee)
            {
                employee.Print();
            }

            Console.WriteLine("\n\t/sorting by salary in descending order/");
            IEnumerable<Employee> newTeamEmployee2 = teamEmployee.SortBySalary();
            foreach (Employee employee in newTeamEmployee2)
            {
                employee.Print();
            }

            Console.WriteLine("\n\t/max salary in a team/");
            double maxSalaryInTeam = teamEmployee.MaxSalaryInTeam();
            Console.WriteLine("Max salary in a team: " + maxSalaryInTeam);

            Console.WriteLine("\n\t/adding new employee team/");
            TeamContainer teamContainer = new TeamContainer();
            teamContainer.AddTeam("Java Developers", 4);
            teamContainer.Summary();

            Console.WriteLine("\n\t/removing employee team/");
            teamContainer.AddTeam("SCRUM Team", 2);
            teamContainer.Summary();
            string teamToRemove = "SCRUM Team";
            teamContainer.RemoveTeam(teamToRemove);
            teamContainer.Summary();

            Console.WriteLine("\n\t/finding empty teams/");
            IEnumerable<TeamEmployee> emptyTeams = teamContainer.FindEmpty();
            foreach (TeamEmployee emptyTeamTeacher in emptyTeams)
            {
                Console.WriteLine(emptyTeamTeacher.TeamName + ", team limit: " + emptyTeamTeacher.TeamName);
            }

            Console.WriteLine("\n\t/testing summary method/");
            teamContainer.Summary();
        }
    }
}