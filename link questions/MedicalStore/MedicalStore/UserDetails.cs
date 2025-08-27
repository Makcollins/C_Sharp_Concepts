using System;

namespace MedicalStore;

public class UserDetails : PersonalDetails, IWallet
{
    public string UserID { get; set; }
    public decimal WalletBalance { get; set; }
    private static int counter = 1001;

    public UserDetails()
    {
        UserID = $"UID{counter++}";
    }
    public void WalletRecharge(decimal amount)
    {
        WalletBalance += amount;
    }
    public void DeductBalance(decimal amount)
    {
        WalletBalance -= amount;
    }
}
