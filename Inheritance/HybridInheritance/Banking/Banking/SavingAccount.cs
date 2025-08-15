using System;

namespace Banking;

public class SavingAccount : IDInfo, ICalculate, IBankInfo
{
    public string? AccountNumber { get; set; }
    public AccountType AccType { get; set; }

    public string? BankName{ get; set; }
    public string? IFSC{ get; set; }
    public string? Branch{ get; set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
    public decimal BalanceCheck()
    {
        return Balance;
    }
  
}
