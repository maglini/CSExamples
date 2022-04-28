using System;
using System.Collections.Generic;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example1
{
    public class LetterHandler
    {
        private static Func<Person, Person, string, string> GetLetterDelegate;
         
        public static void GetAllMessages(Person from, Person to, string phrase)
        {
                
            string title = $"New letter has received!\nDate: {DateTime.Now}";
            
            GetLetterDelegate += LetterStyle.GetBusinessStyleLetter;
            GetLetterDelegate += LetterStyle.GetFriendlyStyleLetter;
            GetLetterDelegate += LetterStyle.GetRomanticStyleLetter;

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
            
            GetLetterDelegate += LetterStyle.GetBusinessStyleLetter;
            GetLetterDelegate += LetterStyle.GetFriendlyStyleLetter;
            GetLetterDelegate += LetterStyle.GetRomanticStyleLetter;

            string lastMessage = GetLetterDelegate.Invoke(from, to, phrase);

            Console.WriteLine(lastMessage);
        }
    }
}