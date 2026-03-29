public class Solution {
    private int[,] dp;
    private int totalSum;

    public int FindTargetSumWays(int[] nums, int target) {
        totalSum = 0;
        foreach (var num in nums) totalSum += num;
        dp = new int[nums.Length, 2 * totalSum + 1];
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < 2 * totalSum + 1; j++) {
                dp[i, j] = int.MinValue;  
            }
        }
        return Backtrack(0, 0, nums, target);
    }

    private int Backtrack(int i, int total, int[] nums, int target) {
        if (i == nums.Length) {
            return total == target ? 1 : 0;
        }

        if (dp[i, total + totalSum] != int.MinValue) {
            return dp[i, total + totalSum];  
        }

        dp[i, total + totalSum] = Backtrack(i + 1, total + nums[i], nums, target) + 
                                  Backtrack(i + 1, total - nums[i], nums, target);  
        return dp[i, total + totalSum];
    }
}