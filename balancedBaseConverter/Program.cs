using System;
using System.Linq;
using System.Collections.Generic;
using corklibrary;

namespace balancedBaseConverter {
    class Program {
        static void Main(string[] args) {
            int[] list = {};
            list = list.RemoveAt(0);
            
            foreach (int item in list)
                Console.Write(item);
        }
    }
}