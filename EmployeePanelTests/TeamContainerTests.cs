using EmployeePanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePanelTests
{
    [TestClass]
    public class TeamContainerTests
    {
        [TestMethod]
        public void AddTeam_AddsCorrectly()
        {
            // Arrange
            var teamContainer = new TeamContainer();
            string enteredName = "Developers";
            int enteredLimit = 7;

            // Act
            teamContainer.AddTeam(enteredName, enteredLimit);

            // Assert
            Assert.IsTrue(teamContainer.employees.ContainsKey(enteredName));
        }

        [TestMethod]
        public void RemoveTeam_RemovesCorrectly()
        {
            // Arrange
            var teamContainer = new TeamContainer();
            string enteredName = "Developers";
            int enteredLimit = 7;

            // Act
            teamContainer.AddTeam(enteredName, enteredLimit);
            teamContainer.RemoveTeam(enteredName);

            // Assert
            Assert.IsFalse(teamContainer.employees.ContainsKey(enteredName));
        }

        [TestMethod]
        public void FindEmpty_FindsEmptyGroupsCorrectly()
        {
            // Arrange
            var teamContainer = new TeamContainer();

            // Act
            var emptyTeams = teamContainer.FindEmpty();

            // Assert
            Assert.AreEqual(0, emptyTeams.Count());
        }

        [TestMethod]
        public void Summary_PrintsCorrectResultsToConsole()
        {
            // Arrange
            var teamContainer = new TeamContainer();
            string enteredName = "Developers";
            int enteredLimit = 7;
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            // Act
            teamContainer.AddTeam(enteredName, enteredLimit);
            teamContainer.Summary();
            var result = consoleOut.ToString().Trim();

            // Assert
            StringAssert.Contains(result, "Group: Developers, Group filling: 0 %");
        }
    }
}