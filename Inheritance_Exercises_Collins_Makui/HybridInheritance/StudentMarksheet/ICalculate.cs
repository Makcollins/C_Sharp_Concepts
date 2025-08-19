using System;

namespace StudentMarksheet;

public interface ICalculate
{
    int ProjectMark{ get; set; }
    void CalculateUGMarksheet();

}
