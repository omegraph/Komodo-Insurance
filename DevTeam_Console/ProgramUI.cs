using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Console
{
    class ProgramUI
    {
        
        private readonly DevTeamRepository _teamRepo = new DevTeamRepository();
                
        public void Run()
        {
            SeeDevTeamList();
            while (ExecuteMenu())
            {
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private bool ExecuteMenu()
        {
            Console.WriteLine("Choose an option:\n" +
                "1. Create New Team\n" +
                "2. View All Teams\n" +
                "3. View Team Details\n" +
                "4. View Developers\n" +
                "5. Edit a Team\n" +
                "6. Delete a Team\n" +
                "7. Exit");

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    CreateNewDevTeam();
                    break;
                
                case "2":
                    DisplayAllTeams();
                    break;
                
                case "3":
                    DisplayTeamDetails();
                    break;
                
                case "4":
                    DisplayAllDevelopers();
                    break;
                
                case "5":
                    EditDevTeam();
                    break;
                
                case "6":
                    DeleteDevTeam();
                    break;
                
                case "7":
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            return true;
        }

        private void CreateNewDevTeam()
        {
            Console.WriteLine("Enter the team ID?");
            string teamIDAsString = Console.ReadLine();
            int teamID = int.Parse(teamIDAsString);

            Console.WriteLine("Enter the team name?");
            string teamName = Console.ReadLine();

            DevTeam newTeam = new DevTeam(teamID, teamName);

            Console.WriteLine($"Do you want to add a developer to {teamName}? (Y/N)");
            bool addDev = GetYesNoAnswer();

            while (addDev)
            {
                Console.Clear();
                Developer newDeveloper = CreateNewDev();
                newTeam.AddTeamMember(newDeveloper);

                Console.WriteLine("Add another Developer? (Y/N");
                addDev = GetYesNoAnswer();
            }

            _teamRepo.AddDevTeam(newTeam);
        }

        private Developer CreateNewDev()
        {
            Developer newDev = new Developer();

            Console.WriteLine("Enter the new developer's ID:");
            newDev.DeveloperID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new developer Last Name:");
            newDev.Name = Console.ReadLine();

            Console.WriteLine($"Does {newDev.Name} have access to a Pluralsight account? (Y/N");
            newDev.HasPluralsight = GetYesNoAnswer();

            return newDev;
        }

        private void DisplayAllTeams()
        {
            List<DevTeam> allTeams = _teamRepo.GetDevTeam();
            foreach (DevTeam team in allTeams)
            {
                Console.WriteLine($"Team {team.TeamID}: {team.TeamName} has {team.GetTeamMembers().Count} members");
            }

            Console.WriteLine();
        }

        private void DisplayTeamDetails()
        {
            DispalayAllTeams();

            Console.WriteLine("Enter the ID of the team want to see:");
            DevTeam team = GetTeamByID();

            Console.Clear();

            Console.WriteLine($"Team {team.TeamID}: {team.TeamName}\n");
            foreach (Developer developer in team.GetTeamMembers())
            {
                Console.WriteLine($"Developer {developer.DeveloperID}: {developer.Name}\n" +
                    $"Has Pluralsight: {developer.HasPluralsight}\n");
            }
        }

        private void DispalayAllTeams()
        {
            throw new NotImplementedException();
        }

        private DevTeam GetTeamByID()
        {
            string input = Console.ReadLine();

            int id = int.Parse(input);

            return _teamRepo.GetTeamByID(id);
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();
            Console.WriteLine("Developers in all teams:");

            List<DevTeam> devTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam team in devTeams)
            {
                foreach (Developer developer in team.GetTeamMembers())
                {
                    Console.WriteLine($"Developer {developer.DeveloperID}: {developer.Name}, " +
                        $"{(developer.HasPluralsight ? "has" : "does not have")} a Pluralsight account.");
                }
            }

            Console.WriteLine();
        }

        private void EditDevTeam()
        {
            Console.WriteLine("Enter the team ID you'd like to update:");
            DisplayAllTeams();

            DevTeam team = GetTeamByID();

            Console.Clear();

            Console.WriteLine($"Team {team.TeamID}: {team.TeamName}\n" +
                $"Would you like to update this team? (Y/N)");
            bool editing = GetYesNoAnswer();
            while (editing)
            {
            Console.WriteLine("What would you like to change on this team?\n" +
                "1. Team ID\n" +
                "2. Team Name\n" +
                "3. Team Roster\n" +
                "4. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    EditTeamID(team);
                    break;
                case "2":
                    EditTeamName(team);
                    break;
                case "3":
                    EditTeamRoster(team);
                    break;
                case "4":
                    return; 
            }

            Console.WriteLine($"Would you like to change anything else on {team.TeamName}? (Y/N)");
            editing = GetYesNoAnswer();
        }
    }

        private void EditTeamID(DevTeam team)
        {
            Console.WriteLine("Enter the new team ID:");
            team.TeamID = int.Parse(Console.ReadLine());
        }

        private void EditTeamName(DevTeam team)
        {
            Console.WriteLine("Enter the new team Name:");
            team.TeamName = (Console.ReadLine());
        }

        private void EditTeamRoster(DevTeam
            team)
        {
            Console.Clear();
            DisplayTeamRoster(team);
            while (true)
            {
                Console.WriteLine("1. Add Developer\n" +
                    "2. Remove Developer\n" +
                    "3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddDevToTeam(team);
                        break;
                    case "2":
                        RemoveDevFromTeam(team);
                        break;
                    case "3":
                        return;
                    default;
                        Console.WriteLine("Please enter valid input...");
                        break;
                }
            }
        }

        private void AddDevToTeam(DevTeam team)
        {
            Developer newDev = CreateNewDev();
            team.AddTeamMember(newDev);
        }

        private void RemoveDevFromTeam(DevTeam team)
        {
            DisplayTeamRoster(team);
            Console.WriteLine("Enter the developer ID you want to remove:");
            int id = int.Parse(Console.ReadLine());
            team.RemoveTeamMemberByID(id);
        }

        private void DisplayTeamRoster(DevTeam team)
        {
            throw new NotImplementedException();
        }

        private void DisplayTeamRoaster(DevTeam team)
        {
            foreach (Developer developer in team.GetTeamMembers())
            {
                Console.WriteLine($"Developer {developer.DeveloperID}: {developer.Name}, " +
                    $"{(developer.HasPluralsight ? "has" : "does not have")} a Pluralsight account.");
            }
        }

        private void DeleteDevTeam()
        {
            Console.Clear();

            Console.WriteLine("Which team would you Like to remove?");
            DisplayAllTeams();

            DevTeam team = GetTeamByID();
            _teamRepo.RemoveTeam(team);
        }

        
        private void DeleteDevTeamByID()
        {
            Console.WriteLine("Which team would you like to remove?");
            DisplayAllTeams();

            int id = int.Parse(Console.ReadLine());
            _teamRepo.RemoveTeamByID(id);
        }

        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }

        private void SeeDevTeamList()
        {
            DevTeam teamOne = new DevTeam(1, "Badgers");
            teamOne.AddTeamMember(new Developer { DeveloperID = 001, HasPluralsight = false, name = "Ali" });
            teamOne.AddTeamMember(new Developer { DeveloperID = 002, HasPluralsight = false, name = "Steve" });
            teamOne.AddTeamMember(new Developer { DeveloperID = 003, HasPluralsight = true, name = "Bob" });
            teamOne.AddTeamMember(new Developer { DeveloperID = 004, HasPluralsight = true, name = "Natalie" });
            teamOne.AddTeamMember(new Developer { DeveloperID = 005, HasPluralsight = true, name = "Lilia" });

            _teamRepo.AddDevTeam(teamOne);

            DevTeam teamTwo = new DevTeam(2, "Gold Team");
            teamTwo.AddTeamMember(new Developer { DeveloperID = 201, HasPluralsight = true, name = "Jack" });
            teamTwo.AddTeamMember(new Developer { DeveloperID = 202, HasPluralsight = false, name = "Bill" });
            teamTwo.AddTeamMember(new Developer { DeveloperID = 203, HasPluralsight = false, name = "Zidane" });

            _teamRepo.AddDevTeam(teamTwo);

            DevTeam teamThree = new DevTeam(3, "Badgers");
            teamThree.AddTeamMember(new Developer { DeveloperID = 301, HasPluralsight = false, name = "Fati" });
            teamThree.AddTeamMember(new Developer { DeveloperID = 302, HasPluralsight = false, name = "Lidya" });
            teamThree.AddTeamMember(new Developer { DeveloperID = 303, HasPluralsight = true, name = "Marcos" });
            teamThree.AddTeamMember(new Developer { DeveloperID = 304, HasPluralsight = true, name = "Eric" });

            _teamRepo.AddDevTeam(teamThree);
        }
    } 
}
