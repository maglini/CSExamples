using System;

namespace UnsafeCode.Logic
{
    public static class UnsafeCodeLogic
    {
        public static unsafe void Unsafe2DimArrayAccess(int[,] array)
        {
            int rowSize = array.GetLength(0);
            int columnSize = array.GetLength(1);

            fixed (int* pointer = array)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    int baseOfDim = row * columnSize;
                    for (int column = 0; column < columnSize; column++)
                    {
                        int item = pointer[baseOfDim + column];
                        Console.Write(item);
                        Console.Write(' ');
                    }

                    Console.WriteLine();
                }
            }
        }
        
        public static unsafe void StackallocDemo()
        {
            const int width = 20;
            char* pc = stackalloc Char[width];
            string s = "Jeffrey Richter";
            for (int index = 0; index < width; index++)
            {
                pc[width - index - 1] = (index < s.Length) ? s[index] : '.';
            }
    
            //Cледующая инструкция выводит на экран ".....rethciR yerffeJ" 
            Console.WriteLine(new string(pc, 0, width));
        }
        
        public static unsafe void InlineArrayDemo() {
      
            CharArray ca; 
            int widthInBytes = sizeof(CharArray);
            int width = widthInBytes / 2;
    
            string s = "Jeffrey Richter"; // 15 символов
    
            for (int index = 0; index < width; index++) {
                ca.Characters[width - index - 1] = (index < s.Length) ? s[index] : '.';
            }

            //Следующая инструкция выводит на экран ".....rethciR yerffeJ" 
            Console.WriteLine(new string(ca.Characters, 0, width));
        }
        private unsafe struct CharArray {
            public fixed char Characters[20];
        }

    }
}