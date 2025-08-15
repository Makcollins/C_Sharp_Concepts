using System;

namespace StudentMarksheet;

public class PersonalInfo
{
    public string RegistrationNumber
    {
        get
        {
            counter++;
            return $"STU_{counter}";
        }
        set { }
    }
    public string? Name { get; set; }
    public string? FatherName { get; set; }
    public string? phone { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gen { get; set; }
    private static int counter = 1000;

}

