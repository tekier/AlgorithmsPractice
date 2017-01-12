using System.Collections.Generic;

namespace Strings
{
    public class Permutations
    {
        public string[] GetPermutationsOf(string input)
        {
            if (input.Equals(string.Empty))
                return new[] {" "};
            if (input.Length == 1)
                return new[] {input};

            var combinations = new List<string>();
            RecursivelyFillList(ref combinations, "", input);
            return combinations.ToArray();
        }

        public void RecursivelyFillList(ref List<string> list, string stringSoFar, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                list.Add(stringSoFar);
                return;
            }
            for (int index = 0; index < input.Length; index++)
            {
                string remainingString = input.Substring(0, index) + input.Substring(index + 1);
                RecursivelyFillList(ref list, stringSoFar+input[index], remainingString);
            }
        }
    }
}
