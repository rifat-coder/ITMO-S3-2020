using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Code_Of_Lab5v2
{
    class Client
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Account> ListOfAccounts = new List<Account>();

        public int IdOfPassport { get; set; }

        public bool Verification { get; }


        public Client(string NewName, string NewAddress, int NewIdOfPassport)
        {
            Name = NewName;

            Address = NewAddress;

            IdOfPassport = NewIdOfPassport;

            if (Address != "-" && IdOfPassport != 0)
            {
                Verification = false;
            }
            else
            {
                Verification = true;
            }
        }

        public void WithdrawMoney(Account AccountWithdrawFrom, Account AccountWithdrawTo, double QuantityOfMoney)
        {
            Debug.Assert(AccountWithdrawFrom != null, "Client is null!");
            Debug.Assert(AccountWithdrawTo != null, "Client is null!");
            AccountWithdrawFrom.TakeMoney(QuantityOfMoney);
            AccountWithdrawTo.AddMoney(QuantityOfMoney);
        }

        public void RemoveAccount(Account AccountForDel)
        {
            ListOfAccounts.Remove(AccountForDel);
        }
    }
}
