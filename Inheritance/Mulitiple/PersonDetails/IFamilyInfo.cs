using System;

namespace PersonDetails;

public interface IFamilyInfo
{
    string FatherName { get; set; }
    string MotherName { get; set; }
    string HouseAdress { get; set; }
    int NoOfSiblings{ get; set; }
}
