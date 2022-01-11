using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDBank.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void New_account_should_have_zero_as_Balance()
        {
            var account = new BankAccount();

            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        public void Can_Deposit()
        {
            var account = new BankAccount();

            account.Deposit(5m);
            account.Deposit(2m);

            Assert.AreEqual(7m, account.Balance);
        }

        [TestMethod]
        public void Deposit_a_negative_value_throws_ArgumentEx()
        {
            var account = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => account.Deposit(-1));
        }

        [TestMethod]
        public void Deposit_a_zero_value_throws_ArgumentEx()
        {
            var account = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => account.Deposit(0));
        }

        [TestMethod]
        public void Can_Withdraw()
        {
            var account = new BankAccount();
            account.Deposit(10);

            account.Withdraw(6m);
            account.Withdraw(1m);

            Assert.AreEqual(3m, account.Balance);
        }

        [TestMethod]
        public void Withdraw_a_negative_value_throws_ArgumentEx()
        {
            var account = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => account.Withdraw(-1));
        }

        [TestMethod]
        public void Withdraw_a_zero_value_throws_ArgumentEx()
        {
            var account = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => account.Withdraw(0));
        }

        [TestMethod]
        public void Withdraw_more_than_Balance_throws_InvaildOperationEx()
        {
            var account = new BankAccount();
            account.Deposit(12);

            Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(13));
        }
    }
}