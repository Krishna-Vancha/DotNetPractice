using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
    internal class EncapsulationDemo
    {
        private decimal balance;
        public string name { get; }
        public readonly List<string> transactions = new();

        public IReadOnlyList<string> TransactionsLog=> transactions.AsReadOnly();
        public decimal Balance=> balance;

        public EncapsulationDemo(decimal balance, string name)
        {
            if (balance < 0)
            {
                throw new ArgumentException("Balasnce needs to be more than 0");
            }
            else
            {
                this.balance = balance;
            }
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException("Name should be provided properly");
            }
            else {
                this.name = name;
            }
            transactions.Add($"Created account with {name} and balance {this.balance : C}");


        }
        public void Withdraw(decimal amount)
        { if (amount > this.balance)
            {
                throw new ArgumentException(nameof(amount), "Withdrawal must be positive.");
            }
            else
            { 
                this.balance= amount;
            }

            
            transactions.Add($"Amount Withdrwan on {name} and current balance is {this.balance: C}");
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new AggregateException("Amount should be greater than Zero");
            }
            else
            {
                this.balance += amount;
            }
            transactions.Add($"Amount Deposited on {name} and current balance is {this.balance: C}");
        }
    }
}
