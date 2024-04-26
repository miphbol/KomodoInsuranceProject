using System.ComponentModel.Design;
using System.Runtime.Serialization;
using Developer.Repository;

namespace Komodo_Console;

public class ProgramUI
{
    private DeveloperRepository _developerRepo = new DeveloperRepository();
    private DevTeamRepository _devTeamRepo = new DevTeamRepository();

    // Method that run/starts the application

    public void Run()
    {
        SeedDeveloperList();
        SeedDevTeamList();
        Menu();
    }

    // Menu

    private void Menu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            System.Console.WriteLine("Select a menu option:\n" +
            "1. Create a Developer profile\n" +
            "2. View all Developers\n" +
            "3. Update existing Developers\n" +
            "4. Delete a Developer profile\n" +
            "5. Create a DevTeam\n" +
            "6. View all DevTeams\n" +
            "7. Update existing DevTeams\n" +
            "8. Delete a DevTeam\n" +
            "9. Add a Developer to a DevTeam\n" +
            "10. Remove a Developer from a DevTeam\n" +
            "11. Exit");

            // Get user input
            string input = System.Console.ReadLine();

            // Evaluate user input and make relative outputs
            switch (input)
            {
                case "1":
                    // Create new developer profile
                    CreateDev();
                    break;
                case "2":
                    // View all developer profiles
                    ViewAllDevs();
                    break;
                case "3":
                    // Update existing developer profiles
                    UpdateExistingDevs();
                    break;
                case "4":
                    // Delete a developer profile
                    DeleteDev();
                    break;
                case "5":
                    // Create new developer team
                    CreateDevTeam();
                    break;
                case "6":
                    // View all developer teams
                    ViewDevTeams();
                    break;
                case "7":
                    // Update existing developer teams
                    UpdateExistingTeams();
                    break;
                case "8":
                    // Delete existing developer team
                    DeleteDevTeam();
                    break;
                case "9":
                    // Add a developer to a team
                    AddDeveloperToTeam();
                    break;
                case "10":
                    // Remove a developer from a team
                    RemoveDeveloperFromTeam();
                    break;
                case "11":
                    // Exit
                    System.Console.WriteLine("Closing application...");
                    keepRunning = false;
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid number.");
                    break;
            }

