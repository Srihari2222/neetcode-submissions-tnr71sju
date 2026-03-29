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

        let dp = Array.from({ length: n + 2 }, () => new Array(n + 2).fill(0));
        for (let l = n; l >= 1; l--) {
            for (let r = l; r <= n; r++) {
                for (let i = l; i <= r; i++) {
                    let coins = newNums[l - 1] * newNums[i] * newNums[r + 1];
                    coins += dp[l][i - 1] + dp[i + 1][r];
                    dp[l][r] = Math.max(dp[l][r], coins);
                }
            }
        }

        return dp[1][n];
    }
}