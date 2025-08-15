using System;

namespace Collaege;

public class PersonalInfo
{
    public string UserID { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? FatherName { get; set; }
    public DateTime DOB { get; set; }
    public string? Phone { get; set; }
    public Gender Gen { get; set; }
    public string? MailID { get; set; }

    public PersonalInfo(string name, string father, DateTime dob, string phone, Gender gen, string mail)
    {
        Name = name;
        FatherName = father;
        DOB = dob;
        Phone = phone;
        Gen = gen;
        MailID = mail;
    }

  

}
public enum Gender
{
    Male,Female
}
