using System;

namespace Banking;

public interface IBankInfo
{
    public string? BankName { get; set; }
    public string? IFSC { get; set; }
    public string? Branch{ get; set; }
}
