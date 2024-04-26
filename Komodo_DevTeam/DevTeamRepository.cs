namespace Developer.Repository;

public class DevTeamRepository
{
    private List<DeveloperTeam> _listOfTeams = new List<DeveloperTeam>();

    //Create

    public void AddTeamToList(DeveloperTeam team)
    {
        _listOfTeams.Add(team);
    }

    public void AddDevToTeam(int devTeamID, int devID )
    {
        foreach (DeveloperTeam devTeam in _listOfTeams)
        {
            if (devTeam.TeamID == devTeamID)
            {
                devTeam.teamMemberIDs.Add(devID);
            }
        }
    }

    //Read

    public List<DeveloperTeam> GetDevTeamList()
    {
        return new List<DeveloperTeam>(_listOfTeams);
    }




    //Update
    
    public bool UpdateExistingTeams(string originalTeamName, int orignalTeamID, DeveloperTeam newTeam)
    {
        DeveloperTeam oldTeam = GetTeamByName(originalTeamName);

        if (oldTeam != null)
        {
            oldTeam.TeamName = newTeam.TeamName;
            oldTeam.TeamID = newTeam.TeamID;

            return true;
        }
        else
        {
            return false;
        }
    }



    //Delete

    public bool RemoveTeam(string teamname)
    {
        DeveloperTeam team = GetTeamByName(teamname);

        if (team == null)
        {
            return false;
        }

        int initialCount = _listOfTeams.Count;
        _listOfTeams.Remove(team);

        if (initialCount > _listOfTeams.Count)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void RemoveDevFromTeam(int devTeamID, int devID)
    {
        foreach (DeveloperTeam devTeam in _listOfTeams)
        {
            if (devTeam.TeamID == devTeamID)
            {
                devTeam.teamMemberIDs.Remove(devID);
            }
        }
    }




    //Helper method

    public DeveloperTeam GetTeamByName(string teamname)
    {
        foreach (DeveloperTeam team in _listOfTeams)
        {
            if (team.TeamName.ToLower() == teamname.ToLower())
            {
                return team;
            }
        }

        return null;
    }

        public DeveloperTeam GetTeamByID(int teamid)
    {
        foreach (DeveloperTeam team in _listOfTeams)
        {
            if (team.TeamID == teamid)
            {
                return team;
            }
        }

        return null;
    }
}







