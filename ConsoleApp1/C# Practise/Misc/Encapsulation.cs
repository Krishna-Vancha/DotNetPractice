using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace ConsoleApp1.C__Practise.Misc
{
    public class Encapsulation
    {
        public static void Main(string[] args)
        {
            BankAccount account=new BankAccount(2000m);
            Console.WriteLine(account.GetBalance());
            // account.Withdraw(3000);
            account.Deposit(500);   // now transactionHistory has 1 real entry
            IReadOnlyList<string> transactionlist = account.TransactionHistory();
            Console.WriteLine(string.Join(" ", transactionlist));
             // transactionlist.Add("Test"); No accessible as readonly

        }
         
    }
    public class BankAccount
    {
        private decimal balance ;
        private string accountHolderName;
        private List<string> transactionHistory=new List<string>();
        private static int helper = 0;


        public IReadOnlyList<string> TransactionHistory() => transactionHistory.AsReadOnly();
        public string AccountNumber { get; private set; }


        private void LogTransaction(string message)
        {
            transactionHistory.Add(message);

        }


        public BankAccount(decimal balance)
        {
            

           Balance=balance>=0?balance: throw new ArgumentException("balance should be greater than zero/0");
            AccountNumber += "ACC-" + helper++;
        }

        public int GetTransactionCount => transactionHistory.Count; 


        public decimal GetBalance() =>
            Balance;

        public string AccountHolderName
        {
            get => accountHolderName;
            set => accountHolderName = string.IsNullOrEmpty(value)?throw new ArgumentException("Name cannot be Empty"):value;
        }
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {   


            Balance += amount >= 0 ? amount : throw new ArgumentException("Deposit Amount shgoulc be greater tahn 0");
            //transactionHistory.Add($"{amount} is successfully Deposited");
            LogTransaction($"{amount} is successfully Deposited");
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount >= 0 && Balance>=amount ? amount : throw new ArgumentException("Deposit Amount shgoulc be greater tahn 0");
            LogTransaction($"{amount} is successfully Withdrawn");
        }

    }
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }
        public SavingsAccount(decimal interestRat, int amount) : base(amount)
        {
            InterestRate = interestRat;
            //  Console.WriteLine(balance); cannot be accessed since private
            Console.WriteLine(Balance); // can be accessed
           // Balance = 5000;   // cannot be accessed
        }

        
    }
}
