using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePanel;

namespace EmployeePanelTests
{
    [TestClass]
    public class EmployeeConditionTests
    {
        [TestMethod]
        public void Enum_Contains_Present()
        {
            // Arrange
            var enumValues = Enum.GetValues(typeof(EmployeeCondition));

            // Assert
            CollectionAssert.Contains(enumValues, EmployeeCondition.PRESENT);
        }

        [TestMethod]
        public void Enum_Contains_Delegation()
        {
            // Arrange
            var enumValues = Enum.GetValues(typeof(EmployeeCondition));

            // Assert
            CollectionAssert.Contains(enumValues, EmployeeCondition.DELEGATION);
        }

        [TestMethod]
        public void Enum_Contains_Sick()
        {
            // Arrange
            var enumValues = Enum.GetValues(typeof(EmployeeCondition));

            // Assert
            CollectionAssert.Contains(enumValues, EmployeeCondition.SICK);
        }

        [TestMethod]
        public void Enum_Contains_Absent()
        {
            // Arrange
            var enumValues = Enum.GetValues(typeof(EmployeeCondition));

            // Assert
            CollectionAssert.Contains(enumValues, EmployeeCondition.ABSENT);
        }
    }
}
