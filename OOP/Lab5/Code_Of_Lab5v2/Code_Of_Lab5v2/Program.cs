using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Code_Of_Lab5v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                СonditionsForDepositAccount сonditionsForDepositAccount = new СonditionsForDepositAccount(new List<double>() { 0.03, 0.05, 0.10 }, 10);
                СonditionsForDebetAccount сonditionsForDebetAccount = new СonditionsForDebetAccount(new List<double>() { 0.05 });
                СonditionsForCreditAccount сonditionsForCreditAccount = new СonditionsForCreditAccount(-100, 0.008);
                BankСonditions bankСonditions = new BankСonditions(сonditionsForDepositAccount, сonditionsForDebetAccount, сonditionsForCreditAccount);


                Bank MyBank = new Bank("Sber", bankСonditions);

                Client Rifat = MyBank.AddClient("Murtazin Rifat", "-", 0);
                Console.WriteLine($"Murtazin Rifat is Verifed: {MyBank.ListOfClients[0].Verification}"); // false
                DebitAccount debit = MyBank.AddDebitAccount(Rifat);

                MyBank.PayeeBalanceToAccount(Rifat, debit, 50000);

                Rifat.Address = "Abramova street";
                Rifat.IdOfPassport = 9215;

                MyBank.WithdrawBalanceFromAccount(Rifat, debit, 11400);

                CreditAccount credit = MyBank.AddCreditAccount(Rifat);
                MyBank.WithdrawBalanceFromAccount(Rifat, credit, 100000);

                Console.WriteLine("Money Before Month: ");
                Console.WriteLine("Debit Cost" + debit.BankBalance);
                Console.WriteLine("Credit Cost" + credit.BankBalance);
                Console.WriteLine("Money After Month: ");
                Console.WriteLine("Debit Cost" + debit.BankBalance);
                Console.WriteLine("Credit Cost" + credit.BankBalance);

                Guid id = MyBank.SendMoney(Rifat, debit, credit, 150000);

                MyBank.SaveOperetionInHistoryList(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }
            
        }
    }
}
