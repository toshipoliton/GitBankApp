using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank2;
using System;
using Bank2.Core;
using Bank2.Core.Accounts.Enum;
using System.Collections.Generic;

namespace Bank2.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void should_create_new_BankAccount()
        {
            //arragne
            Bank b = new Bank();

            //act
            b.CreateBankAccount(AccountType.CheckingsAcccount, 0);
            //assert
            Assert.AreEqual(b.accounts.Count, 1);
        }
        [TestMethod()]
        public void should_create_new_BankAccount_with_initial_value()
        {
            //arragne
            Bank b = new Bank();
            double expected = 500;

            //act
            b.CreateBankAccount(AccountType.CheckingsAcccount, 500);

            //assert
            Assert.AreEqual(expected, b.accounts[0].Balance);
        }
        [TestMethod()]
        public void should_deposit_amount_to_BankAccount()
        {
            //arragne
            Bank b = new Bank();
            b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 600;

            //act
            b.Deposit("123", 100);

            //assert
            Assert.AreEqual(expected, b.accounts[0].Balance);
        }
        [TestMethod()]
        public void should_create_new_BankAccount_with_number()
        {
            //arragne
            Bank b = new Bank();

            //act
            string accountnumber = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);

            //assert
            Assert.AreEqual(accountnumber, b.accounts[0].AccountNumber);
        }
        [TestMethod()]
        public void should_deposit_amount_to_correct_account()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 600;

            //act
            b.Deposit(accountone, 100);
            double amounta = b.GetAmount(accountone);

            //assert
            Assert.AreEqual(expected, amounta);
        }
        [TestMethod()]
        public void should_leave_other_account_uneffected_on_deposit()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 500;

            //act
            b.Deposit(accountone, 100);
            double amountb = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amountb);

        }
        [TestMethod()]
        public void should_withdrawl_amount_to_correct_account()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 400;

            //act
            b.Withdrawl(accountone, 100);
            double amounta = b.GetAmount(accountone);

            //assert
            Assert.AreEqual(expected, amounta);
        }
        [TestMethod()]
        public void should_transfer_amount_and_correct_accountone()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 400;

            //act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accountone);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_and_correct_accounttwo()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 600;

            //act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_from_saving_to_checkingsAccount()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 600;

            //act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_not_transfer_from_saving_to_other_cliens_account()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            double expected = 600;

            //act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_from_Checking_to_other_Savings_account_with_interest()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.SavingsAccount, 500);
            double expected = 660;

            //Act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_from_Checking_to_Losings_account_with_interest()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.LosingsAccount, 500);
            double expected = 540;

            //Act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_from_Checking_to_Losings_account_with_interest_looking_at_Cheking()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.LosingsAccount, 500);
            double expected = 400;

            //Act
            b.Transfer(accountone, accounttwo, 100);

            double amount = b.GetAmount(accountone);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_transfer_from_Checking_to_Savings_account_with_interest_looking_at_Savings_balance_0()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 500);
            string accounttwo = b.CreateBankAccount(AccountType.SavingsAccount, 0);
            double expected = 22;

            //Act
            b.Transfer(accountone, accounttwo, 20);

            double amount = b.GetAmount(accounttwo);

            //assert
            Assert.AreEqual(expected, amount);
        }
        [TestMethod()]
        public void should_be_able_to_withdraw_more_amount_than_current_balance_holds()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.CheckingsAcccount, 100);
            double expected = -20;

            //Act
            b.Withdrawl(accountone, 120);

            double amount = b.GetAmount(accountone);

            //assert
            Assert.AreEqual(expected, amount);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void should_not_be_able_to_withdraw_more_amount_than_current_balance_holds()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.SavingsAccount, 100);

            //Act
            b.Withdrawl(accountone, 120);

            double amount = b.GetAmount(accountone);

            //assert
            // Assert.AreEqual(expected, amount);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void should_not_be_able_to_deposit_negative_amount()
        {
            //arragne
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.SavingsAccount, 10);


            //Act
            b.Deposit(accountone, -20);

            //assert
            // Assert.AreEqual(expected, message);
        }
        [TestMethod()]
        public void should_not_be_able_to_deposit_negative_amount_method2()
        {
            //arrange
            Bank b = new Bank();
            string accountone = b.CreateBankAccount(AccountType.SavingsAccount, 10);
            ApplicationException exception = null;
            string expected = "Amount must be positive";


            //Act
            try
            {
                b.Deposit(accountone, -20);
            }
            catch (ApplicationException ex)
            {
                exception = ex;
            }

            //assert
            Assert.AreEqual(expected, exception.Message);
        }
    }
}
