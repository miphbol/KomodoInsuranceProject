namespace Developer.Repository;

public class DeveloperTeam
{
    public string TeamName { get; set; }
    public int TeamID { get; set; }

    public List<int> teamMemberIDs { get; set;} = new List<int>();

public DeveloperTeam(){}

public DeveloperTeam(string teamname, int teamid)
    {
        TeamName = teamname;
        TeamID = teamid;
        
    }
}



