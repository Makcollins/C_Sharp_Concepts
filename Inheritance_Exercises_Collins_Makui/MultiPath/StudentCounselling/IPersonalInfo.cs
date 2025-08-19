using System;

namespace StudentCounselling;

public interface IPersonalInfo
{
    public string AadharNumber { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string Phone { get; set; }
    public DateTime DOB { get; set; }
     public Gender Gen { get; set; }

}
