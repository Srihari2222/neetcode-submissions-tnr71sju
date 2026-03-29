class Solution {
    /**
     * @param {number[]} nums
     * @param {number} target
     * @return {number}
     */
    findTargetSumWays(nums, target) {

        const backtrack = (i, total) => {
            if (i === nums.length) {
                return total === target ? 1 : 0;
            }
            return backtrack(i + 1, total + nums[i]) + 
                backtrack(i + 1, total - nums[i]);
        }

        return backtrack(0, 0);
    }
}