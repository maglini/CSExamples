using System;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example3
{
    public class MoneyReceivedArgs : EventArgs
    {
        public Money MoneyBalance { get; init; }
        
        public Money MoneyDifference { get; init; }
        
        public DateTime Date { get; init; }
        public Person Person { get; init; }
        
        public MoneyReceivedArgs(Money moneyBalance, Money moneyDifference, DateTime date, Person person)
        {
            MoneyBalance = moneyBalance;
            MoneyDifference = moneyDifference;
            Date = date;
            Person = person;
        }
    }
}