using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePanel
{
    class TeamContainer
    {
        Dictionary<string, TeamEmployee> employees = new Dictionary<string, TeamEmployee>();

        public void AddTeam(string enteredName, int enteredLimit)
        {
            TeamEmployee team = new TeamEmployee(enteredName, enteredLimit);
            employees.Add(enteredName, team);
        }

        public void RemoveTeam(string enteredName)
        {
            if (employees.ContainsKey(enteredName))
            {
                employees.Remove(enteredName);
                Console.WriteLine("Team removed successfully.");
            }
            else
            {
                Console.WriteLine("Error. Team does not exist!");
            }
        }

        public IEnumerable<TeamEmployee> FindEmpty()
        {
            return employees.Values.Where(team => team.teams.Count == 0);
        }

        public void Summary()
        {
            foreach (TeamEmployee team in employees.Values)
            {
                int currentSize = team.teams.Count;
                int limit = team.TeamLimit;

                double percent = (double)currentSize / limit * 100;

                Console.WriteLine("Group: " + team.TeamName + ", Group filling: " + percent + " %");
            }
        }
    }
}
