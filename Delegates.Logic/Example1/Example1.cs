using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example1
{
    public static class Example1
    {
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