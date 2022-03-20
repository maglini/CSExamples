using System;
using System.Collections.Generic;

namespace Logic.Compares
{
    public class UniqueGenericComparer<T> : IEqualityComparer<T> where T : class
    {
        private readonly IEnumerable<Func<T, object>> _funcs;

        public UniqueGenericComparer(IEnumerable<Func<T, object>> funcs)
        {
            _funcs = funcs;
        }
        
        public UniqueGenericComparer(Func<T, object> func)
        {
            _funcs = new List<Func<T, object>>() {func};
        }
   
        public bool Equals(T ? t1, T? t2)
        {
            bool result = t1!= null && t2 != null;
            
            foreach (var func in _funcs)
            {
                result &= func.Invoke(t1) == func.Invoke(t2);
            }
            
            return result;
        }

        public int GetHashCode(T t)
        {
            var hash = 0;
            foreach (var func in _funcs)
            {
                var property = func.Invoke(t);
                hash += property.GetHashCode();
            }

            return hash;
        }
    }
}