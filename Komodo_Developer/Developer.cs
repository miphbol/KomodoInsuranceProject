namespace Developer.Repository;

public class Developer
{
    public string DeveloperName { get; set; }
    public int DeveloperID { get; set; }
    public bool PluralSightAccess  { get; set; }

    public Developer() {}

    public Developer(string developername, int developerid, bool pluralsightaccess)
    {
        DeveloperName = developername;
        DeveloperID = developerid;
        PluralSightAccess = pluralsightaccess;
    }
}
