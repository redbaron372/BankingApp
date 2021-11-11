using NUnit.Framework;
using BankingApp;
using System;

namespace BankingAppTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void BankHasAName()
        {
            // Arrange

            var testBank = new Bank("Bank123");
            bool expected = true;

            //Act
            var nameNotNull = testBank.Name != null;

            //Assert
            Assert.AreEqual(expected, nameNotNull);
        }

        [Test]
        public void AccountHasAnOwner()
        {
            // Arrange

            var testAccount = new BankAccount("Robert Smith");
            bool expected = true;

            //Act
            var nameNotNull = testAccount.Owner != null;

            //Assert
            Assert.AreEqual(expected, nameNotNull);
        }

        [Test]
        public void AccountHasABalance()
        {
            // Arrange

            var testAccount = new BankAccount("Robert Smith", 1.00);
            var expected = 1.00;

            //Act
            var actual = testAccount.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BankHasSeveralAccounts()
        {
            //Arrange
            var testBank = new Bank("Bank123");
            testBank.Accounts.Add(new BankAccount("Jeff Smith", 100.00));
            testBank.Accounts.Add(new BankAccount("Tina Pool", 3.00));
            var expected = 1;

            //Act
            var numberAccounts = testBank.Accounts.Count;
            //Assert

            Assert.Less(expected, numberAccounts);
        }

        [Test]
        public void AccountTypeIsChecking()
        {
            // Arrange

            var testAccount = new BankAccount("Robert Smith", 1.00, "C");
            var expected = "C";

            //Act
            var actual = testAccount.AccountType;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AccountTypeIsInvestment()
        {
            // Arrange

            var testAccount = new BankAccount("Robert Smith", 1.00, "I");
            var expected = "I";

            //Act
            var actual = testAccount.AccountType;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AccountIsCorporate()
        {
            // Arrange

            var testAccount = new BankAccount("Robert Smith", 1.00, "I", true);
            var expected = true;

            //Act
            var actual = testAccount.Corporate;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Withdrawal()
        {
            // Arrange
            var startingBalance = 1000.00;
            var testAccount = new BankAccount("Robert Smith", startingBalance, "C");
            var withdrawalAmount = 40.00;
            var expected = testAccount.Balance - withdrawalAmount;


            //Act
            testAccount.Withdrawal(withdrawalAmount);

            //Assert
            var actual = testAccount.Balance;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawalOver500Corporate()
        {
            // Arrange
            var startingBalance = 1000.00;
            var testAccount = new BankAccount("Robert Smith", startingBalance, "I", true);
            var withdrawalAmount = 600.00;
            var expected = testAccount.Balance - withdrawalAmount;


            //Act
            testAccount.Withdrawal(withdrawalAmount);

            //Assert
            var actual = testAccount.Balance;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void WithdrawalOver500IndividualThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var startingBalance = 1000.00;
            var testAccount = new BankAccount("Robert Smith", startingBalance, "I", false);
            var withdrawalAmount = 600.00;
            var expected = testAccount.Balance - withdrawalAmount;


            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>( ()=>
            testAccount.Withdrawal(withdrawalAmount));
            
        }
        
        [Test]
        public void Deposit()
        {
            // Arrange
            var startingBalance = 1000.00;
            var testAccount = new BankAccount("Robert Smith", startingBalance, "C");
            var depositAmount = 40.00;
            var expected = testAccount.Balance + depositAmount;


            //Act
            testAccount.Deposit(depositAmount);

            //Assert
            var actual = testAccount.Balance;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TransferAccountTransferedTooHasCorrectBalance()
        {
            //Arrange
            var testBank = new Bank("Bank123");
            var transferAmount = 500.00;
            testBank.Accounts.Add(new BankAccount("Jeff Smith", 1000.00));
            testBank.Accounts.Add(new BankAccount("Tina Pool", 1000.00));
            var expected = 1500;

            //Act
            Bank.Transfer(testBank.Accounts[0], transferAmount, testBank.Accounts[1]);
            //Assert
            var actual = testBank.Accounts[1].Balance;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TransferAccountTransferedFromHasCorrectBalance()
        {
            //Arrange
            var testBank = new Bank("Bank123");
            var transferAmount = 500.00;
            testBank.Accounts.Add(new BankAccount("Jeff Smith", 1000.00));
            testBank.Accounts.Add(new BankAccount("Tina Pool", 1000.00));
            var expected = 500;

            //Act
            Bank.Transfer(testBank.Accounts[0], transferAmount, testBank.Accounts[1]);
            //Assert
            var actual = testBank.Accounts[0].Balance;
            Assert.AreEqual(expected, actual);
        }
    }
}