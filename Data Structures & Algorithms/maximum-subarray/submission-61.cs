public class Solution {
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        int[,] dp = new int[n + 1, 2];
        
        dp[n - 1, 1] = dp[n - 1, 0] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            dp[i, 1] = Math.Max(nums[i], nums[i] + dp[i + 1, 1]);
            dp[i, 0] = Math.Max(dp[i + 1, 0], dp[i, 1]);
        }
        
        return dp[0, 0];
    }
}