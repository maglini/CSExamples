using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp6.Entities;

namespace ConsoleApp6
{
 
    class Program
    {
        public static void Main()
        {
            Executor.Execute();
            
            MyLinqExample.Execute();
            
            DynamicInvokeDelegateExample.GetAllMessages();
            
            DynamicInvokeDelegateExample.GetLastMessages();
        }
    }
}