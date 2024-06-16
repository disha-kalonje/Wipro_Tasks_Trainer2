// Create Account class with AccountId and AccountBalance property in it. Create an AccountManager Class which contain property 1. FromAccount ( DataType->Account) 2. ToAccount ( DataType-> Account) 3. AmountToTransfer ( Double) 4. Transfer ( Depbit amount from Account to credit to another account) Create two account objects and send the money from Account A to AccountB with the help of Transfer method of accountManager. Run method for transfer on Thread. we have to wait for the thread to complete before mainthread get complete.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_acc_june6
{
    public class Account
    {
        public int AccountId { get; private set; }
        private double balance;

        public Account(int accountId, double initialBalance)
        {
            AccountId = accountId;
            balance = initialBalance;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void Withdraw(double amount)
        {
            if (balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            balance -= amount;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }
    }

    public class AccountManager
    {
        private readonly object lockObject = new object(); // Lock object for thread safety

        public Account FromAccount { get; private set; }
        public Account ToAccount { get; private set; }
        public double AmountToTransfer { get; private set; }

        public AccountManager(Account fromAccount, Account toAccount, double amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            AmountToTransfer = amount;
        }

        public void Transfer()
        {
            lock (lockObject) // Synchronized block for thread safety
            {
                if (FromAccount.GetBalance() < AmountToTransfer)
                {
                    Console.WriteLine("Insufficient funds in account {0}", FromAccount.AccountId);
                    return;
                }

                FromAccount.Withdraw(AmountToTransfer);
                ToAccount.Deposit(AmountToTransfer);

                Console.WriteLine("Transferred {0} from account {1} to account {2}", AmountToTransfer, FromAccount.AccountId, ToAccount.AccountId);
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Account accountA = new Account(1001, 1000);
            Account accountB = new Account(1002, 500);

            AccountManager accountManager = new AccountManager(accountA, accountB, 300);

            // Create and run the transfer thread
            Thread transferThread = new Thread(accountManager.Transfer);
            transferThread.Start();

            // Wait for the transfer thread to complete before continuing
            transferThread.Join();

            Console.WriteLine("Account A balance: {0}", accountA.GetBalance());
            Console.WriteLine("Account B balance: {0}", accountB.GetBalance());
        }
    }
}
