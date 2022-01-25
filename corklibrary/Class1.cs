using System.Collections.Generic;

namespace corklibrary {
    public static class ArrayC {
        public static T[] RemoveAt<T>(this T[] arg,int index) {
            List<T> list = arg.ToList();

            if (index < 0 || index >= list.Count) 
                throw new IndexOutOfRangeException("Attempt to remove item from array at index " + index + ". Index does not exist within array.");

            list.RemoveAt(index);
            return list.ToArray();
        }

        public static char[] ToArray(this int num) {
            string str = num.ToString();
            return str.ToArray();
        }
    }
}