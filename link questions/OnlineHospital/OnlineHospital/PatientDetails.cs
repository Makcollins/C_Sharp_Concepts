using System;

namespace OnlineHospital;

public class PatientDetails : PersonalDetails, ITransaction
{
    public decimal _walletBalance;
    public string? PatientID { get; }
    public decimal WalletBalance { get{ return _walletBalance; } }
    static int counter = 1001;

    public PatientDetails()
    {
        PatientID = $"PID{counter++}";
    }

    public void Recharge(decimal amount)
    {
        _walletBalance += amount;
    }
    public void DeductBalance(decimal amount)
    {
        _walletBalance -= amount;
    }
}
