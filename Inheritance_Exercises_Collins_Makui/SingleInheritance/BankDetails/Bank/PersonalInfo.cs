using System;
using System.ComponentModel.DataAnnotations;

namespace Bank;

public class PersonalInfo
{
    [Required]
    private static int counter = 1001;
    public string UserID { get{ return $"USR{counter++}"; } }
    public string? Name { get; set; }
    public string ?FatherName { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male, Female
}

public class AccountInfo : PersonalInfo
{
    [Required]
    static int counter = 100000001;
    private decimal _balance;

    public string AccountID { get { return $"ACCN{counter++}"; }}
    public string? BranchName { get; set; }
    public string? IFSCCode { get; set; }
    public decimal Balance { get{ return _balance; } set{ _balance = value; } }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }
}

