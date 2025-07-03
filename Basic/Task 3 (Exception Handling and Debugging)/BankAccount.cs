using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Exception_Handling_and_Debugging_
{
    class BankAccount
    {
        private string accountHolder;

        private double accountBalance;

        public BankAccount(string accountHolder, double accountBalance)
        {
            this.accountHolder = accountHolder;
            this.accountBalance = accountBalance;
        }

        public string Holder
        {
            get { return accountHolder; }

            set { accountHolder = value; }
        }

        public double balance
        {
            get { return accountBalance; }

        }



        public string Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new InvalidAmountException("The amount specified is invalid.");
            }

            else
            {
                accountBalance = accountBalance + amount;
                return $"Deposit Successful.{amount}$ added to balance. your current balance is now {accountBalance}$";
                
            }
        }


        public string Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("The amount specified is invalid.");
            }
            else if( amount > accountBalance)
            {
                throw new InsufficientFundsException("You do not have sufficient funds in your account.");
            }
            else
            {
                accountBalance = accountBalance - amount;
                return $"Withdraw successful.{amount}$ credited from your bank account.";
            }

        }
    }
}
