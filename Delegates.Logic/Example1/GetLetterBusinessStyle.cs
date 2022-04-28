using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example1
{
    public static class LetterStyle
    {
        public static string GetBusinessStyleLetter(Employee from, Employee to, string phrase)
            => $"Hello,\n{to.Name}.\n{phrase}\nBest regards\n{from.Name}";
        
        public static string GetFriendlyStyleLetter(Person from, Person to, string phrase)
            => $"Hi,\n{to.Name}.\n{phrase}\nSee you soon\n{from.Name}";
        
        public static string GetRomanticStyleLetter(Person from, Person to, string phrase)
            => $"Dear,\n{to.Name}.\n{phrase}\nXOXO,\n{from.Name}";

        public static string GetBusinessStyleLetter(Person arg1, Person arg2, string arg3)
        {
            throw new System.NotImplementedException();
        }
    }
}