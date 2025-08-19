using System;

namespace Collaege;

public class Teacher : PersonalInfo
{
    public string TeacherID
    {
        get { return "T" + counter++; }
    }
    public string? Department { get; set; }
    public string? Subject { get; set; }
    public string? SubjectTeaching { get; set; }
    public string? Qualification { get; set; }
    public int YearOfExperience { get; set; }
    public DateTime DateOfJoining { get; set; }
    private static int counter = 1001;


    public Teacher(string name, string father, DateTime dob, string phone, Gender gen, string mail) : base(name, father, dob, phone, gen, mail)
    {
        UserID = TeacherID;
    }
}
