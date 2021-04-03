using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Code_Of_Lab5v2
{
    public interface IBankConditions
    {
        public List<double> ListOfPercentsBank { get; }
    }

    public class СonditionsForDepositAccount : IBankConditions
    {
        public List<double> ListOfPercentsBank { get; set; } = new List<double>();
        public int TermInDays { get; set; }
        public СonditionsForDepositAccount(List<double> ListPercent, int NewTermInDays)
        {
            ListOfPercentsBank = ListPercent;
            TermInDays = NewTermInDays;
        }
    }
    
    public class СonditionsForDebetAccount : IBankConditions
    {
        public List<double> ListOfPercentsBank { get; set; } = new List<double>();
        public СonditionsForDebetAccount(List<double> ListPercent)
        {
            ListOfPercentsBank = ListPercent;
        }
    }

    public class СonditionsForCreditAccount : IBankConditions
    {
        public List<double> ListOfPercentsBank { get; set; } = new List<double>();
        public double LowerLimit { get; set; } = 0;
        public double Commission { get; set; } = 0.003;
        public СonditionsForCreditAccount(double NewLowerLimit, double NewCommission)
        {
            LowerLimit = NewLowerLimit;
            Commission = NewCommission;
        }
    }

    public class BankСonditions
    {
        public СonditionsForDepositAccount Deposit { get; }
        public СonditionsForDebetAccount Debet { get; }
        public СonditionsForCreditAccount Credit { get; }

        public BankСonditions(СonditionsForDepositAccount NewCondDeposit, СonditionsForDebetAccount NewCondDebet, СonditionsForCreditAccount NewCondCredit)
        {
            Deposit = NewCondDeposit;
            Debet = NewCondDebet;
            Credit = NewCondCredit;
        }
    }

    class Bank
    {
        public string Name;

        public BankСonditions BankСonditions { get; set; }

        public History HistoryOfOperations = new History();

        public double LimitForNotVerifiedClients { get; set; }

        public List<Client> ListOfClients = new List<Client>();

        public Bank(string name_, BankСonditions NewBankСonditions)
        {
            BankСonditions = NewBankСonditions;

            Name = name_;

            LimitForNotVerifiedClients = 10000;
        }

        public Client AddClient(string NewName, string NewAddress, int NewPassportId)
        {
            ListOfClients.Add(new Client(NewName, NewAddress, NewPassportId));

            return ListOfClients[ListOfClients.Count - 1];
        }

        public DebitAccount AddDebitAccount(Client NewClient)
        {
            Debug.Assert(NewClient != null, "Client is null!");
            DebitAccount Debit = new DebitAccount(BankСonditions.Debet);
            ListOfClients.Find(item => item.Name == NewClient.Name).ListOfAccounts.Add(Debit);
            return Debit;
        }

        public DepositeAccount AddDepositeAccount(Client client, double money_)
        {
            Debug.Assert(client != null, "Client is null!");
            DepositeAccount deposite = new DepositeAccount(money_, BankСonditions.Deposit);
            ListOfClients.Find(item => item.Name == client.Name).ListOfAccounts.Add(deposite);
            return deposite;
        }

        public CreditAccount AddCreditAccount(Client client)
        {
            CreditAccount credit = new CreditAccount(BankСonditions.Credit);
            ListOfClients.Find(item => item.Name == client.Name).ListOfAccounts.Add(credit);
            return credit;
        }

        public Guid PayeeBalanceToAccount(Client ToClient, Account ToAccount, double NewAdditiMoney)
        {
            Guid CurrentIdTransaction = Guid.NewGuid();
            ToClient = ListOfClients.Find(item => item.Name == ToClient.Name);
            Debug.Assert(ToClient != null, "Client is null!");
            ToAccount = ToClient.ListOfAccounts.Find(item => item.Id == ToAccount.Id);
            Debug.Assert(ToAccount != null, "Cost is null!");
            ToAccount.AddMoney(NewAdditiMoney);
            HistoryOfOperations.AddBankStatement(new BankStatement(CurrentIdTransaction, ToAccount, NewAdditiMoney, true, ToClient));
            return CurrentIdTransaction;
            
        }

        public Guid WithdrawBalanceFromAccount(Client FromClient, Account FromAccount, double NewAdditiMoney)
        {
            Guid CurrentIdTransaction = Guid.NewGuid();
            FromClient = ListOfClients.Find(item => item.Name == FromClient.Name);
            Debug.Assert(FromClient != null, "Client is null!");
            FromAccount = FromClient.ListOfAccounts.Find(item => item.Id == FromAccount.Id);
            Debug.Assert(FromAccount != null, "Cost is null!");
            if (!FromClient.Verification && NewAdditiMoney > LimitForNotVerifiedClients) { throw new Exception("Transaction denied"); }
            else
            {
                FromAccount.TakeMoney(NewAdditiMoney);
                HistoryOfOperations.AddBankStatement(new BankStatement(CurrentIdTransaction, FromAccount, NewAdditiMoney, false, FromClient));
                return CurrentIdTransaction;
            }
        }

        public Guid SendMoney(Client client, Account costfrom, Account costto, double money)
        {
            Guid CurrentIdTransaction = Guid.NewGuid();
            WithdrawBalanceFromAccount(client, costfrom, money);
            PayeeBalanceToAccount(client, costto, money);
            return CurrentIdTransaction;
            
        }

        public void SaveOperetionInHistoryList(Guid TransactionId)
        {
            var CurrentHistory = HistoryOfOperations.FindBankStatement(TransactionId);
            if (CurrentHistory == null)
            {
                return;
            }
            HistoryOfOperations.RemoveBankStatement(HistoryOfOperations.FindBankStatement(TransactionId));

            if (CurrentHistory.OperationType == true)
                WithdrawBalanceFromAccount(HistoryOfOperations.FindBankStatement(TransactionId).Client, HistoryOfOperations.FindBankStatement(TransactionId).BankAccount, HistoryOfOperations.FindBankStatement(TransactionId).QuantityOfMoney);
            else
                PayeeBalanceToAccount(HistoryOfOperations.FindBankStatement(TransactionId).Client, HistoryOfOperations.FindBankStatement(TransactionId).BankAccount, HistoryOfOperations.FindBankStatement(TransactionId).QuantityOfMoney);

        }
    }
}
