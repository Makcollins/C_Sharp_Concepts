using System;

namespace MedicalStore;

public interface IWallet
{
    decimal WalletBalance { get; set; }
    void WalletRecharge(decimal amount);
    void DeductBalance(decimal amount);
}
