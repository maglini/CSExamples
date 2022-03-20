using System.Collections.Generic;
using Logic.Models;

namespace Logic.Compares
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User? user1, User? user2)
        {
            return user2 != null
                   && user1 != null
                   && user1.Id == user2.Id
                   && user1.Name == user2.Name
                   && user1.Username == user2.Username;
        }

        public int GetHashCode(User user)
        {
            return user.Username.GetHashCode();
        }
    }

}