class Solution {
    /**
     * @param {number[]} nums
     * @return {number[][]}
     */
    subsetsWithDup(nums) {
        const res = [];
        nums.sort((a, b) => a - b);
        this.backtrack(0, [], nums, res);
        return res;
    }

    /**
     * @param {number} start
     * @param {number[]} subset
     * @param {number[]} nums
     * @param {number[][]} res
     * @return {void}
     */
    backtrack(start, subset, nums, res) {
        res.push([...subset]);
        for (let i = start; i < nums.length; i++) {
            if (i > start && nums[i] === nums[i - 1]) {
                continue;
            }
            subset.push(nums[i]);
            this.backtrack(i + 1, subset, nums, res);
            subset.pop();
        }
    }
}