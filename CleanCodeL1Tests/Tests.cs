using System;
using Xunit;
using CleanCodeL1;

namespace CleanCodeL1Tests
{
    public class Tests
    {
        [Fact]
        void TestsConstructorWithNegativeBalance()
        {
            double balance = -101.75;
            double interest = 0.1;
            Assert.Throws<Exception>(() => new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithNegativeInterest()
        {
            double balance = 100.75;
            double interest = -0.1;
            Assert.Throws<Exception>(() => new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithZeroBalance()
        {
            double balance = 0;
            double interest = 0.1;
            Assert.NotNull(new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithZeroInterest()
        {
            double balance = 100.75;
            double interest = 0;
            Assert.Throws<Exception>(() => new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithNormalValues()
        {
            double balance = 100.75;
            double interest = 0.1;
            Assert.NotNull(new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithExtremeValues()
        {
            double balance = 1001283712893.12375;
            double interest = 0.00000001123123;
            Assert.NotNull(new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithNaN()
        {
            double balance = double.NaN;
            double interest = double.NaN;
            Assert.Throws<Exception>(() => new Account(balance, interest));
        }

        [Fact]
        void TestsConstructorWithInfinity()
        {
            double balance = double.PositiveInfinity;
            double interest = double.PositiveInfinity;
            Assert.NotNull(new Account(balance, interest));
        }

        [Fact]
        void TestsDepositWithNegativeNumber()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double depositAmount = -90;

            Assert.Throws<Exception>(() => account.Deposit(depositAmount));
        }

        [Fact]
        void TestsDepositWithZero()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double depositAmount = 0;

            Assert.Throws<Exception>(() => account.Deposit(depositAmount));
        }

        [Fact]
        void TestsDepositWithNan()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double depositAmount = double.NaN;

            Assert.Throws<Exception>(() => account.Deposit(depositAmount));
        }

        [Fact]
        void TestsDepositWithNormalNumber()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double depositAmount = 90;
            double expectedBalance = balance + depositAmount;
            account.Deposit(depositAmount);

            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        void TestsDepositWithInfinity()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double depositAmount = double.PositiveInfinity;
            double expectedBalance = balance + depositAmount;
            account.Deposit(depositAmount);

            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        void TestsWithdrawWithNegativeNumber()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double withdrawAmount = -50;

            Assert.Throws<Exception>(() => account.Withdraw(withdrawAmount));
        }

        [Fact]
        void TestsWithdrawWithNaN()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double withdrawAmount = double.NaN;

            Assert.Throws<Exception>(() => account.Withdraw(withdrawAmount));
        }

        [Fact]
        void TestsWithdrawWithZero()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double withdrawAmount = 0;

            Assert.Throws<Exception>(() => account.Withdraw(withdrawAmount));
        }

        [Fact]
        void TestsWithdrawWithMoreThanBalance()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double withdrawAmount = 200;

            Assert.Throws<Exception>(() => account.Withdraw(withdrawAmount));
        }

        [Fact]
        void TestsWithdrawWithNormalNumber()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double withdrawAmount = 50.75;
            double expectedBalance = balance - withdrawAmount;
            account.Withdraw(withdrawAmount);

            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        void TestsTransferWithNegativeNumber()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            double balance2 = 200.75;
            double interest2 = 0.2;
            Account account2 = new Account(balance2, interest2);

            double transferAmount = -50;

            Assert.Throws<Exception>(() => account1.Transfer(account2, transferAmount));
        }

        [Fact]
        void TestsTransferWithNaN()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            double balance2 = 200.75;
            double interest2 = 0.2;
            Account account2 = new Account(balance2, interest2);

            double transferAmount = double.NaN;

            Assert.Throws<Exception>(() => account1.Transfer(account2, transferAmount));
        }

        [Fact]
        void TestsTransferWithZero()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            double balance2 = 200.75;
            double interest2 = 0.2;
            Account account2 = new Account(balance2, interest2);

            double transferAmount = 0;

            Assert.Throws<Exception>(() => account1.Transfer(account2, transferAmount));
        }

        [Fact]
        void TestsTransferWithMoreThanAccount1Balance()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            double balance2 = 200.75;
            double interest2 = 0.2;
            Account account2 = new Account(balance2, interest2);

            double transferAmount = 200;

            Assert.Throws<Exception>(() => account1.Transfer(account2, transferAmount));
        }

        [Fact]
        void TestsTransferWithNormalNumber()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            double balance2 = 200.75;
            double interest2 = 0.2;
            Account account2 = new Account(balance2, interest2);

            double transferAmount = 50.75;
            double expectedAccount1Balance = balance1 - transferAmount;
            double expectedAccount2Balance = balance2 + transferAmount;
            account1.Transfer(account2, transferAmount);

            Assert.Equal(expectedAccount1Balance, account1.Balance);
            Assert.Equal(expectedAccount2Balance, account2.Balance);
        }

        [Fact]
        void TestsTransferWithNullAccount()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);
            Account account2 = null;

            double transferAmount = 90;

            Assert.Throws<Exception>(() => account1.Transfer(account2, transferAmount));
        }

        [Fact]
        void TestsTransferWithSameAccount()
        {
            double balance1 = 100.75;
            double interest1 = 0.1;
            Account account1 = new Account(balance1, interest1);

            double transferAmount = 90;

            Assert.Throws<Exception>(() => account1.Transfer(account1, transferAmount));
        }

        [Fact]
        void TestsCalculateInterestReturnValue()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double expectedInterest = balance * interest;

            Assert.Equal(expectedInterest, account.CalculateInterest());
        }

        [Fact]
        void TestsCalculateInterestWhereIntererestIsAddedToBalance()
        {
            double balance = 100.75;
            double interest = 0.1;
            Account account = new Account(balance, interest);

            double expectedBalance = balance * interest + balance;
            account.CalculateInterest();

            Assert.Equal(expectedBalance, account.Balance);
        }
    }
}