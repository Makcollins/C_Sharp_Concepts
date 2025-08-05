using System;

namespace SyncMart;

public class CustomerDetails
{
    public string CustomerID { get; set; } = String.Empty;
    public string CustomerName { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string MobileNumber { get; set; } = String.Empty;
    public int WalletBalance { get; set; }
    public string EmailID { get; set; } = String.Empty;

    public void WalletRecharge(int rechargeAmount)
    {
        WalletBalance += rechargeAmount;
    }

    public void DeductBalance(int deductAmount)
    {
        WalletBalance -= deductAmount;
    }

}
