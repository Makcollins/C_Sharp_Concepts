using System;

namespace PersonDetails;

public class RegisterPerson : PersonalInfo, IFamilyInfo
{
    public string RegistrationID
    {
        get { return "PN" + counter++; }
        set { }
    }
    public DateTime DateofRegistration { get; set; }

    private static int counter = 1000;

    public void Display()
    {
        Console.WriteLine($"UserID: {UserID}\nName: {Name}\nGender: {Gen}\nDOB: {DOB.ToShortDateString()}\nPhone: {Phone}\nMarital Details: {MaritalStatus}\n");
        Console.WriteLine($"FatherName: {FatherName}\nMotherName: {MotherName}\nHouseAddress: {HouseAdress}\nNo.of.Siblings: {NoOfSiblings}");
        Console.WriteLine($"Registration ID: {RegistrationID}\nRegistration Date: {DateofRegistration.ToShortDateString()}");
    }

    //iFamilyInfo members implementation
    public string FatherName { get; set; } = String.Empty;
    public string MotherName { get; set; } = String.Empty;
    public string HouseAdress { get; set; } = String.Empty;
    public int NoOfSiblings { get; set; }

}
