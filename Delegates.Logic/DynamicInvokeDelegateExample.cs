using System;
using System.Collections.Generic;
using ConsoleApp6.Entities;

namespace ConsoleApp6
{
    public class DynamicInvokeDelegateExample
    {
        static class GetLetterBusinessStyle
        {
            public static string GetLetter(Person from, Person to, string phrase)
                => $"Hello,\n{to.Name}.\n{phrase}\nBest regards\n{from.Name}";
        }
    
        static class GetLetterFriendlyStyle
        {
            public static string GetLetter(Person from, Person to, string phrase)
                => $"Hi,\n{to.Name}.\n{phrase}\nSee you soon\n{from.Name}";
        }
    
        static class GetLetterRomanticStyle
        {
            public static string GetLetter(Person from, Person to, string phrase)
                => $"Dear,\n{to.Name}.\n{phrase}\nXOXO,\n{from.Name}";
        }
        
        static class LetterHandler
        {
            private static Func<Person, Person, string, string> GetLetterDelegate;
         
            public static void GetAllMessages(Person from, Person to, string phrase)
            {
                
                string title = $"New letter has received!\nDate: {DateTime.Now}";
            
                GetLetterDelegate += GetLetterBusinessStyle.GetLetter;
                GetLetterDelegate += GetLetterFriendlyStyle.GetLetter;
                GetLetterDelegate += GetLetterRomanticStyle.GetLetter;

                IList<string> letters = new List<string>();
                foreach (Delegate getLetterDelegate in GetLetterDelegate.GetInvocationList())
                {
                    if (getLetterDelegate.GetType() == GetLetterDelegate.GetType())
                    {
                        var letter = getLetterDelegate.DynamicInvoke(from, to, phrase);
                        letters.Add((string)letter);
                    }
                }
          
                foreach (var letter in letters)
                {
                    Console.WriteLine(letter);
                }
            }

            public static void GetLastMessages(Person from, Person to, string phrase)
            {
                string title = $"New letter has received!\nDate: {DateTime.Now}";
            
                GetLetterDelegate += GetLetterBusinessStyle.GetLetter;
                GetLetterDelegate += GetLetterFriendlyStyle.GetLetter;
                GetLetterDelegate += GetLetterRomanticStyle.GetLetter;

                string lastMessage = GetLetterDelegate.Invoke(from, to, phrase);

                Console.WriteLine(lastMessage);
            }
        }
        
        public static void GetAllMessages()
        {
            Person p1 = new Person("Lilya", Gender.Woman, 22);
            Person p2 = new Person("David", Gender.Man,24);
            
            LetterHandler.GetAllMessages(p1, p2, "What about coffee?");
        }
        
        public static void GetLastMessages()
        {
            Person p1 = new Person("Lilya", Gender.Woman,22);
            Person p2 = new Person("David", Gender.Man,24);
            
            LetterHandler.GetLastMessages(p1, p2, "What about coffee?");
        }
    }
}