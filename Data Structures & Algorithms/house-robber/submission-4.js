class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    rob(nums) {
        
        const dfs = (i) => {
            if (i >= nums.length) {
                return 0;
            }
            return Math.max(dfs(i + 1), 
                            nums[i] + dfs(i + 2));
        }
        return dfs(0);
    }
}
