using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Common
{
    public static class LetterStyle
    {
        public static string GetBusinessStyleLetter(Person from, Person to, string phrase)
            => $"Hello,\n{to.Name}.\n{phrase}\nBest regards\n{from.Name}";
        
        public static string GetFriendlyStyleLetter(Person from, Person to, string phrase)
            => $"Hi,\n{to.Name}.\n{phrase}\nSee you soon\n{from.Name}";
        
        public static string GetRomanticStyleLetter(Person from, Person to, string phrase)
            => $"Dear,\n{to.Name}.\n{phrase}\nXOXO,\n{from.Name}";

        
    }
}