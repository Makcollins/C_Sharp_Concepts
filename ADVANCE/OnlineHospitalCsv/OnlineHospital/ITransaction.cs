using System;

namespace OnlineHospital;

public interface ITransaction
{
    decimal WalletBalance { get; }

    void Recharge(decimal amount);
    void DeductBalance(decimal amount);
}
