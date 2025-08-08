using System;

namespace Collaege;

public class PrincipalInfo : PersonalInfo
{
    public string PrincipalID
    {
        get
        {
            string gid = "P" + counter;
            counter++;
            return gid;
        }
        set
        {
            PrincipalID = value;
        }
    }
    public string? Qualification { get; set; }
    public int YearOfExperience { get; set; }
    public DateTime DateOfJoining { get; set; }

     private static int counter = 3001;
    

    public PrincipalInfo(string name, string father, DateTime dob, string phone, Gender gen, string mail) : base(name, father, dob, phone, gen, mail)
    {
        UserID = PrincipalID;
    }
}
