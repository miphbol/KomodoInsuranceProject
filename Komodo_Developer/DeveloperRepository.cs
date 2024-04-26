
namespace Developer.Repository;

public class DeveloperRepository
{
    private List<Developer> _devList = new List<Developer>();


// Create

    public void AddDevToList(Developer dev)
    {
        _devList.Add(dev);
    }



// Read

    public List<Developer> GetDevList()
    {
        return new List<Developer>(_devList);
    }


// Update

public bool UpdateExistingDevs(string originalName, int originalID, bool originalAccess, Developer newDev)
    {
        Developer oldDev = GetDevByName(originalName);

        if (oldDev != null)
        {
            oldDev.DeveloperName = newDev.DeveloperName;
            oldDev.DeveloperID = newDev.DeveloperID;
            oldDev.PluralSightAccess = newDev.PluralSightAccess;

            return true;
        }
        else
        {
            return false;
        }
    }

// Delete

public bool RemoveDev(string developername)
    {
        Developer dev = GetDevByName(developername);

        if (dev == null)
        {
            return false;
        }

        int initialCount = _devList.Count;
        _devList.Remove(dev);

        if (initialCount > _devList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

// Helper method


public Developer GetDevByName(string developername)
    {
        foreach (Developer dev in _devList)
        {
            if (dev.DeveloperName.ToLower() == developername.ToLower())
            {
                return dev;
            }
        }

        return null;
    }

}

