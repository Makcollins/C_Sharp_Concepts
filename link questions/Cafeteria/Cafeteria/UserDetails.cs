using System;

namespace Cafeteria;

public class UserDetails : PersonalDetails, IBalance
{
    private static int counter = 1001;
    public string UserID { get; set; }
    public string? WorkStationNumber { get; set; }
    public decimal balance;
    public decimal WalletBalance { get { return balance; } }
    public UserDetails()
    {
        UserID = $"SF{counter++}";
    }

    public void WalletRecharge(decimal amount)
    {
        balance += amount;
    }
    public void DeductAmount(decimal amount){
        balance -= amount;
    }

}
