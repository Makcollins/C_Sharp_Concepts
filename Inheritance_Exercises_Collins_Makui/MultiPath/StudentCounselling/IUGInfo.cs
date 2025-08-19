using System;

namespace StudentCounselling;

public interface IUGInfo:IPersonalInfo
{
    string UGMarksheetNumber { get; set; }
    int Sem1Mark { get; set; }
    int Sem2Mark { get; set; }
    int Sem3Mark { get; set; }
    int Sem4Mark { get; set; }
    int UGTotal { get; set; }
    double UGPercentage { get; set; }
    void CalculateUG();
    void Display();

}
