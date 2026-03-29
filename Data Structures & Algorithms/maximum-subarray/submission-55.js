class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    maxSubArray(nums) {
        const memo = Array(nums.length + 1).fill(null).map(
            () => [null, null]
        );

        const dfs = (i, flag) => {
            if (i === nums.length) return flag ? 0 : -1e6;
            if (memo[i][+flag] !== null) return memo[i][+flag];
            memo[i][+flag] = flag ? Math.max(0, nums[i] + dfs(i + 1, true))
                                : Math.max(dfs(i + 1, false), 
                                           nums[i] + dfs(i + 1, true));
            return memo[i][+flag];
        }
        return dfs(0, false);
    }
}