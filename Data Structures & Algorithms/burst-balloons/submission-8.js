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

        return this.dfs(newNums, 1, newNums.length - 2);
    }

    /**
     * @param {number[]} nums
     * @param {number} l
     * @param {number} r
     * @return {number}
     */
    dfs(nums, l, r, dp) {
        if (l > r) return 0;

        let maxCoins = 0;
        for (let i = l; i <= r; i++) {
            let coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += this.dfs(nums, l, i - 1) + this.dfs(nums, i + 1, r);
            maxCoins = Math.max(maxCoins, coins);
        }
        return maxCoins;
    }
}