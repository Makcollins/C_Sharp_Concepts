using System;

namespace Cafeteria;

public interface IBalance
{
    decimal  WalletBalance { get; }
    void WalletRecharge(decimal amount);
    void DeductAmount(decimal amount);
}
