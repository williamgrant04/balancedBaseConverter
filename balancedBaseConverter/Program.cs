using System;
using System.Linq;
using System.Collections.Generic;
using corklibrary;

namespace balancedBaseConverter {
    static class Program {
        static void Main(string[] args) {
            while (true) {
                Console.Write("Enter a base: ");
                int eBase = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter a number to convert: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(number.ToBase(eBase));
                Console.WriteLine(number.ToBalancedBase(eBase));
            }
        }

        public static int ToBase(this int num, int eBase) {
            char[] number = num.ToArray();
            if (number[0] == '-')
                throw new ArgumentException("Number cannot be negative, try ToBalancedBase instead.");

            List<int> converted = new List<int>();

            while (num != 0) {
                converted.Add(num % eBase);
                num /= eBase;
            }
            converted.Reverse();
            return Convert.ToInt32(String.Join("", converted));
        }

        public static string ToBalancedBase(this int num, int eBase) {
            List<int> unbalanced = new List<int>();
            List<string> bal = new List<string>();

            #region Convert the base10 number into chosen base
            while (num != 0) {
                unbalanced.Add(num % eBase);
                num /= eBase;
            }
            int uCount = unbalanced.Count();
            #endregion

            #region Getting the numbers that the base uses in a balanced form
            for (int i = 0; i < eBase/2; i++) {
                bal.Add(Convert.ToString(i+1));
            }
            bal.Add("0");
            for (int j = 0; j < eBase/2; j++) {
                bal.Add("-" + Convert.ToString(j + 1));
            }
            List<int> balBase = bal.Select(str => Convert.ToInt32(str)).ToList();
            balBase.Reverse();
            #endregion

            for (int k = 0; k < uCount; k++) {
                if ((unbalanced[k] > balBase.Last()) && (unbalanced[k] != eBase)) {
                    unbalanced[k] -= eBase;
                    try {
                        unbalanced[k + 1] += 1;
                    } catch {
                        unbalanced.Add(1);   
                    }
                } else if (unbalanced[k] == eBase) {
                    unbalanced[k] = 0;
                    try {
                        unbalanced[k + 1] += 1;
                    } catch {
                        unbalanced.Add(1);   
                    }
                }
            }

            unbalanced.Reverse();
            return string.Join("", unbalanced);
        }
    }
}