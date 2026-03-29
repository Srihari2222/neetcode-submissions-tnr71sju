class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    rob(nums) {
        if (nums.length === 1) return nums[0];

        const dfs = (i, flag) => {
            if (i >= nums.length || (flag && i === nums.length - 1)) 
                return 0;

            return Math.max(dfs(i + 1, flag), 
                            nums[i] + dfs(i + 2, flag || i === 0));
        }
        
        return Math.max(dfs(0, true), dfs(1, false));
    }
}