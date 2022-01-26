using System.Collections.Generic;

namespace corklibrary {
    public static class CorkLibrary {
        public static char[] ToArray(this int num) {
            string str = num.ToString();
            return str.ToArray();
        }
    }
}