using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class StringRotationDetector
    {
        /**
         * The aim is to write a method DetectRotation(string, string => bool)
         * Given an stringToCheck, find if that string is a rotation of the referenceString.
         */

        public bool CheckRotation(string referenceString, string stringToCheck)
        {
            if (referenceString.Length != stringToCheck.Length)
                return false;
            return (stringToCheck + stringToCheck).Contains(referenceString);
        }
    }
}
