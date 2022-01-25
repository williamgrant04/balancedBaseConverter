using System;
using System.Linq;
using System.Collections.Generic;
using corklibrary;

namespace balancedBaseConverter {
    static class Program {
        static void Main(string[] args) {
            //Console.Write("Enter a base: ");
            //int eBase = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a number to convert: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write(number.ToBase(2));
        }

        public static int ToBase(this int num, int eBase, bool balanced = false) {
            char[] number = num.ToArray();
            if (number[0] == '-') {
                throw new ArgumentException("Number cannot be negative, try ToBalancedBase instead.");
            }

            List<int> converted = new List<int>();

            while (num != 0) {
                converted.Add(num % eBase);
                num /= eBase;
            }

            if (balanced) {
                return num.ToBalancedBase(eBase);
            } else {
                return Convert.ToInt32(converted);
            }

        }

        public static int ToBalancedBase(this int num, int enBase) {

        }
    }
}