using System;
using System.Collections.Generic;

namespace Code_Of_Lab5v2
{
    class BankStatement
    {
        public Guid TransactionID;

        public bool OperationType; // true if addding money and false if losing money

        public Account BankAccount;

        public Client Client;

        public double QuantityOfMoney;

        public BankStatement(Guid transactionID_, Account NewAccount, double NewMoney, bool TypeOfOperation, Client NewClient)
        {

            TransactionID = transactionID_;

            BankAccount = NewAccount;

            OperationType = TypeOfOperation;

            QuantityOfMoney = NewMoney;

            Client = NewClient;
            
        }
    }

    class History
    {
        public List<BankStatement> HistoryOfOperations { get; } = new List<BankStatement>();

        public History(BankStatement bankStatement)
        {
            HistoryOfOperations.Add(bankStatement);
        }

        public History() { }

        public void AddBankStatement(BankStatement bankStatement)
        {
            HistoryOfOperations.Add(bankStatement);
        }

        public void RemoveBankStatement(BankStatement bankStatement)
        {
            HistoryOfOperations.Remove(bankStatement);
        }

        public BankStatement FindBankStatement(Guid TransactionID)
        {
            return HistoryOfOperations.Find(x => x.TransactionID == TransactionID);
        }
    }
}
