using System;

namespace OnlineCourses;

public class UserDetails
{
    public required string RegistrationID { get; set; }
    public required string UserName { get; set; }
    public int Age { get; set; }

    public Gender Gen { get; set; }

    public required string Qualification { get; set; }

    public required string MobileNumber { get; set; }

    public required string MailID { get; set; }


    // public string RegistrationID
    // {
    //     get
    //     {
    //         return regID;
    //     }
    //     set
    //     {
    //         counter++;
    //         regID = "SYNC" + counter.ToString();
    //         // counter++;
    //     }
    // }
}
