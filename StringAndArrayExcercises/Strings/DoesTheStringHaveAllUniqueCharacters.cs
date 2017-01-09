using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    /*
     * Given an arbitrary string, write code that can figure out if
     * a string has only unique characters.
     * 
     * What if no additional space can be used?
     */

    public class DoesTheStringHaveAllUniqueCharacters
    {
        /**
         * @ CheckExhaustively(string => bool)
         * 
         * Easiest way to do this imo is to do a brute force search
         * 
         * (+) No additional space
         * (-) O(n^2) worst-case
         */

        public bool CheckExhaustively(string input)
        {
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && input[i] == input[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /**
         * @ CheckUsingHashTable(string => bool)
         * 
         * Could simply use a HashTable to lookup already seen characters in the string.
         * 
         * (+) Efficient, hashtables have a constant lookup time
         * (-) SPACE complexity of O(n)
         */

        public bool CheckUsingHashTable(string input)
        {
            var length = input.Length;
            var lookupTable = new Hashtable();

            for (int i = 0; i < length; i++)
            {
                if (!lookupTable.ContainsKey(input[i]))
                {
                    lookupTable.Add(input[i], 0);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * @ CheckUsingBitVector(string => bool)
         * 
         * Uses a bit vector which requires 8x|16x less space than hash table.
         * 
         * (+) More space efficient compared to Hashtable
         * (-) Still requires extra space 
         */
        public bool CheckUsingBitVector(string input)
        {
            var bitArray = new BitArray(char.MaxValue);
            for (int i = 0; i < input.Length; i++)
            {
                if (bitArray[input[i]])
                {
                    return false;
                }
                bitArray[input[i]] = true;
            }

            return true;
        }

        
    }
}
