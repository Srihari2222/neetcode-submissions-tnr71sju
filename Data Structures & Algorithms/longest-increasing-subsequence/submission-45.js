class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    lengthOfLIS(nums) {
        const n = nums.length;
        const dp = Array.from({ length: n + 1 }, () => new Array(n + 1).fill(0));

        for (let i = n - 1; i >= 0; i--) {
            for (let j = i - 1; j >= -1; j--) {
                let LIS = dp[i + 1][j + 1]; // Not including nums[i]

                if (j === -1 || nums[j] < nums[i]) {
                    LIS = Math.max(LIS, 1 + dp[i + 1][i + 1]); // Including nums[i]
                }

                dp[i][j + 1] = LIS;
            }
        }

        return dp[0][0];
    }
}
