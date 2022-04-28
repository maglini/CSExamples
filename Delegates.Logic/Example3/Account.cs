using System;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example3
{
    public class Account
    {
        private Person Owner { get; init; }
        
        private event EventHandler<MoneyReceivedArgs> moneyReceivedEvent;
        public event EventHandler<MoneyReceivedArgs> MoneyReceivedEvent
        {
 
            add
            {
                Console.WriteLine($"{value?.Target?.GetType().Name} subscribe to event successfully!");
                moneyReceivedEvent += value;
            }
            remove
            {
                Console.WriteLine($"{value?.Target?.GetType().Name} unsubscribe to event successfully!");
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
                    Money moneyDiff = value - money;
                    money = value;
                    moneyReceivedEvent?.Invoke(this, new MoneyReceivedArgs(money, moneyDiff, person: this.Owner, date: DateTime.Now));
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
}