using System;

namespace StudentCounselling;

public interface IHSCInfo : IPersonalInfo
{
    string HSCMarksheetNumber { get; set; }
    int Physics { get; set; }
    int Chemistry { get; set; }
    int Maths { get; set; }
    int HSCTotal { get; set; }
    double HSCPercentage { get; set; }
    void CalculateHSC();
    void Display();
}
