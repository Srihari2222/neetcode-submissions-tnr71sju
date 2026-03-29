class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    maxCoins(nums) {
        let n = nums.length;
        let newNums = new Array(n + 2).fill(1);
        for (let i = 0; i < n; i++) {
            newNums[i + 1] = nums[i];
        }

        let dp = Array.from({ length: n + 2 }, () => new Array(n + 2).fill(-1));
        return this.dfs(newNums, 1, newNums.length - 2, dp);
    }

    /**
     * @param {number[]} nums
     * @param {number} l
     * @param {number} r
     * @param {number[][]} dp
     * @return {number}
     */
    dfs(nums, l, r, dp) {
        if (l > r) return 0;
        if (dp[l][r] !== -1) return dp[l][r];

        dp[l][r] = 0;
        for (let i = l; i <= r; i++) {
            let coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += this.dfs(nums, l, i - 1, dp) + this.dfs(nums, i + 1, r, dp);
            dp[l][r] = Math.max(dp[l][r], coins);
        }
        return dp[l][r];
    }
}