using System;

namespace Delegates.Logic.Example3
{
    public class Printer
    {
        public Printer(Account account)
        {
            account.MoneyReceivedEvent += AccountOnMoneyReceivedEvent;
        }

        private void AccountOnMoneyReceivedEvent(object? sender, MoneyReceivedArgs e)
        {
            Console.WriteLine("PRINT PRINT PRINT PRINT PRINT PRINT PRINT PRINT");
            Console.WriteLine($"DATE:\t\t{e.Date}");
            Console.WriteLine($"To\t\t{e.Person.Name}");
            Console.WriteLine($"CURRENT MONEY BALANCE:\t\t{e.MoneyBalance.moneyValue}");
            
            Console.WriteLine( (e.MoneyDifference.moneyValue < 0)
                ? $"MONEY WAS DEBITED:\t\t{e.MoneyDifference.moneyValue}"
                : $"MONEY WAS RECEIVED:\t\t{e.MoneyDifference.moneyValue}");
            
            Console.WriteLine("PRINT PRINT PRINT PRINT PRINT PRINT PRINT PRINT");
        }
    }
}