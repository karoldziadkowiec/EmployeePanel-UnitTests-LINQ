using EmployeePanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePanelTests
{
    [TestClass]
    public class EmployeeModelTests
    {
        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            string name = "Karol";
            string surname = "Dziadkowiec";
            EmployeeCondition condition = EmployeeCondition.PRESENT;
            DateTime birthday = new DateTime(2002, 1, 6);
            double salary = 5000;

            // Act
            var employee = new Employee(name, surname, condition, birthday, salary);

            // Assert
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(surname, employee.Surname);
            Assert.AreEqual(condition, employee.Condition);
            Assert.AreEqual(birthday, employee.Birthday);
            Assert.AreEqual(salary, employee.Salary);
        }

        [TestMethod]
        public void Constructor_InitializesDefaultValues()
        {
            // Arrange
            var employee = new Employee();

            // Assert
            Assert.IsNull(employee.Name);
            Assert.IsNull(employee.Surname);
            Assert.AreEqual(EmployeeCondition.PRESENT, employee.Condition);
            Assert.AreEqual(default(DateTime), employee.Birthday);
            Assert.AreEqual(0, employee.Salary);
        }

        [TestMethod]
        public void CompareTo_ReturnsCorrectResultForSameNames()
        {
            // Arrange
            var employee1 = new Employee("Karol", "Dziadkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Karol", "Dziadkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            int expectedResult = 0;

            // Act
            var result = employee1.CompareTo(employee1, employee2);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CompareTo_ReturnsCorrectResultForDifferentNamesLess0()
        {
            // Arrange
            var employee1 = new Employee("James", "Bond", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Karol", "Dziadkowiec", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            int expectedResult = -1;

            // Act
            var result = employee1.CompareTo(employee1, employee2);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CompareTo_ReturnsCorrectResultForDifferentNamesGreater0()
        {
            // Arrange
            var employee1 = new Employee("James", "Bond", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            var employee2 = new Employee("Aaron", "Arnold", EmployeeCondition.PRESENT, new DateTime(2002, 1, 6), 5000);
            int expectedResult = 1;

            // Act
            var result = employee1.CompareTo(employee1, employee2);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
