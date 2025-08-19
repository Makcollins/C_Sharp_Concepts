using System;

namespace Collaege;

public class StudentInfo : PersonalInfo
{
    public string StudentID
    {
        get { return "ST" + counter++; }
    }
    public string? Degree { get; set; }
    public string? Department { get; set; }
    public string? Semester { get; set; }
    private static int counter = 2001;

    public StudentInfo(string name, string father, DateTime dob, string phone, Gender gen, string mail) : base(name, father, dob, phone, gen, mail)
    {
        UserID = StudentID;
    }
}
