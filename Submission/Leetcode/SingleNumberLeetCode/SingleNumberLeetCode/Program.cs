using System.Collections.Generic;

namespace SingleNumberLeetCode;

class Program
{
    
    static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine( s.SingleNumber([1]));
       
    }
    public class Solution {
        private Dictionary<int, int> counts = new Dictionary<int, int>();
        public int SingleNumber(int[] nums) {

            foreach (int num in nums)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;
                else 
                    counts[num] = 1;
            }

            foreach (var x in counts)
            {
                if (x.Value == 1)
                    return x.Key;
            }

            return -1; // Moved inside the method to close all execution paths
        }
    }
}