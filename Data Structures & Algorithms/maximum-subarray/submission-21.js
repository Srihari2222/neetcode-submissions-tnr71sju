class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    maxSubArray(nums) {
        const n = nums.length;
        const dp = Array.from({ length: n + 1 }, () => Array(2).fill(0));
        
        dp[n - 1][1] = dp[n - 1][0] = nums[n - 1];
        for (let i = n - 2; i >= 0; i--) {
            dp[i][1] = Math.max(nums[i], nums[i] + dp[i + 1][1]);
            dp[i][0] = Math.max(dp[i + 1][0], dp[i][1]);
        }
        
        return dp[0][0];
    }
}