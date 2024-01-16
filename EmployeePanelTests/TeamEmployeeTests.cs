using EmployeePanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePanelTests
{
    [TestClass]
    public class TeamEmployeeTests
    {
        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            string name = "Developers";
            int limit = 7;

            // Act
            var team = new TeamEmployee(name, limit);

            // Assert
            Assert.AreEqual(name, team.TeamName);
            Assert.AreEqual(limit, team.TeamLimit);
        }

        [TestMethod]
        public void Constructor2_InitializesPropertiesCorrectly()
        {
            // Arrange
            string name = "Developers";
            int limit = 7;
            var teams = new List<Employee>();

            // Act
            var team = new TeamEmployee(teams, name, limit);

            // Assert
            Assert.AreEqual(teams, team.teams);
            Assert.AreEqual(name, team.TeamName);
            Assert.AreEqual(limit, team.TeamLimit);

        }

        [TestMethod]
        public void AddEmployee_AddsEmployeeToList()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);

            // Act
            team.AddEmployee(employee);

            // Assert
            Assert.IsTrue(team.teams.Contains(employee));
        }

        [TestMethod]
        public void AddSalary_AddsSalaryToEmployee()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var salary = 200.0;
            var expectedSalary = 5200.0;

            // Act
            team.AddEmployee(employee);
            team.AddSalary(employee, salary);

            // Assert
            Assert.AreEqual(expectedSalary, employee.Salary);
        }

        [TestMethod]
        public void RemoveEmployee_RemoveEmployeeCorrectly()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);

            // Act
            team.AddEmployee(employee);
            team.RemoveEmployee(employee);

            // Assert
            Assert.IsFalse(team.teams.Contains(employee));
        }

        [TestMethod]
        public void ChangeCondition_ChangeConditionCorrectly()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            EmployeeCondition expectedCondition = EmployeeCondition.DELEGATION;

            // Act
            team.AddEmployee(employee);
            team.ChangeCondition(employee, expectedCondition);

            // Assert
            Assert.AreEqual(expectedCondition, employee.Condition);
        }

        [TestMethod]
        public void Search_PrintsCorrectResultsToConsole()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            string searchedString = "Dzidkowiec";
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            // Act
            team.AddEmployee(employee);
            team.Search(searchedString);
            var result = consoleOut.ToString().Trim();

            // Assert
            StringAssert.Contains(result, "Karol Dzidkowiec");
            StringAssert.Contains(result, "Condition: PRESENT");
            StringAssert.Contains(result, "Birthday: 06.01.2002 00:00:00");
            StringAssert.Contains(result, "Salary: 5000 PLN");
        }

        [TestMethod]
        public void SearchPartial_ReturnsCorrectEmployees()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee1 = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 5, 10), 4500);
            var employee3 = new Employee("Leo", "Messi", EmployeeCondition.PRESENT, new DateTime(1987, 3, 15), 4800);
            var searchedPartialString = "a";
            team.AddEmployee(employee1);
            team.AddEmployee(employee2);
            team.AddEmployee(employee3);
            int expectedNumberOfEmployees = 2;

            // Act
            var result = team.SearchPartial(searchedPartialString).ToList();

            // Assert
            Assert.AreEqual(expectedNumberOfEmployees, result.Count);
            CollectionAssert.Contains(result, employee1);
            CollectionAssert.Contains(result, employee2);
            CollectionAssert.DoesNotContain(result, employee3);
        }

        [TestMethod]
        public void CountByCondition_ReturnsCorrectNumber()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee1 = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 5, 10), 4500);
            var employee3 = new Employee("Leo", "Messi", EmployeeCondition.PRESENT, new DateTime(1987, 3, 15), 4800);
            EmployeeCondition searchedCondition = EmployeeCondition.PRESENT;
            team.AddEmployee(employee1);
            team.AddEmployee(employee2);
            team.AddEmployee(employee3);
            int expectedNumberOfEmployees = 2;

            // Act
            var result = team.CountByCondition(searchedCondition);

            // Assert
            Assert.AreEqual(expectedNumberOfEmployees, result);
        }

        [TestMethod]
        public void Summary_PrintsCorrectResultsToConsole()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            // Act
            team.AddEmployee(employee);
            team.Summary();
            var result = consoleOut.ToString().Trim();

            // Assert
            StringAssert.Contains(result, "Karol Dzidkowiec");
            StringAssert.Contains(result, "Condition: PRESENT");
            StringAssert.Contains(result, "Birthday: 06.01.2002 00:00:00");
            StringAssert.Contains(result, "Salary: 5000 PLN");
        }

        [TestMethod]
        public void SortByName_SortsCorrectly()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee1 = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 5, 10), 4500);
            team.AddEmployee(employee1);
            team.AddEmployee(employee2);
            var expectedName1 = "Cristiano";
            var expectedName2 = "Karol";

            // Act
            var result = team.SortByName().ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(expectedName1, result[0].Name);
            Assert.AreEqual(expectedName2, result[1].Name);
        }

        [TestMethod]
        public void SortBySalary_SortsCorrectly()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee1 = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 5, 10), 5500);
            team.AddEmployee(employee1);
            team.AddEmployee(employee2);
            var expectedName1 = "Cristiano";
            var expectedName2 = "Karol";

            // Act
            var result = team.SortBySalary().ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(expectedName1, result[0].Name);
            Assert.AreEqual(expectedName2, result[1].Name);
        }

        [TestMethod]
        public void MaxSalaryInTeam_RetrunsCorrectly()
        {
            // Arrange
            var team = new TeamEmployee("Developers", 3);
            var employee1 = new Employee("Karol", "Dzidkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Cristiano", "Ronaldo", EmployeeCondition.ABSENT, new DateTime(1985, 5, 10), 5500);
            team.AddEmployee(employee1);
            team.AddEmployee(employee2);
            var expectedValue = 5500.0;

            // Act
            var result = team.MaxSalaryInTeam();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
