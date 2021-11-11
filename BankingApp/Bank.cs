using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class Bank
    {
        public string Name { get; set; }
        public List<BankAccount> Accounts = new();

        public Bank(string name)
        {
            this.Name = name;
        }

        public static void Transfer(BankAccount withdrawalAccount, double transferAmount, BankAccount depositAccount)
        {
            withdrawalAccount.Withdrawal(transferAmount);
            depositAccount.Deposit(transferAmount);
        }
    }
}
