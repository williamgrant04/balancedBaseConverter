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
            Console.Write(number.ToBase(3));
            Console.Write("\n" + number.ToBalancedBase(3));
        }

        public static int ToBase(this int num, int eBase, bool balanced = false) {
            char[] number = num.ToArray();
            if (!balanced)
                if (number[0] == '-')
                    throw new ArgumentException("Number cannot be negative, try ToBalancedBase instead.");

            List<int> converted = new List<int>();

            while (num != 0) {
                converted.Add(num % eBase);
                num /= eBase;
            }

            if (balanced) {
                return num.ToBalancedBase(eBase);
            } else {
                return Convert.ToInt32(String.Join("", converted));
            }

        }

        public static int ToBalancedBase(this int num, int eBase) {
            List<int> unbalanced = new List<int>();
            List<string> balBase = new List<string>();

            while (num != 0) {
                unbalanced.Add(num % eBase);
                num /= eBase;
            }

            #region Getting the numbers that the base uses in a balanced form
            for (int i = 0; i < eBase/2; i++) {
                balBase.Add(Convert.ToString(i+1));
            }
            balBase.Add("0");
            for (int j = 0; j < eBase/2; j++) {
                balBase.Add("-" + Convert.ToString(j + 1));
            }
            #endregion


        }
    }
}