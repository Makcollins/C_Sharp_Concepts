using System;

namespace Banking;

public interface ICalculate
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    decimal BalanceCheck();
}
