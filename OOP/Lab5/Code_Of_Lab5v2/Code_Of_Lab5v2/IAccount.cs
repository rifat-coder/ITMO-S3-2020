using System;

namespace Code_Of_Lab5v2
{
    //public class IAccount

    public class Account
    {
        public Guid Id { get; protected set; }

        public double PercentOfAccount;

        public double BankBalance { get; set; }

        public double ComissionPercentOfAccount;
        
        public double LowerLimit;

        public DateTime LimDateOfAccount = DateTime.Now;

        public void AddMoney(double NewMonewToAdd) { BankBalance += NewMonewToAdd; }

        public bool TakeMoney(double take)
        {
            bool flag = BankBalance - take <= LowerLimit || LimDateOfAccount <= DateTime.Now ? true : false;
            if (flag) { BankBalance -= take; }
            return flag;
        }
        
        public bool CanYouTakeMoney(double take)
        {
            return (BankBalance - take < LowerLimit && LimDateOfAccount <= DateTime.Now);
        }

    }

    class CreditAccount : Account
    {
        public CreditAccount(СonditionsForCreditAccount NewCondCredit)
        {
            Id = Guid.NewGuid();

            ComissionPercentOfAccount = NewCondCredit.Commission;

            LowerLimit = NewCondCredit.LowerLimit;
        }
    }

    public class DebitAccount : Account
    {
        public DebitAccount(СonditionsForDebetAccount NewCondDebet)
        {
            base.Id = Guid.NewGuid();

            PercentOfAccount = NewCondDebet.ListOfPercentsBank[0];
        }
    }

    class DepositeAccount : Account
    {
        public double PerBefore50 { get; set; }

        public double PerBefore100 { get; set; }

        public double PerAfter100 { get; set; }

        public DepositeAccount(double NewMoney, СonditionsForDepositAccount NewCondDeposit)
        {
            base.Id = Guid.NewGuid();

            BankBalance = NewMoney;

            LimDateOfAccount.AddMonths(NewCondDeposit.TermInDays);

            PercentOfAccount = NewCondDeposit.ListOfPercentsBank[0];

            PerBefore50 = PercentOfAccount;

            PerBefore100 = NewCondDeposit.ListOfPercentsBank[1];

            PerAfter100 = NewCondDeposit.ListOfPercentsBank[2];
        }
    }

    abstract class AccountBuilder
    {
        public Account account { get; private set; }
        public void CreateAccount()
        {
            account = new Account();
        }
        
    }
}
