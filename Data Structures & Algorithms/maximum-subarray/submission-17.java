class Solution {
    public int maxSubArray(int[] nums) {
        int n = nums.length;
        int[][] dp = new int[n + 1][2];
        
        for (int i = n - 1; i >= 0; i--) {
            dp[i][1] = Math.max(0, nums[i] + dp[i + 1][1]);
            dp[i][0] = Math.max(dp[i + 1][0], nums[i] + dp[i + 1][1]);
        }
        
        return dp[0][0];
    }
}