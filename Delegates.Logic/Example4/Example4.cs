using Delegates.Logic.Common.Entities;
using Delegates.Logic.Example1;

namespace Delegates.Logic.Example4
{
    public static class Example4
    {
        public static void GetAllMessages()
        {
            Person p1 = new Person("Lilya", Gender.Woman, 22);
            Person p2 = new Person("David", Gender.Man,24);
            
            LetterHandlerGeneric<Person>.GetAllMessages(p1, p2, "What about coffee?");
        }
        
        public static void GetLastMessage()
        {
            Person p1 = new Person("Lilya", Gender.Woman, 22);
            Person p2 = new Person("David", Gender.Man,24);
            
            LetterHandlerGeneric<Person>.GetLastMessages(p1, p2, "What about coffee?");
        }
    }
}