            System.Console.WriteLine("Please press any key to continue...");
            System.Console.ReadKey();
            System.Console.Clear();

        }
    }
    


    // Create new Developer
    
    private void CreateDev()
    {
        System.Console.Clear();
        Developer.Repository.Developer newDev = CreateNewDeveloperObject();
        _developerRepo.AddDevToList(newDev);
    }

    // Create new DevTeam

    private void CreateDevTeam()
    {
        System.Console.Clear();
        DeveloperTeam newTeam = CreateNewTeamObject();
        _devTeamRepo.AddTeamToList(newTeam);
    }

    // View current Developer list
    private void ViewAllDevs()
    {
        System.Console.Clear();

        List<Developer.Repository.Developer> listOfDevelopers = _developerRepo.GetDevList();
        foreach (Developer.Repository.Developer dev in listOfDevelopers)
        {
            System.Console.WriteLine(
            $"Developer: {dev.DeveloperName}\n" +
            $"ID: {dev.DeveloperID}\n" +
            $"Access to PluralSight?: {dev.PluralSightAccess}");
        }
    }

    // View current Team List
        private void ViewDevTeams()
    {
        System.Console.Clear();

        List<DeveloperTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
        foreach (DeveloperTeam team in listOfDevTeams)
        {
            System.Console.WriteLine(
            $"DevTeam: {team.TeamName}\n" +
            $"Team ID: {team.TeamID}"
            );
        }
    }

    // Update Developer info
    private void UpdateExistingDevs()
    {
        ViewAllDevs();

        System.Console.WriteLine("Enter the name of the developer you wish to update:");

        string originalDev = System.Console.ReadLine();
        var oDev = _developerRepo.GetDevByName(originalDev);
        Developer.Repository.Developer newDev = CreateNewDeveloperObject();

        bool wasUpdated = _developerRepo.UpdateExistingDevs(oDev.DeveloperName, oDev.DeveloperID, oDev.PluralSightAccess, newDev);

        if (wasUpdated)
        {
            System.Console.WriteLine("Developer successfully updated.");
        }
        else
        {
            System.Console.WriteLine("Could not update");
        }
    }

    private static Developer.Repository.Developer CreateNewDeveloperObject()
    {
        Developer.Repository.Developer newDev = new Developer.Repository.Developer();

        System.Console.WriteLine("Enter a new name for the developer:");
        newDev.DeveloperName = System.Console.ReadLine();

        System.Console.WriteLine("Enter a new ID for the developer:");
        string assignedID = System.Console.ReadLine();
        newDev.DeveloperID = int.Parse(assignedID);

        System.Console.WriteLine("Does the developer have PluralSight access?");
        string pluralSightString = System.Console.ReadLine().ToLower();

        if (pluralSightString == "y")
        {
            newDev.PluralSightAccess = true;
        }
        else
        {
            newDev.PluralSightAccess = false;
        }
        return newDev;
    }



    // Update Team info

        private void UpdateExistingTeams()
    {
        ViewDevTeams();

        System.Console.WriteLine("Enter the name of the team you wish to update:");

        string originalTeam = System.Console.ReadLine();
        var oDevTeam = _devTeamRepo.GetTeamByName(originalTeam);
        DeveloperTeam newTeam = CreateNewTeamObject();

        bool wasUpdated = _devTeamRepo.UpdateExistingTeams(oDevTeam.TeamName, oDevTeam.TeamID, newTeam);

        if (wasUpdated)
        {
            System.Console.WriteLine("Team successfully updated.");
        }
        else
        {
            System.Console.WriteLine("Could not update");
        }
    }

        private static DeveloperTeam CreateNewTeamObject()
    {
        DeveloperTeam newTeam = new DeveloperTeam();

        System.Console.WriteLine("Enter a new name for the team:");
        newTeam.TeamName = System.Console.ReadLine();

        System.Console.WriteLine("Enter a new ID for the team:");
        string assignedTeamID = System.Console.ReadLine();
        newTeam.TeamID = int.Parse(assignedTeamID);

        return newTeam;
    }


    // Delete a developer from the list

    private void DeleteDev()
    {
        System.Console.Clear();

        ViewAllDevs();

        System.Console.WriteLine("\nEnter the name of the Developer you would like to remove:");
        string input = System.Console.ReadLine();

        bool wasDeleted = _developerRepo.RemoveDev(input);

        if (wasDeleted)
        {
            System.Console.WriteLine("The Developer was succesfully removed.");
        }
        else
        {
            System.Console.WriteLine("The Developer could not be removed.");
        }
    }

    // Delete a team from the list

        private void DeleteDevTeam()
    {
        System.Console.Clear();

        ViewDevTeams();

        System.Console.WriteLine("\nEnter the name of the team you would like to remove:");
        string input = System.Console.ReadLine();

        bool wasDeleted = _devTeamRepo.RemoveTeam(input);

        if (wasDeleted)
        {
            System.Console.WriteLine("The team was succesfully removed.");
        }
        else
        {
            System.Console.WriteLine("The team could not be removed.");
        }
    }

    // Add a developer to a team

    private void AddDeveloperToTeam()
    {
        
        System.Console.Clear();

        ViewDevTeams();

        System.Console.WriteLine("Please enter the ID of the Team the Developer will be added to.");

        string developerTeamID = System.Console.ReadLine();
        // int.Parse(developerTeamID);
        
        ViewAllDevs();

        System.Console.WriteLine("Please enter the ID of the Developer you wish to add to a Team.");

        string developerID = System.Console.ReadLine();
        // int.Parse(developerID);
        _devTeamRepo.AddDevToTeam(int.Parse(developerTeamID) ,int.Parse(developerID));
        // DeveloperTeam devTeam = CreateAssignedDevObject();

    }




    // Remove a developer from a team
    private void RemoveDeveloperFromTeam()
    {
        System.Console.Clear();

        ViewDevTeams();

        System.Console.WriteLine("Please enter the ID of the Team the Developer will be removed from.");

        int developerTeamID = int.Parse(System.Console.ReadLine());
        var teamToDisplay = _devTeamRepo.GetTeamByID(developerTeamID);

        foreach (int i in teamToDisplay.teamMemberIDs)
        {
            System.Console.WriteLine(i);
        }
        
        System.Console.WriteLine("Please enter the ID of the Developer to be removed.");

        int developerID = int.Parse(System.Console.ReadLine());
        _devTeamRepo.RemoveDevFromTeam(developerTeamID, developerID);
    }


    // Seed info

    private void SeedDeveloperList()
    {
        Developer.Repository.Developer chandler = new Developer.Repository.Developer("Chandler", 5473, true);
        Developer.Repository.Developer sergio = new Developer.Repository.Developer("Sergio", 1337, false);
        Developer.Repository.Developer brad = new Developer.Repository.Developer("Brad", 0117, true);

        _developerRepo.AddDevToList(chandler);
        _developerRepo.AddDevToList(sergio);
        _developerRepo.AddDevToList(brad);
    }

    private void SeedDevTeamList()
    {
        DeveloperTeam alpha = new DeveloperTeam("Team Alpha", 1001);
        DeveloperTeam bravo = new DeveloperTeam("Team Bravo", 1002);
        DeveloperTeam charlie = new DeveloperTeam("Team Charlie", 1003);

        _devTeamRepo.AddTeamToList(alpha);
        _devTeamRepo.AddTeamToList(bravo);
        _devTeamRepo.AddTeamToList(charlie);
    }
}