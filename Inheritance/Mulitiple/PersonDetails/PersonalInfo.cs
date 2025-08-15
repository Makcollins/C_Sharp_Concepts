using System;

namespace PersonDetails;

public class PersonalInfo
{
    public string UserID
    {
        get { return "USER" + counter++; }
        set { }
    }
    public string? Name { get; set; }
    public Gender Gen { get; set; }
    public DateTime DOB { get; set; }
    public string? Phone { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    private static int counter = 1000;

}

public enum MaritalStatus
{
    Married, Single
}
public enum Gender
{
    Male,Female
}