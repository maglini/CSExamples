using System;

namespace UnsafeCode.Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,] {{1, 2, 3}, {4, 5, 6}};
            UnsafeCodeLogic.Unsafe2DimArrayAccess(array);
            
            UnsafeCodeLogic.StackallocDemo();
            
            UnsafeCodeLogic.InlineArrayDemo();
        }
    }
}