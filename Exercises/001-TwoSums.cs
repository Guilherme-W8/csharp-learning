using System;

public class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        return new int[] { };
    }
}

class Program
{
    static void Main()
    {
        int[] result = Solution.TwoSum(new int[] { 11, 15, 7 }, 18);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
}