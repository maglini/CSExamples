using System;
using System.Runtime.CompilerServices;
using ConsoleApp6.Entities;

namespace ConsoleApp6
{
    public class MoneyReceivedArgs : EventArgs
    {
        public Money MoneyBalance { get; init; }
        
        public Money MoneyDifference { get; init; }
        
        public string Message { get; init; }
        public Person Person { get; init; }
        
        public MoneyReceivedArgs(Money moneyBalance, Money moneyDifference, string message, Person person)
        {
            MoneyBalance = moneyBalance;
            MoneyDifference = moneyDifference;
            Message = message;
            Person = person;
        }
    }

    public class Money
    {
        public decimal moneyValue { get; init; }
        
        public Money(decimal moneyValue)
        {
            this.moneyValue = moneyValue;
        }

        public static Money operator +(Money oldMoney, Money newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue + newMoney.moneyValue;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator +(Money oldMoney, decimal newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue + newMoney;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator -(Money oldMoney, Money newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue - newMoney.moneyValue;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator -(Money oldMoney, decimal newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue - newMoney;
            
            return new Money(resultMoneyValue);
        }

        public static bool operator < (Money oldMoney, Money newMoney)
        {
            return oldMoney.moneyValue < newMoney.moneyValue;
        }

        public static bool operator >(Money oldMoney, Money newMoney)
        {
            return oldMoney.moneyValue > newMoney.moneyValue;
        }
    }
    
    public class Account
    {
        protected Person Owner { get; init; }
        
        private event EventHandler<MoneyReceivedArgs> moneyReceivedEvent;
        public event EventHandler<MoneyReceivedArgs> MoneyReceivedEvent
        {
            add
            {
                Console.WriteLine("Subscribe to event");
                moneyReceivedEvent += value;
            }
            remove
            {
                Console.WriteLine("UnSubscribe to event");
                moneyReceivedEvent -= value;
            }
        }

        private Money money;

        public Money Money
        {
            get => money;
            set
            {
                if (value != null)
                {
                    Money moneyDiff = null;
                    string message = default!;
                    if (money < value)
                    { 
                        moneyDiff = value - money;
                        message = "New money has received";
                    }
                    else if (money > value)
                    { 
                        moneyDiff = value - money;
                        message = "Write-off from balance";
                    }
                    money = value;
                    moneyReceivedEvent?.Invoke(this, new MoneyReceivedArgs(money, moneyDiff, person: this.Owner, message:"write-off from balance"));
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        
    
        public Account(Person person, Money money)
        {
            this.Owner = person;
            this.money = money;

        }
    }

    public class Printer
    {
        public Printer(Account account)
        {
            account.MoneyReceivedEvent += AccountOnMoneyReceivedEvent;
        }

        private void AccountOnMoneyReceivedEvent(object? sender, MoneyReceivedArgs e)
        {
            Console.WriteLine("PRINT PRINT PRINT");
            Console.WriteLine(e.Message);
            Console.WriteLine($"To {e.Person.Name}");
            Console.WriteLine($"MoneyBalance: {e.MoneyBalance.moneyValue}");
            if (e.MoneyDifference.moneyValue < 0)
            {
                Console.WriteLine($"Money taken away: {e.MoneyDifference.moneyValue}");
            }
            else
            {
                Console.WriteLine($"Money received: {e.MoneyDifference.moneyValue}");
            }
        }
    }

    public static class Executor
    {
        public static void Execute()
        {
            Person person = new Person("Jack", Gender.Man, 27);
            Account account = new Account(person, new Money(500));
            Printer printer = new Printer(account);

            Console.WriteLine("---------------------");
            account.Money += 50;
            account.Money -= 100;
        }
    }
}