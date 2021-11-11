using System;

namespace BankingApp
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
        public bool Corporate { get; set; }


        public BankAccount(string owner, double balance = 0, string accountType = "C", bool commercialAccount = false)
        {
            this.Owner = owner;
            this.Balance = balance;
            this.AccountType = accountType;
            this.Corporate = commercialAccount;
        }

        public void Withdrawal(double withdrawalAmount)
        {
            if(withdrawalAmount > 500 && Corporate == false)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Balance -= withdrawalAmount;
        }

        public void Deposit(double depositAmount)
        {
            this.Balance += depositAmount;
        }
    }

}