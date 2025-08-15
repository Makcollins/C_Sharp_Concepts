using System;

namespace Student;

public class StudentInfo : PersonalInfo
{
     public string RegistrationID
    {
        get
        {
            string gid = "STU" + counter;
            counter++;
            return gid;
        }
        set
        {
            RegistrationID = value;
        }
    }
    public string? Standard { get; set; }
    public string? Branch { get; set; }
    public string? AcademicYear { get; set; }
    private static int counter = 1001;

    public StudentInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gen) : base(name, fatherName, phone, mail, dob, gen)
    {
        UserID = RegistrationID;
    }
}
