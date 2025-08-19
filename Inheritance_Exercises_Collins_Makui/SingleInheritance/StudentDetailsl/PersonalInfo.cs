using System;

namespace StudentDetailsl;

public class PersonalInfo
{
    public string? Name { get; set; }
    public string UserID { get { return $"USR{counter++}"; } }
    public string? FatherName { get; set; }
    public string? Phone { get; set; }
    public string? MailID { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
    private static int counter = 1001;

    public virtual void Display()
    {
        Console.WriteLine($"USER ID: {UserID}\nName: {Name}\nFatherName: {FatherName}\nPhone: {Phone}\nMailID: {MailID}\nDOB: {DOB.ToShortDateString()}\nGender: {Gender}\n");
    }
    

}
public enum Gender { Male, Female }

public class StudentInfo : PersonalInfo
{
    public string? RegistrationID { get { return $"STU{counter++}"; } }
    public string? Standard { get; set; }
    public string? Branch { get; set; }
    public string? AcademicYear { get; set; }
    static int counter=2001;

    public override void Display()
    {
        Console.WriteLine($"USER ID: {UserID}\nName: {Name}\nFatherName: {FatherName}\nPhone: {Phone}\nMailID: {MailID}\nDOB: {DOB.ToShortDateString()}\nGender: {Gender}");
        Console.WriteLine($"Registration: {RegistrationID}\nStarndard: {Standard} {Branch}\nAcademic year: {AcademicYear}\n");
    }
}