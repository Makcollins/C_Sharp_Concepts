using System;

namespace Cafeteria;

public class PersonalDetails
{
    public string? Name { get; set; }
    public string? FatherName { get; set; }
    public Gender Gender { get; set; }
    public string? Mobile { get; set; }
    public string? MailID { get; set; }

}
public enum Gender { Male, Female, Transgender}

