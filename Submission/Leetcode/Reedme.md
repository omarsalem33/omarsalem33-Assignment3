# Single Number (LeetCode #136)

Solution to the [Single Number](https://leetcode.com/problems/single-number/) problem on LeetCode using C#.

## 📝 Problem Statement

Given a **non-empty** array of integers `nums`, every element appears *twice* except for one. Find that single one.

### Constraints
- $1 \le \text{nums.length} \le 3 \times 10^4$
- $-3 \times 10^4 \le \text{nums}[i] \le 3 \times 10^4$
- Each element in the array appears twice except for one element which appears exactly once.

---

## 💡 Approaches

### Approach 1: Frequency Counting using `Dictionary<TKey, TValue>` (Implemented)

This approach utilizes a hash map (`Dictionary<int, int>`) to track the frequency of occurrences for each number in the array.

1. **Count Frequencies:** Iterate through `nums` and increment the count for each integer in the dictionary.
2. **Find Single Element:** Iterate through the key-value pairs of the dictionary to find the entry with a value equal to `1`.

#### C# Implementation

```csharp
using System;
using System.Collections.Generic;

namespace SingleNumberLeetCode;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.SingleNumber([1])); // Output: 1
    }

    public class Solution 
    {
        private Dictionary<int, int> counts = new Dictionary<int, int>();

        public int SingleNumber(int[] nums) 
        {
            counts.Clear(); // Clear previous entries for repeated calls

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

            return -1; // Fallback return statement
        }
    }
}
```

#### Complexity Analysis

- **Time Complexity:** $\mathcal{O}(n)$ — We traverse the input array once to build the dictionary and iterate over the dictionary entries (at most $n$ items) to find the element with frequency 1.
- **Space Complexity:** $\mathcal{O}(n)$ — Extra memory is allocated to store elements in the hash map.

---

### Approach 2: Bitwise XOR Operator (Optimal $O(1)$ Space Solution)

While the dictionary approach works in linear time, it requires $O(n)$ space. The problem optimal solution uses the **bitwise XOR (`^`)** operator to achieve $O(1)$ extra space.

#### Properties of XOR:
1. $a \oplus a = 0$ (A number XORed with itself cancels out to zero)
2. $a \oplus 0 = a$ (A number XORed with zero remains unchanged)

#### Code

```csharp
public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        int single = 0;
        foreach (int num in nums) 
        {
            single ^= num;
        }
        return single;
    }
}
```

#### Complexity Analysis
- **Time Complexity:** $\mathcal{O}(n)$
- **Space Complexity:** $\mathcal{O}(1)$

---

## 🔗 Links

- **Problem Description:** [LeetCode - Single Number](https://leetcode.com/problems/single-number/)
- **Submission Detail:** [LeetCode Submission #2142458257](https://leetcode.com/problems/single-number/submissions/2142458257/)