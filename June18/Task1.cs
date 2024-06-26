// Accouunt class
// Balance     : double
// AccountType : string
// ProcessTransaction
 
// Subscriber Class Events
// 1. Processing transaction ( Raise event before doing the transaction)
// 2. Transaction Complete  ( Print the New Balance and Account type on which transaction happened)
  
public delegate void TransactionEvent(Account account, double amount); // Delegate for transaction events

public class Account
{
    public double Balance { get; private set; }
    public string AccountType { get; private set; }
    private readonly List<TransactionEvent> subscribers = new List<TransactionEvent>();

    public Account(double initialBalance, string accountType)
    {
        Balance = initialBalance;
        AccountType = accountType;
    }

    public void Subscribe(TransactionEvent subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(TransactionEvent subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void ProcessTransaction(double amount)
    {
        // Raise ProcessingTransaction event before processing
        OnProcessingTransaction(this, amount);

        // Perform transaction logic (assuming no overdraft)
        if (amount > 0) // Deposit
        {
            Balance += amount;
        }
        else if (amount < 0 && Balance >= -amount) // Withdrawal with sufficient funds
        {
            Balance += amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        // Raise TransactionComplete event after processing
        OnTransactionComplete(this, amount);
    }

    private void OnProcessingTransaction(Account account, double amount)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber(account, amount);
        }
    }

    private void OnTransactionComplete(Account account, double amount)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber(account, amount);
        }
    }
}

public class Subscriber
{
    public void OnProcessingTransaction(Account account, double amount)
    {
        Console.WriteLine($"Processing transaction for account {account.AccountType} with amount {amount:C2}");
    }

    public void OnTransactionComplete(Account account, double amount)
    {
        Console.WriteLine($"Transaction completed for account {account.AccountType}. New balance: {account.Balance:C2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var account = new Account(1000.00, "Savings");
        var subscriber = new Subscriber();

        account.Subscribe(subscriber.OnProcessingTransaction);
        account.Subscribe(subscriber.OnTransactionComplete);

        account.ProcessTransaction(500.00); // Deposit
        Console.WriteLine();
        account.ProcessTransaction(-200.00); // Withdrawal

        // You can unsubscribe from events if needed
        // account.Unsubscribe(subscriber.OnProcessingTransaction);
    }
}
