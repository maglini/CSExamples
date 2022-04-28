using System;
using System.Threading;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example3
{
    public static class Example3
    {
        public static void Execute()
        {
            Console.WriteLine("----------Created----------Account----------");
            Person person = new Person("Jack", Gender.Man, 27);
            Account account = new Account(person, new Money(500));
            Printer printer = new Printer(account);
            
            Console.WriteLine("----------First----------Transaction----------");
            account.Money += 50;
            
            Thread.Sleep(2000);
            
            Console.WriteLine("----------Second----------Transaction----------");
            account.Money -= 100;
        }
    }
}