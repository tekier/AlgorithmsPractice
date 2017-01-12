using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class ReplaceSpacesWithString
    {
        public void ReplaceUsingStringBuilder(ref string input)
        { 
            StringBuilder builder = new StringBuilder(input);
            builder.Replace(" ", "_");
            input = builder.ToString();
        }

        public void ReplaceUsingBasicStringOps(ref string input)
        {
            string temp = string.Empty;
            foreach (char character in input)
            {
                if (character.ToString().Equals(" "))
                {
                    temp = temp + "_";
                }
                else
                {
                    temp =  temp + character;
                }
            }
            input = temp;
        }
    }
}
