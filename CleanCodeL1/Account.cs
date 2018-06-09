using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeL1
{
    public class Account
    {
        public Account(double initialBalance, double interest)
        {
            if (double.IsNaN(initialBalance) || double.IsNaN(interest))
            {
                throw new Exception($"initialBalance or interest is NaN (initialBalance = {initialBalance} interest = {interest})");
            }
            if (initialBalance < 0 || interest <= 0)
            {
                throw new Exception($"Invalid initial balance or interest (initialBalance = {initialBalance}, interest = {interest})");
            }
            Balance = initialBalance;
            Interest = interest;
        }
        public double Balance { get; private set; }
        double Interest { get; set; }

        public void Deposit(double amount)
        {
            if (double.IsNaN(amount))
            {
                throw new Exception("amount is NaN");
            }
            if (amount <= 0)
            {
                throw new Exception($"amount is <= 0 (amount = {amount})");
            }
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (double.IsNaN(amount))
            {
                throw new Exception("amount is NaN");
            }
            if (amount <= 0)
            {
                throw new Exception($"amount is <= 0 (amount = {amount})");
            }
            if (amount > Balance)
            {
                throw new Exception($"amount to withdraw is larger than current Balance (amount = {amount}, Balance = {Balance})");
            }
            Balance -= amount;
        }

        public void Transfer(Account target, double amount)
        {
            Withdraw(amount);
            target.Deposit(amount);
        }

        public double CalculateInterest()
        {
            double interestAmount = Balance * Interest;
            Deposit(interestAmount);
            return interestAmount;
        }
    }
}
