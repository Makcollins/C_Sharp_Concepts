using System;

namespace Student;

public class PersonalInfo
{
    public string UserID { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? FatherName { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gen { get; set; }

    public PersonalInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gen)
    {
        Name = name;
        FatherName = fatherName;
        Phone = phone;
        Mail = mail;
        DOB = dob;
        Gen = gen;
    }
    
}
