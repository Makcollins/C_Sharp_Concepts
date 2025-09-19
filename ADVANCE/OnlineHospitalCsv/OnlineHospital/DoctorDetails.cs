using System;
using System.Dynamic;

namespace OnlineHospital;

public class DoctorDetails : PersonalDetails
{
    public string? DoctorID { get; set; }
    public int Experience { get; set; }
    public string? Specialization { get; set; }
    public decimal Fees { get; set; }
    static int counter = 301;
    public DoctorDetails()
    {
        DoctorID = $"DID{counter++}";
    }
}
