using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class AccountTest {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [TestMethod]
        public void checking_account_has_flat_rate_1_pct() {
            var account = new Account(Account.CHECKING);
            account.Deposit(100);
            var result = account.InterestEarned();
            Assert.AreEqual(.1, result);
        }

        [TestMethod]
        public void savings_account_has_flat_rate_1_pct_for_first_1000() {
            var account = new Account(Account.SAVINGS);
            account.Deposit(1000);
            var result = account.InterestEarned();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void savings_account_has_flat_rate_2_pct_after_1000() {
            var account = new Account(Account.SAVINGS);
            account.Deposit(2000);
            var result = account.InterestEarned();
            Assert.AreEqual(3, result, DOUBLE_DELTA);
        }

        [TestMethod]
        public void maxi_savings_account_has_interestEarned_5_pct_if_withdraws_10_days() {
            var account = new Account(Account.MAXI_SAVINGS);
            account.Deposit(1000);
            var result = account.InterestEarned();
            Assert.AreEqual(5, result, DOUBLE_DELTA);
        }

        [TestMethod]
        public void maxi_savings_account_has_interestEarned_1_if_withdraws_10_days() {
            var account = new Account(Account.MAXI_SAVINGS);
            account.Deposit(2000);
            account.Withdraw(1000);
            var result = account.InterestEarned();
            Assert.AreEqual(1, result, DOUBLE_DELTA);
        }

    }
}