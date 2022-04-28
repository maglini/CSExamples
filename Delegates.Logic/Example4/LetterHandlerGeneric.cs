using System;
using System.Collections.Generic;
using Delegates.Logic.Common;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example4
{
    public class LetterHandlerGeneric<T> where T : Person
    {
        private static Func<T, T, string, string> _getLetterDelegate;
        
        public static void GetAllMessages(T from, T to, string phrase)
        {
            string title = $"New letter has received!\nDate: {DateTime.Now}";
            
            _getLetterDelegate += LetterStyle.GetBusinessStyleLetter;
            _getLetterDelegate += LetterStyle.GetFriendlyStyleLetter;
            _getLetterDelegate += LetterStyle.GetRomanticStyleLetter;

            IList<string> letters = new List<string>();
            foreach (Delegate getLetterDelegate in _getLetterDelegate.GetInvocationList())
            {
                if (getLetterDelegate.GetType() == _getLetterDelegate.GetType())
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

        public static void GetLastMessages(T from, T to, string phrase)
        {
            string title = $"New letter has received!\nDate: {DateTime.Now}";
            
            _getLetterDelegate += LetterStyle.GetBusinessStyleLetter;
            _getLetterDelegate += LetterStyle.GetFriendlyStyleLetter;
            _getLetterDelegate += LetterStyle.GetRomanticStyleLetter;

            string lastMessage = _getLetterDelegate.Invoke(from, to, phrase);

            Console.WriteLine(lastMessage);
        }
    }
}