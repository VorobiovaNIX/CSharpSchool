using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
 
    public interface IBaseCollection
    {
        void Add(Object obj);
        void Remove(Object obj);

        //void Clear();
    }

    public static class BaseCollectionExtension // extension method for interface 
    {
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach (var item in objects)
            {
                collection.Add(item);
            }
        }
    }


    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int count = 0;

        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];

        }

        public void Add(object obj)
        {
            items[count] = obj;
            count++;
        }

        public void Remove(object obj)
        {
            items[count] = null;
            count--;
        }
    }

}
